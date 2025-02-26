<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="presentacion.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mb-3">Listado de Artículos</h1>
    <hr />

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" for="txtFiltro" CssClass="" />
                <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkFiltroAvanzado"
                    CssClass="" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>

    <%if (FiltroAvanzado) { %>
    <div class="row">
        <div class="col-4 mb-3">
            <asp:Label Text="Campo" for="ddlCampo" runat="server" />
            <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-select" 
                OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Precio" />
                <asp:ListItem Text="Nombre" />
                <asp:ListItem Text="Marca" />
            </asp:DropDownList>
        </div>
        <div class="col-4 mb-3">
            <asp:Label Text="Criterio" for="ddlCriterio" runat="server" />
            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-select">
            </asp:DropDownList>
        </div>
        <div class="col-4 mb-3">
            <asp:Label Text="Filtro" for="txtFiltroAvanzado" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="mb-3">
            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
        </div>
    </div>

    <% } %>

    <div class="row">
        <asp:GridView ID="dgvArticulos" DataKeyNames="Id" runat="server"
            CssClass="table table-striped" AutoGenerateColumns="false"
            OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
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
