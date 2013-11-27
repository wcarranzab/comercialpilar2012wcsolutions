using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class SalidaCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DetallePedido p = new DetallePedido();
                GridView1.DataSource = p.listarHojaPedidos();
                GridView1.DataBind();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //al seleccionar enviar los datos del Producto por Cookie
            Int32 f = GridView1.SelectedIndex;
            HttpCookie datos = new HttpCookie("datos");
            datos.Values["codigo"] = GridView1.Rows[f].Cells[1].Text;
            datos.Values["cliente"] = GridView1.Rows[f].Cells[2].Text;
            datos.Values["fechaPedido"] = GridView1.Rows[f].Cells[3].Text;
            datos.Values["fechaEntrega"] = GridView1.Rows[f].Cells[4].Text;
            datos.Values["estado"] = GridView1.Rows[f].Cells[5].Text;

            Response.Cookies.Add(datos);
            Response.Redirect("OrdenSalida.aspx");
        }

    }
}