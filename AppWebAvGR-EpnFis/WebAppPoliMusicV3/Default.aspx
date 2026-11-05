<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppPoliMusicV3.Default" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Inicio | PoliMusic</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <section class="p-5 mb-4 bg-white rounded-3 shadow-sm">
        <div class="container-fluid py-2">
            <h1 class="display-5 fw-bold">Bienvenido a PoliMusic</h1>
            <p class="col-md-8 fs-5">Explora y reproduce las canciones disponibles en la biblioteca.</p>
            <a class="btn btn-primary btn-lg" href="<%: ResolveUrl("~/Song") %>">Ver canciones</a>
        </div>
    </section>
</asp:Content>
