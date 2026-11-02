<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppPoliMusicV2.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>PoliMusic - Inicio</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <div class="header">
            <h1>PoliMusic</h1>
            <asp:LinkButton ID="lnkLogout" runat="server" CssClass="logout-link" OnClick="lnkLogout_Click">Cerrar Sesión</asp:LinkButton>
        </div>
        <form id="defaultForm" runat="server">
            <div class="content">
                <h2>
                    Bienvenido <asp:Label ID="lblUsername" runat="server"></asp:Label>
                </h2>
                <div class="menu">
                    <asp:HyperLink ID="hlnkSongs" runat="server" NavigateUrl="Song.aspx" CssClass="menu-link">Ver Canciones</asp:HyperLink>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
