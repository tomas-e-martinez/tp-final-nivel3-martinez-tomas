<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticuloDetalle.aspx.cs" Inherits="presentacion.ArticuloDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="ID" runat="server" for="txtId" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Código" runat="server" for="txtCodigo" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtCodigo" placeholder="S04T" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" runat="server" for="txtNombre" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtNombre" placeholder="Galaxy S12" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripción" runat="server" for="txtDescripcion" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtDescripcion" placeholder="Teléfono inteligente con pantalla de 5 pulgadas." CssClass="form-control" TextMode="MultiLine" Rows="2" />
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Categoría" runat="server" for="ddlCategoria" CssClass="form-label" />
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Marca" runat="server" for="ddlMarca" CssClass="form-label" />
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" runat="server" for="txtPrecio" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtPrecio" placeholder="$4250" CssClass="form-control" />
            </div>
        </div>
        <div class="col-4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label Text="URL de Imagen" runat="server" for="txtUrlImagen" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtUrlImagen" AutoPostBack="true"
                            placeholder="http://imagenes.com/celular" CssClass="form-control mb-3" />
                        <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUwCJYSnbBLMEGWKfSnWRGC_34iCCKkxePpg&s" runat="server" ID="imgArticulo" Width="60%" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:Button Text="Aceptar" runat="server" CssClass="btn btn-primary" ID="btnAceptar"  />
    <asp:Button Text="Modificar" runat="server" CssClass="btn btn-primary" ID="btnModificar" />
    <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" />
    <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger"
        ID="btnEliminar"
        OnClientClick="return confirm('¿Está seguro de que desea eliminar este artículo?');" />
</asp:Content>
