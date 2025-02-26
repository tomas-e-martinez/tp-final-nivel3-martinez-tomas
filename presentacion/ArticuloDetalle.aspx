<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticuloDetalle.aspx.cs" Inherits="presentacion.ArticuloDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mb-3">Información del Artículo</h1>
    <hr />
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="ID" runat="server" for="txtId" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Código" runat="server" for="txtCodigo" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtCodigo" placeholder="S04T" CssClass="form-control" MaxLength="50" REQUIRED />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" runat="server" for="txtNombre" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtNombre" placeholder="Galaxy S12" CssClass="form-control" MaxLength="50" REQUIRED />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripción" runat="server" for="txtDescripcion" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtDescripcion" placeholder="Teléfono inteligente con pantalla de 5 pulgadas." CssClass="form-control" TextMode="MultiLine" Rows="2" MaxLength="150" />
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
                <asp:TextBox runat="server" ID="txtPrecio" placeholder="4250" CssClass="form-control" MaxLength="20" REQUIRED/>
            </div>
        </div>
        <div class="col-4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label Text="URL de Imagen" runat="server" for="txtUrlImagen" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtUrlImagen" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged"
                            placeholder="http://imagenes.com/celular" CssClass="form-control mb-3" MaxLength="1000" TextMode="Url" />
                        <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUwCJYSnbBLMEGWKfSnWRGC_34iCCKkxePpg&s" runat="server" ID="imgArticulo" Width="60%" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-12 mb-3">
            <asp:LinkButton Text="Volver" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click" />
            <%if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).Admin) { %>
            <asp:Button Text="Agregar" runat="server" CssClass="btn btn-success" ID="btnAgregar" OnClick="btnAgregar_Click"  />
            <asp:Button Text="Guardar cambios" runat="server" CssClass="btn btn-success" ID="btnModificar" OnClick="btnModificar_Click" />
            <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger"
                ID="btnEliminar" OnClick="btnEliminar_Click"
                OnClientClick="return confirm('¿Está seguro de que desea eliminar este artículo?');" />
            <% } %>
        </div>
        <div class="col-12 mb-3">
            <asp:Label runat="server" ID="lblMensaje" />
        </div>
    </div>
</asp:Content>
