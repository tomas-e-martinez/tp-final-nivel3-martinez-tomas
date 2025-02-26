<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="presentacion.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mb-3">Mi Perfil</h1>
    <hr />
    <div class="row">
        <div class="col-12 mb-3">
            <asp:Label Text="Nombre *" runat="server" for="txtNombre" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" REQUIRED placeholder="Juan" />
        </div>
        <div class="col-12 mb-3">
            <asp:Label Text="Apellido *" runat="server" for="txtApellido" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" REQUIRED placeholder="Pérez" />
        </div>
        <div class="col-12 mb-3">
            <asp:Label Text="Imagen de perfil (URL)" runat="server" for="txtUrlImagen" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control" REQUIRED TextMode="Url" placeholder="https://imagenes.com/perfil.jpg" />
        </div>
    </div>
    <div class="row">
        <div class="col-4 mb-3">
            <asp:Button Text="Guardar cambios" runat="server" ID="btnGuardarPerfil" CssClass="btn btn-success" OnClick="btnGuardarPerfil_Click"/>
        </div>
        <div class="col-12 mb-3">
            <asp:Label runat="server" ID="lblMensaje" />
        </div>
    </div>

</asp:Content>
