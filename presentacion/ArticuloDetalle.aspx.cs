using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace presentacion
{
    public partial class ArticuloDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    txtId.Enabled = false;

                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    List<Categoria> listaCategorias = negocioCategoria.listar();
                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    List<Marca> listaMarcas = negocioMarca.listar();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();


                    if (Request.QueryString["id"] != null)
                    {
                        btnAgregar.Visible = false;

                        int id = int.Parse(Request.QueryString["id"]);
                        txtId.Text = id.ToString();

                        List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];
                        Articulo seleccionado = listaArticulos.Find(x => x.Id == id);

                        txtCodigo.Text = seleccionado.Codigo;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtNombre.Text = seleccionado.Nombre;
                        txtPrecio.Text = seleccionado.Precio.ToString();
                        txtUrlImagen.Text = seleccionado.ImagenUrl;
                        txtUrlImagen_TextChanged(sender, e);
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    }
                    else
                    {
                        btnModificar.Visible = false;
                        btnEliminar.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo art = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                art.Codigo = txtCodigo.Text;
                art.Nombre = txtNombre.Text;
                art.Descripcion = txtDescripcion.Text;
                art.ImagenUrl = txtUrlImagen.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);

                art.Categoria = new Categoria();
                art.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                art.Marca = new Marca();
                art.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                negocio.agregar(art);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo art = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                art.Id = int.Parse(Request.QueryString["id"]);

                art.Descripcion = txtDescripcion.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);
                art.Nombre = txtNombre.Text;
                art.Codigo = txtCodigo.Text;
                art.ImagenUrl = txtUrlImagen.Text;

                art.Categoria = new Categoria();
                art.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                art.Marca = new Marca();
                art.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                negocio.modificar(art);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.eliminar(int.Parse(Request.QueryString["id"]));
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }
    }
}