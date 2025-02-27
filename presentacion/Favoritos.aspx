<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="presentacion.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mb-3">Favoritos</h1>
    <hr />
    <div class="row">
    <asp:GridView ID="dgvFavoritos" DataKeyNames="Id" runat="server"
        CssClass="table table-striped" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvFavoritos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" HtmlEncode="false" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Selec." />
        </Columns>
    </asp:GridView>
    <asp:Label Text="" runat="server" ID="lblFavoritos" />
</div>
</asp:Content>
