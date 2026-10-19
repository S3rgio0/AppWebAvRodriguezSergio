<%
If Len(Trim(CStr(Session("Username")))) > 0 Then
    Response.Redirect "songs.asp"
Else
    Response.Redirect "login.asp"
End If
Response.End
%>
