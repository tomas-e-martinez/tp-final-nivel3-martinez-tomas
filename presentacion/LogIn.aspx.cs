using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using negocio;
using dominio;

namespace presentacion
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario user = new Usuario();

                if (txtEmail.Text.IsNullOrWhiteSpace() || txtPass.Text.IsNullOrWhiteSpace())
                {
                    lblError.Text = "Debe completar todos los campos";
                    return;
                }

                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;

                if (negocio.Loguear(user))
                {
                    Session.Add("usuario", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                    return;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}