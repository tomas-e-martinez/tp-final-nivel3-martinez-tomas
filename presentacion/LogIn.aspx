<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="presentacion.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Iniciar Sesión</h1>
    <hr />
    <div class="row mb-3">
        <div class="col-12 mb-3">
            <asp:Label Text="Correo electrónico" runat="server" for="txtUsuario" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" REQUIRED />
        </div>
        <div class="col-12 mb-3">
            <asp:Label Text="Contraseña" runat="server" for="txtPass" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" REQUIRED />
        </div>
        <div class="col-12 mb-3">
            <asp:Button Text="Ingresar" runat="server" ID="btnLogin" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
