<%@ Page Title="Canciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Song.aspx.cs" Inherits="WebAppPoliMusicV3.Song" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Canciones | PoliMusic</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <section class="welcome-panel mb-4">
        <div class="welcome-icon" aria-hidden="true">♫</div>
        <div>
            <span class="eyebrow">POLIMUSIC · TU BIBLIOTECA</span>
            <h1>Bienvenido, <asp:Literal ID="litUserName" runat="server" Mode="Encode" /></h1>
            <p class="mb-0">Encuentra una canción y dale al play.</p>
        </div>
    </section>

    <section class="library-card">
        <div class="library-heading">
            <div><span class="eyebrow">BIBLIOTECA</span><h2 class="h3 mb-0">Song list</h2></div>
            <asp:Label ID="lblSongCount" runat="server" CssClass="song-count" />
        </div>
        <asp:Label ID="lblDataMode" runat="server" CssClass="preview-note" Visible="false" />
        <div class="table-responsive">
        <asp:GridView ID="gvSongs" runat="server" AutoGenerateColumns="false" CssClass="table song-table align-middle mb-0" EmptyDataText="No hay canciones disponibles.">
            <Columns>
                <asp:BoundField DataField="ID_SONG" HeaderText="ID Canción" />
                <asp:BoundField DataField="TITLE" HeaderText="Nombre" />
                <asp:BoundField DataField="FILE_PATH" HeaderText="Ruta" />
                <asp:BoundField DataField="PLAY_COUNT" HeaderText="Reproducciones" />
                <asp:TemplateField HeaderText="Reproducir">
                    <ItemTemplate>
                        <audio class="song-player" controls="controls"><source src='<%# Eval("FILE_PATH") %>' type="audio/mpeg" /></audio>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </section>
</asp:Content>
