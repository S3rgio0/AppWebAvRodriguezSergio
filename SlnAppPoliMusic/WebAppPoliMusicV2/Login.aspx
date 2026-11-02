<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppPoliMusicV2.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>PoliMusic - Login</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <div class="login-box">
            <h1>PoliMusic</h1>
            <h2>Iniciar Sesión</h2>
            <form id="loginForm" runat="server">
                <div class="form-group">
                    <label for="txtUsername">Usuario:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Contraseña:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="error-message"></asp:Label>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
