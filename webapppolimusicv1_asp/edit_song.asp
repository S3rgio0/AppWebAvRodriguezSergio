<!--#include file="funciones.asp"-->
<!--#include file="conexion.asp"-->
<%
RequireAdmin
Dim id, songName, filePath, cmd, rs, message
id = Trim(Request.QueryString("id"))
If Request.ServerVariables("REQUEST_METHOD") = "POST" Then id = Trim(Request.Form("id"))
If Not IsNumeric(id) Then Response.Redirect "songs.asp": Response.End
message = ""
If Request.ServerVariables("REQUEST_METHOD") = "POST" Then
    songName = Trim(Request.Form("song_name"))
    filePath = Trim(Request.Form("file_path"))
    If songName = "" Or filePath = "" Then
        message = "Song name and file path are required."
    Else
        Set cmd = Server.CreateObject("ADODB.Command")
        Set cmd.ActiveConnection = conn
        cmd.CommandText = "UPDATE TBL_SONG SET song_name = ?, file_path = ? WHERE id = ?"
        cmd.CommandType = 1
        cmd.Parameters.Append cmd.CreateParameter("@song_name", 200, 1, 255, songName)
        cmd.Parameters.Append cmd.CreateParameter("@file_path", 200, 1, 500, filePath)
        cmd.Parameters.Append cmd.CreateParameter("@id", 3, 1, 4, CLng(id))
        cmd.Execute
        conn.Close
        Set conn = Nothing
        Response.Redirect "songs.asp"
        Response.End
    End If
Else
    Set cmd = Server.CreateObject("ADODB.Command")
    Set cmd.ActiveConnection = conn
    cmd.CommandText = "SELECT song_name, file_path FROM TBL_SONG WHERE id = ?"
    cmd.CommandType = 1
    cmd.Parameters.Append cmd.CreateParameter("@id", 3, 1, 4, CLng(id))
    Set rs = cmd.Execute
    If rs.EOF Then rs.Close: conn.Close: Response.Redirect("songs.asp"): Response.End
    songName = rs("song_name")
    filePath = rs("file_path")
    rs.Close
    Set rs = Nothing
End If
%>
<!DOCTYPE html>
<html lang="en">
<head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><title>PoliMusic | Edit song</title><link rel="stylesheet" href="styles.css"></head>
<body>
    <header class="topbar"><a class="brand" href="songs.asp"><span class="brand-icon">♫</span> Poli<span>Music</span></a><a href="logout.asp">Logout</a></header>
    <main class="dashboard narrow">
        <a class="back-link" href="songs.asp">← Back to songs</a>
        <div class="form-panel"><p class="eyebrow">ADMINISTRATION</p><h1>Edit song</h1>
        <% If message <> "" Then %><div class="alert"><%= HtmlEncode(message) %></div><% End If %>
        <form method="post" action="edit_song.asp" class="admin-form">
            <input type="hidden" name="id" value="<%= HtmlEncode(id) %>">
            <label for="song_name">Song name</label><input id="song_name" name="song_name" maxlength="255" value="<%= HtmlEncode(songName) %>" required>
            <label for="file_path">Audio file name</label><input id="file_path" name="file_path" maxlength="500" value="<%= HtmlEncode(filePath) %>" required>
            <p class="form-hint">Files must be stored in <code>assets/audio/</code>.</p>
            <button class="primary-button" type="submit">Update song</button> <a class="secondary-button" href="songs.asp">Cancel</a>
        </form></div>
    </main>
</body>
</html>
<%
If Not conn Is Nothing Then
    If conn.State = 1 Then conn.Close
    Set conn = Nothing
End If
%>
