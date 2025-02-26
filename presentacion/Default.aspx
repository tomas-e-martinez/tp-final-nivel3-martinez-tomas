<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .card-img-top {
            width: 100%;
            height: 200px;
            object-fit: contain;
        }
    </style>

    <h1 class="mb-3">Bienvenido/a</h1>
    <hr />

    <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top p-3" alt="..." onerror="this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9cSGzVkaZvJD5722MU5A-JJt_T5JMZzotcw&s'">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-title"><%#Eval("Categoria.Descripcion") + " - " + Eval("Marca.Descripcion") %></p>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <p class="card-text fw-bold">$<%#Eval("Precio", "{0:F2}") %></p>
                            <div class="d-flex justify-content-between">
                                <a href="ArticuloDetalle.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Detalles</a>
                                <asp:Button Text="Marcar favorito" runat="server" CssClass="btn btn-outline-dark" ID="btnAgregarFav" 
                                    OnCommand="btnAgregarFav_Click" CommandArgument='<%# Eval("Id") %>' />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
