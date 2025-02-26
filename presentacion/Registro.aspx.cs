using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System.Text.RegularExpressions;

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

                if (txtEmail.Text.Length > 100 || txtPass.Text.Length > 20 ||
                    txtApellido.Text.Length > 50 || txtNombre.Text.Length > 50 ||
                    txtConfirmarPass.Text.Length > 20)
                {
                    lblError.Text = "Uno o más campos exceden el límite de caracteres permitidos";
                    return;
                }

                //if(!Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                //{
                //    lblError.Text = "El email ingresado no es válido";
                //    return;
                //}

                //if (txtPass.Text.Length < 6)
                //{
                //    lblError.Text = "La contraseña debe tener al menos 6 caracteres";
                //    return;
                //}

                if (txtEmail.Text.Contains(" ") || txtPass.Text.Contains(" "))
                {
                    lblError.Text = "El email y la contraseña no pueden contener espacios";
                    return;
                }

                if (txtPass.Text != txtConfirmarPass.Text)
                {
                    lblError.Text = "Las contraseñas no coinciden";
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();
                if (!negocio.emailDisponible(txtEmail.Text))
                {
                    lblError.Text = "Ya existe una cuenta con ese email";
                    return;
                }

                Usuario user = new Usuario();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                user.Id = negocio.registrar(user);
                Session.Add("usuario", user);
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}