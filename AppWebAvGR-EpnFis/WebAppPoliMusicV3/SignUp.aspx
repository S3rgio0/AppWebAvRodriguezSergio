<%@ Page Title="Crear cuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebAppPoliMusicV3.SignUp" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Crear cuenta | PoliMusic</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-8 col-lg-7">
            <div class="card"><div class="card-body p-4">
                <h1 class="h3 mb-4">Crear cuenta</h1>
                <div class="mb-3">
                    <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" CssClass="form-label" Text="Nombre de usuario" />
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="100" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label" Text="Correo electrónico" />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" MaxLength="256" />
                </div>
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label" Text="Contraseña" />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword" CssClass="form-label" Text="Confirmar contraseña" />
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblBirthday" runat="server" AssociatedControlID="txtBirthday" CssClass="form-label" Text="Fecha de nacimiento (dd/MM/yyyy)" />
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPhoto" runat="server" AssociatedControlID="uploadPhoto" CssClass="form-label" Text="Foto de perfil (JPG o PNG, máximo 10 MB)" />
                    <asp:FileUpload ID="uploadPhoto" runat="server" CssClass="form-control" accept=".jpg,.png" />
                </div>
                <asp:Button ID="btnSignUp" runat="server" Text="Crear cuenta" CssClass="btn btn-primary" OnClick="btnSignUp_Click" />
                <asp:Label ID="lblMessage" runat="server" CssClass="form-message" EnableViewState="false" />
            </div></div>
        </div>
    </div>
</asp:Content>
