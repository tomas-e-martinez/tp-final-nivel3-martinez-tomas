<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="presentacion.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mb-3">
        <h1>Mi Perfil</h1>
    </div>
    <div class="row">
        <div class="col-12 mb-3">
            <asp:Label Text="Nombre" runat="server" for="txtNombre" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" REQUIRED placeholder="Juan" />
        </div>
        <div class="col-12 mb-3">
            <asp:Label Text="Apellido" runat="server" for="txtApellido" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" REQUIRED placeholder="Pérez" />
        </div>
        <div class="col-12 mb-3">
            <asp:Label Text="Correo electrónico" runat="server" for="txtUser" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" REQUIRED TextMode="Email" placeholder="nombre@ejemplo.com" />
        </div>
    </div>
    <div class="row">
        <div class="col-4 mb-3">
            <asp:Button Text="Guardar Cambios" runat="server" ID="btnGuardarPerfil" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
