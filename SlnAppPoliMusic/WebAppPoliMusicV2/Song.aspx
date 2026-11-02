<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Song.aspx.cs" Inherits="WebAppPoliMusicV2.Song" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>PoliMusic - Canciones</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <div class="header">
            <h1>PoliMusic</h1>
            <asp:LinkButton ID="lnkLogout" runat="server" CssClass="logout-link" OnClick="lnkLogout_Click">Cerrar Sesión</asp:LinkButton>
        </div>
        <form id="songForm" runat="server">
            <div class="content">
                <h2>Listado de Canciones</h2>
                <asp:GridView ID="gvSongs" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                    <Columns>
                        <asp:BoundField DataField="TITLE" HeaderText="Título" />
                        <asp:TemplateField HeaderText="Reproductor">
                            <ItemTemplate>
                                <audio controls>
                                    <source src='<%# Eval("FILE_PATH") %>' type='audio/mpeg' />
                                    Tu navegador no soporta el elemento de audio.
                                </audio>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
