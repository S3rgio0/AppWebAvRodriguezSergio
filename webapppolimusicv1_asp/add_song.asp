<!--#include file="funciones.asp"-->
<!--#include file="conexion.asp"-->
<%
RequireAdmin
Dim songName, filePath, cmd, message
songName = Trim(Request.Form("song_name"))
filePath = Trim(Request.Form("file_path"))
message = ""
If Request.ServerVariables("REQUEST_METHOD") = "POST" Then
    If songName = "" Or filePath = "" Then
        message = "Song name and file path are required."
    Else
        Set cmd = Server.CreateObject("ADODB.Command")
        Set cmd.ActiveConnection = conn
        cmd.CommandText = "INSERT INTO TBL_SONG (song_name, file_path, reproductions) VALUES (?, ?, 0)"
        cmd.CommandType = 1
        cmd.Parameters.Append cmd.CreateParameter("@song_name", 200, 1, 255, songName)
        cmd.Parameters.Append cmd.CreateParameter("@file_path", 200, 1, 500, filePath)
        cmd.Execute
        conn.Close
        Set conn = Nothing
        Response.Redirect "songs.asp"
        Response.End
    End If
End If
%>
<!DOCTYPE html>
<html lang="en">
<head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><title>PoliMusic | Add song</title><link rel="stylesheet" href="styles.css"></head>
<body>
    <header class="topbar"><a class="brand" href="songs.asp"><span class="brand-icon">♫</span> Poli<span>Music</span></a><a href="logout.asp">Logout</a></header>
    <main class="dashboard narrow">
        <a class="back-link" href="songs.asp">← Back to songs</a>
        <div class="form-panel"><p class="eyebrow">ADMINISTRATION</p><h1>Add new song</h1><p class="subtitle">Add a new track to your music library.</p>
        <% If message <> "" Then %><div class="alert"><%= HtmlEncode(message) %></div><% End If %>
        <form method="post" action="add_song.asp" class="admin-form">
            <label for="song_name">Song name</label><input id="song_name" name="song_name" maxlength="255" value="<%= HtmlEncode(songName) %>" required>
            <label for="file_path">Audio file name</label><input id="file_path" name="file_path" maxlength="500" placeholder="bensound-adventure.mp3" value="<%= HtmlEncode(filePath) %>" required>
            <p class="form-hint">Files must be stored in <code>assets/audio/</code>.</p>
            <button class="primary-button" type="submit">Save song</button> <a class="secondary-button" href="songs.asp">Cancel</a>
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
