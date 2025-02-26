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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar());

                List<Articulo> lista = ((List<Articulo>)Session["listaArticulos"]);


                repRepetidor.DataSource = lista;
                repRepetidor.DataBind();
            }
        }

        protected void btnAgregarFav_Click(object sender, CommandEventArgs e)
        {
            if (Session["usuario"] == null)
                Response.Redirect("LogIn.aspx");

            FavoritoNegocio negocio = new FavoritoNegocio();
            int idArticulo = int.Parse(e.CommandArgument.ToString());
            int idUser = ((Usuario)Session["usuario"]).Id;

            negocio.agregarFavorito(idArticulo, idUser);

            ((Button)sender).CssClass = "btn btn-dark";
            ((Button)sender).Text = "Agregado a favoritos";
            ((Button)sender).Enabled = false;
        }
    }
}