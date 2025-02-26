using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Ajax.Utilities;
using negocio;

namespace presentacion
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }
            if (!IsPostBack)
            {
                try
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtUrlImagen.Text = usuario.UrlImagenPerfil;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = (Usuario)Session["usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.UrlImagenPerfil = txtUrlImagen.Text;

                if(txtNombre.Text.IsNullOrWhiteSpace() || txtApellido.Text.IsNullOrWhiteSpace())
                {
                    lblMensaje.Text = "Debe completar los campos marcados como obligatorios (*)";
                    lblMensaje.CssClass = "text-danger";
                    return;
                }

                if (txtNombre.Text.Length > 50 || txtApellido.Text.Length > 50 || txtUrlImagen.Text.Length > 500)
                {
                    lblMensaje.Text = "Uno de los campos excede el límite de caracteres permitidos";
                    lblMensaje.CssClass = "text-danger";
                    return;
                }

                negocio.modificar(user);
                lblMensaje.Text = "Perfil modificado correctamente";
                lblMensaje.CssClass = "text-success";
                
                ((Image)Master.FindControl("imgPerfil")).ImageUrl = user.UrlImagenPerfil;

                Label lblNombreNav = ((Label)Master.FindControl("lblNombreNav"));
                if (!user.Nombre.IsNullOrWhiteSpace())
                {
                    lblNombreNav.Text = user.Nombre;
                    if (!user.Apellido.IsNullOrWhiteSpace())
                        lblNombreNav.Text += $" {user.Apellido}";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}