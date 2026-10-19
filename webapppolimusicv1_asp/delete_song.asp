<!--#include file="funciones.asp"-->
<!--#include file="conexion.asp"-->
<%
RequireAdmin
Dim id, cmd
id = Trim(Request.QueryString("id"))
If Request.ServerVariables("REQUEST_METHOD") = "POST" Then id = Trim(Request.Form("id"))
If Not IsNumeric(id) Then Response.Redirect "songs.asp": Response.End
If Request.ServerVariables("REQUEST_METHOD") = "POST" Then
    Set cmd = Server.CreateObject("ADODB.Command")
    Set cmd.ActiveConnection = conn
    cmd.CommandText = "DELETE FROM TBL_SONG WHERE id = ?"
    cmd.CommandType = 1
    cmd.Parameters.Append cmd.CreateParameter("@id", 3, 1, 4, CLng(id))
    cmd.Execute
    conn.Close
    Set conn = Nothing
    Response.Redirect "songs.asp"
    Response.End
End If
%>
<!DOCTYPE html>
<html lang="en">
<head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><title>PoliMusic | Delete song</title><link rel="stylesheet" href="styles.css"></head>
<body>
    <header class="topbar"><a class="brand" href="songs.asp"><span class="brand-icon">♫</span> Poli<span>Music</span></a><a href="logout.asp">Logout</a></header>
    <main class="dashboard narrow"><div class="form-panel confirm-panel"><p class="eyebrow">ADMINISTRATION</p><h1>Delete song?</h1><p class="subtitle">This action cannot be undone.</p>
        <form method="post" action="delete_song.asp"><input type="hidden" name="id" value="<%= HtmlEncode(id) %>"><button class="danger-button" type="submit">Yes, delete it</button> <a class="secondary-button" href="songs.asp">Cancel</a></form>
    </div></main>
</body>
</html>
<%
If Not conn Is Nothing Then
    If conn.State = 1 Then conn.Close
    Set conn = Nothing
End If
%>
