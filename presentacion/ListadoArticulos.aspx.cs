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
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar());

                List<Articulo> lista = ((List<Articulo>)Session["listaArticulos"]);

                dgvArticulos.DataSource = lista;
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticuloDetalle.aspx?id=" + id);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 50)
                return;

            List<Articulo> listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            txtFiltro.Enabled = !chkFiltroAvanzado.Checked;
            if(FiltroAvanzado)
                ddlCampo_SelectedIndexChanged(sender, e);
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                txtFiltroAvanzado.TextMode = TextBoxMode.Number;
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                txtFiltroAvanzado.TextMode = TextBoxMode.SingleLine;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltroAvanzado.Text.Length > 50)
                    return;

                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaFiltrada = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(), 
                    ddlCriterio.SelectedItem.ToString(), 
                    txtFiltroAvanzado.Text);

                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}