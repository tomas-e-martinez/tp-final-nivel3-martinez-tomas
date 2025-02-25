<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="presentacion.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mb-3">Listado de Artículos</h1>
    <hr />

    <div class="row">
        <asp:GridView ID="dgvArticulos" DataKeyNames="Id" runat="server" 
            CssClass="table table-striped" AutoGenerateColumns="false" 
            OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" HtmlEncode="false" />
                <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Editar" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="row mb-3">
        <div class="col-12">
        <a class="btn btn-success" href="ArticuloDetalle.aspx">Agregar artículo</a>

        </div>
    </div>

</asp:Content>
