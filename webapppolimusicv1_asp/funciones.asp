<%
Function HtmlEncode(ByVal value)
    If IsNull(value) Then
        HtmlEncode = ""
    Else
        HtmlEncode = Server.HTMLEncode(CStr(value))
    End If
End Function

Function IsAdmin()
    IsAdmin = (LCase(Trim(CStr(Session("Role")))) = "admin")
End Function

Sub RequireLogin()
    If Len(Trim(CStr(Session("Username")))) = 0 Then
        Response.Redirect "login.asp"
        Response.End
    End If
End Sub

Sub RequireAdmin()
    RequireLogin
    If Not IsAdmin() Then
        Response.Redirect "songs.asp"
        Response.End
    End If
End Sub

Function SongPath(ByVal value)
    Dim path
    path = Trim(CStr(value))
    If Left(path, 2) = "~/" Then
        path = Mid(path, 3)
    ElseIf Left(path, 1) = "/" Then
        path = Mid(path, 2)
    End If
    SongPath = Replace(path, "\", "/")
    If LCase(Left(SongPath, 10)) = "songfiles/" Then SongPath = Mid(SongPath, 11)
    If LCase(Left(SongPath, 13)) = "assets/audio/" Then SongPath = Mid(SongPath, 14)
    SongPath = "assets/audio/" & SongPath
End Function
%>
