using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

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
    }
}