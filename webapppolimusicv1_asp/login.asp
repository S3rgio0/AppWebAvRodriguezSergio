<!--#include file="funciones.asp"-->
<!--#include file="conexion.asp"-->
<%
Dim username, password, cmd, rs, message
username = Trim(Request.Form("username"))
password = CStr(Request.Form("password"))
message = ""

If Request.ServerVariables("REQUEST_METHOD") = "POST" Then
    If username = "" Or password = "" Then
        message = "Please enter your username and password."
    Else
        Set cmd = Server.CreateObject("ADODB.Command")
        Set cmd.ActiveConnection = conn
        cmd.CommandText = "SELECT username, role FROM TBL_USER WHERE username = ? AND [password] = ?"
        cmd.CommandType = 1
        cmd.Parameters.Append cmd.CreateParameter("@username", 200, 1, 255, username)
        cmd.Parameters.Append cmd.CreateParameter("@password", 200, 1, 255, password)
        Set rs = cmd.Execute
        If rs.EOF Then
            message = "Invalid username or password."
        Else
            Session("Username") = rs("username")
            Session("Role") = rs("role")
            rs.Close
            Set rs = Nothing
            conn.Close
            Set conn = Nothing
            Response.Redirect "songs.asp"
            Response.End
        End If
        rs.Close
        Set rs = Nothing
        Set cmd = Nothing
    End If
End If
If Not conn Is Nothing Then
    If conn.State = 1 Then conn.Close
    Set conn = Nothing
End If
%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>PoliMusic | Login</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body class="auth-page">
    <main class="auth-card">
        <div class="brand-mark">♫</div>
        <p class="eyebrow">YOUR PERSONAL MUSIC SPACE</p>
        <h1>Welcome to PoliMusic</h1>
        <p class="intro">Sign in to discover, play and manage your favorite songs.</p>
        <% If message <> "" Then %><div class="alert"><%= HtmlEncode(message) %></div><% End If %>
        <form method="post" action="login.asp" class="form-card">
            <label for="username">Username</label>
            <input type="text" id="username" name="username" maxlength="255" autocomplete="username" required>
            <label for="password">Password</label>
            <input type="password" id="password" name="password" maxlength="255" autocomplete="current-password" required>
            <button class="primary-button" type="submit">Sign in <span>→</span></button>
        </form>
    </main>
</body>
</html>
