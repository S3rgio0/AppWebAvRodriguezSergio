<!--#include file="funciones.asp"-->
<!--#include file="conexion.asp"-->
<%
RequireLogin
Dim rs, sql, songCount
sql = "SELECT id, song_name, file_path, reproductions FROM TBL_SONG ORDER BY id"
Set rs = conn.Execute(sql)
songCount = 0
%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>PoliMusic | Songs</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <header class="topbar">
        <a class="brand" href="songs.asp"><span class="brand-icon">♫</span> Poli<span>Music</span></a>
        <div class="user-menu">
            <span class="user-avatar"><%= UCase(Left(HtmlEncode(Session("Username")), 1)) %></span>
            <span><%= HtmlEncode(Session("Username")) %></span>
            <a href="logout.asp">Logout</a>
        </div>
    </header>
    <main class="dashboard">
        <section class="hero">
            <div>
                <p class="eyebrow">YOUR MUSIC LIBRARY</p>
                <h1>Welcome, <%= HtmlEncode(Session("Username")) %></h1>
                <p class="subtitle">Explore your collection and enjoy every beat.</p>
            </div>
            <% If IsAdmin() Then %><a class="primary-button compact" href="add_song.asp">+ Add new song</a><% End If %>
        </section>
        <section class="section-heading"><div><h2>Songs list</h2><p>Your curated collection</p></div></section>
        <div class="table-card">
            <table>
                <thead><tr><th>ID</th><th>Song Name</th><th>Play</th><th>Reproductions</th><% If IsAdmin() Then %><th>Actions</th><% End If %></tr></thead>
                <tbody>
                <% If rs.EOF Then %>
                    <tr><td class="empty" colspan="<% If IsAdmin() Then Response.Write "5" Else Response.Write "4" End If %>">No songs found.</td></tr>
                <% Else %>
                    <% Do Until rs.EOF
                        songCount = songCount + 1
                    %>
                    <tr>
                        <td class="muted">#<%= HtmlEncode(rs("id")) %></td>
                        <td class="song-title"><%= HtmlEncode(rs("song_name")) %></td>
                        <td><audio controls preload="none"><source src="<%= HtmlEncode(SongPath(rs("file_path"))) %>">Audio unavailable</audio></td>
                        <td><span class="plays"><%= HtmlEncode(rs("reproductions")) %></span></td>
                        <% If IsAdmin() Then %><td class="actions"><a href="edit_song.asp?id=<%= Server.URLEncode(rs("id")) %>">Edit</a><a class="danger-link" href="delete_song.asp?id=<%= Server.URLEncode(rs("id")) %>">Delete</a></td><% End If %>
                    </tr>
                    <% rs.MoveNext
                    Loop %>
                <% End If %>
                </tbody>
            </table>
        </div>
        <p class="library-count"><strong><%= songCount %></strong> songs in your library</p>
    </main>
</body>
</html>
<%
rs.Close
Set rs = Nothing
conn.Close
Set conn = Nothing
%>
