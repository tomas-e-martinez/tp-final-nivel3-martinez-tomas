<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="presentacion.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mb-3">Registrarse</h1>
    <hr />
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
            <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" REQUIRED TextMode="Email" placeholder="nombre@ejemplo.com"/>
        </div>
        <div class="col-12 mb-3">
            <asp:Label Text="Contraseña" runat="server" for="txtPass" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" REQUIRED />
        </div>
        <div class="col-12 mb-3">
            <asp:Label Text="Confirmar contraseña" runat="server" for="txtConfirmarPass" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtConfirmarPass" CssClass="form-control" TextMode="Password" REQUIRED />
        </div>
    </div>
    <div class="row">
        <div class="col-4 mb-3">
            <asp:Button Text="Registrarse" runat="server" ID="btnRegistrarse" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>
