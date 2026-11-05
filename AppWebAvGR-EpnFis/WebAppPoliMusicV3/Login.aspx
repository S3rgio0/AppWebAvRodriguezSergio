<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppPoliMusicV3.Login" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Iniciar sesión | PoliMusic</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6 col-lg-5">
            <div class="card"><div class="card-body p-4">
                <h1 class="h3 mb-4">Iniciar sesión</h1>
                <div class="mb-3">
                    <asp:Label ID="lblLogin" runat="server" AssociatedControlID="txtLogin" CssClass="form-label" Text="Usuario" />
                    <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" MaxLength="100" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label" Text="Contraseña" />
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                <asp:Label ID="lblMessage" runat="server" CssClass="form-message text-danger" EnableViewState="false" />
                <p class="mt-3 mb-0">¿No tienes cuenta? <a href="<%: ResolveUrl("~/SignUp.aspx") %>">Regístrate</a></p>
            </div></div>
        </div>
    </div>
</asp:Content>
