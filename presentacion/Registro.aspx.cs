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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtEmail.Text.IsNullOrWhiteSpace() ||
                    txtNombre.Text.IsNullOrWhiteSpace() ||
                    txtApellido.Text.IsNullOrWhiteSpace() ||
                    txtPass.Text.IsNullOrWhiteSpace() ||
                    txtConfirmarPass.Text.IsNullOrWhiteSpace())
                {
                    lblError.Text = "Debe completar todos los campos";
                    return;
                }

                if(txtPass.Text != txtConfirmarPass.Text)
                {
                    lblError.Text = "Las contraseñas no coinciden";
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();
                if (!negocio.EmailDisponible(txtEmail.Text))
                {
                    lblError.Text = "Ya existe una cuenta con ese email";
                    return;
                }

                Usuario user = new Usuario();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                user.Id = negocio.Registrar(user);
                Session.Add("usuario", user);
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}