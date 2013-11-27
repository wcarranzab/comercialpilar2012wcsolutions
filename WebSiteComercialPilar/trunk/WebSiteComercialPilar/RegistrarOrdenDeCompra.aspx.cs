using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class RegistrarOrdenDeCompra : System.Web.UI.Page
    {
        OrdenCompra ord = new OrdenCompra();
        Proveedor prov = new Proveedor();
        Comprobante comp = new Comprobante();

        protected void Page_Load(object sender, EventArgs e)
        {
            cboProveedor.DataSource = prov.listarProveedores();
            cboProveedor.DataTextField = "NombreCia";
            cboProveedor.DataValueField = "codProveedor";
            cboProveedor.DataBind();


        }
        protected void btnBuscarComprobante_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = comp.consulta(txtCodigoComprobante.Text);
            GridView1.DataBind();

        }

        protected void btnMontoTotal_Click(object sender, EventArgs e)
        {

        }
        protected void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            DateTime f1;
            Boolean v1;
            v1 = DateTime.TryParse(txtFechaComprobante.Text, out f1);
            if (v1 == false)
            {
                lblMensaje.Text = "Fecha 1 invalido";
                return;
            }

            DateTime f2;
            Boolean v2;
            v2 = DateTime.TryParse(txtFechaOrden.Text, out f2);
            if (v2 == false)
            {
                lblMensaje.Text = "Fecha 1 invalido";
                return;
            }

            Double d1;
            d1 = int.Parse(txtMontoTotal.Text);

            ord.agregarOrden(txtCodOrden.Text, txtCodigoComprobante.Text, f1, d1, f2, cboProveedor.SelectedValue);


        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFechaComprobante.Text = Server.HtmlDecode(GridView1.SelectedRow.Cells[2].Text);
        }

    }
}