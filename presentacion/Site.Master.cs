using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacion
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];

                    if (string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                        imgPerfil.ImageUrl = "https://media.istockphoto.com/id/1223671392/vector/default-profile-picture-avatar-photo-placeholder-vector-illustration.jpg?s=612x612&w=0&k=20&c=s0aTdmT5aU6b8ot7VKm11DeID6NctRCpB755rA1BIP0=";
                    else
                        imgPerfil.ImageUrl = usuario.UrlImagenPerfil;

                    if (!string.IsNullOrEmpty(usuario.Nombre))
                    {
                        lblNombreNav.Text = usuario.Nombre;
                        if (!string.IsNullOrEmpty(usuario.Apellido))
                            lblNombreNav.Text += $" {usuario.Apellido}";
                    }
                }
                else
                {
                    imgPerfil.ImageUrl = "https://media.istockphoto.com/id/1223671392/vector/default-profile-picture-avatar-photo-placeholder-vector-illustration.jpg?s=612x612&w=0&k=20&c=s0aTdmT5aU6b8ot7VKm11DeID6NctRCpB755rA1BIP0=";
                }
            }
        }

        protected void btnSalirNav_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}