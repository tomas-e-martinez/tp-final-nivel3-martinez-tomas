using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using Microsoft.Ajax.Utilities;
using System.Text.RegularExpressions;

namespace presentacion
{
    public partial class ArticuloDetalle : System.Web.UI.Page
    {
        private void setearBotonFav()
        {
            if (Session["usuario"] != null)
            {
                int idArticulo = int.Parse(Request.QueryString["id"]);
                int idUser = ((Usuario)Session["usuario"]).Id;
                FavoritoNegocio negocio = new FavoritoNegocio();
                if(negocio.favoritoExiste(idArticulo, idUser))
                {
                    btnDesmarcarFav.Visible = true;
                    btnMarcarFav.Visible = false;
                }
                else
                {
                    btnMarcarFav.Visible = true;
                    btnDesmarcarFav.Visible = false;
                }

            }
            else
            {
                btnMarcarFav.Visible = true;
                btnDesmarcarFav.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["id"] == null && (Session["usuario"] == null || ((Usuario)Session["usuario"]).Admin == false))
                    {
                        Response.Redirect("Default.aspx", false);
                        return;
                    }
                    if(Session["usuario"] == null || ((Usuario)Session["usuario"]).Admin == false)
                    {
                        txtCodigo.Enabled = false;
                        txtNombre.Enabled = false;
                        txtDescripcion.Enabled = false;
                        txtUrlImagen.Enabled = false;
                        txtPrecio.Enabled = false;
                        ddlCategoria.Enabled = false;
                        ddlMarca.Enabled = false;
                    }

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
                        setearBotonFav();
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
                        btnMarcarFav.Visible = false;
                        btnDesmarcarFav.Visible = false;
                        btnModificar.Visible = false;
                        btnEliminar.Visible = false;
                        btnMarcarFav.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw ex;
                }
            }
        }

        private bool validarFormulario()
        {
            if (txtCodigo.Text.IsNullOrWhiteSpace() || txtNombre.Text.IsNullOrWhiteSpace() || txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblMensaje.Text = "Debe completar los campos de 'Código', 'Nombre' y 'Precio'";
                lblMensaje.CssClass = "text-danger";
                return false ;
            }

            if (txtCodigo.Text.Length > 50 || txtNombre.Text.Length > 50 ||
                    txtDescripcion.Text.Length > 150 || txtUrlImagen.Text.Length > 1000 ||
                    txtPrecio.Text.Length > 20)
            {
                lblMensaje.Text = "Uno o más campos exceden el límite de caracteres permitidos";
                lblMensaje.CssClass = "text-danger";
                return false;
            }

            if(!Regex.IsMatch(txtPrecio.Text, @"^\d{1,15}(\.\d{1,4})?$"))
            {
                lblMensaje.Text = "El precio ingresado no es válido, debe ser un número positivo con hasta 4 decimales";
                lblMensaje.CssClass = "text-danger";
                return false;
            }


            return true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarFormulario())
                    return;

                Articulo art = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                if (!negocio.codigoDisponible(txtCodigo.Text))
                {
                    lblMensaje.Text = "Ya existe un artículo con el código ingresado";
                    lblMensaje.CssClass = "text-danger";
                    return;
                }

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
                lblMensaje.Text = "Artículo agregado correctamente";
                lblMensaje.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarFormulario())
                    return;

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
                Session.Add("error", ex);
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
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnMarcarFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                    Response.Redirect("LogIn.aspx");

                FavoritoNegocio negocio = new FavoritoNegocio();
                int idArticulo = int.Parse(Request.QueryString["id"]);
                int idUser = ((Usuario)Session["usuario"]).Id;

                negocio.agregarFavorito(idArticulo, idUser);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
            finally
            {
                setearBotonFav();
            }
        }

        protected void btnDesmarcarFav_Click(object sender, EventArgs e)
        {
            try
            {
                FavoritoNegocio negocio = new FavoritoNegocio();
                int idArticulo = int.Parse(Request.QueryString["id"]);
                int idUser = ((Usuario)Session["usuario"]).Id;

                negocio.eliminarFavorito(idArticulo, idUser);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
            finally
            {
                setearBotonFav();
            }
        }
    }
}