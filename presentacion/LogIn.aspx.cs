using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using negocio;
using dominio;
using System.Text.RegularExpressions;

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

                if (txtEmail.Text.Length > 100 || txtPass.Text.Length > 20)
                {
                    lblError.Text = "El email o la contraseña exceden el límite de caracteres permitidos";
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


                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;

                if (negocio.loguear(user))
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
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}