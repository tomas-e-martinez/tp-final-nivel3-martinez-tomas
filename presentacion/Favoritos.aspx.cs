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
    public partial class Favoritos : System.Web.UI.Page
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
                ArticuloNegocio negocio = new ArticuloNegocio();
                int idUser = ((Usuario)Session["usuario"]).Id;

                List<Articulo> listaFavoritos = negocio.listarFavoritosUser(idUser);
                if(listaFavoritos.Count > 0)
                {
                    dgvFavoritos.DataSource = listaFavoritos;
                    dgvFavoritos.DataBind();
                }
                else
                {
                    lblFavoritos.Text = "No tienes artículos favoritos.";
                }
            }
        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvFavoritos.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticuloDetalle.aspx?id=" + id);
        }
    }
}