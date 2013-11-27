using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebSiteComercialPilar
{
    public partial class frmBuscarProducto : System.Web.UI.Page
    {
        Producto prod = new Producto();

        #region "Funciones"

        public void listado()
        {
            DataList1.DataSource = prod.listadoProducto();
            DataList1.DataBind();
        }

        public void listadoPorFiltro(string filtro)
        {
            if (CheckBox1.Checked == true)
            {
                DataList1.DataSource = prod.listaFiltroConStock(filtro);
                DataList1.DataBind();
            }
            else
            {
                DataList1.DataSource = prod.listaFiltroSinStock(filtro);
                DataList1.DataBind();
            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listado();

            }

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            listadoPorFiltro(txtFiltro.Text);

        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPedido.aspx");
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {

            DataListItem it = (DataListItem)((Control)e.CommandSource).Parent;

            //capturo el codigo del it
            string cod = (it.FindControl("lblCodigo") as Label).Text;
            string descrip = (it.FindControl("lblDescripProd") as Label).Text;
            string precio = (it.FindControl("lblPrecio") as Label).Text;
            string stock = (it.FindControl("lblstock") as Label).Text;
            string nomCate = (it.FindControl("lblNombreCategoria") as Label).Text;
            string codCate = (it.FindControl("lblCodCate") as Label).Text;

            HttpCookie busqueda = new HttpCookie("busqueda");
            busqueda.Values["codigo"] = cod;
            busqueda.Values["descrip"] = descrip;
            busqueda.Values["precio"] = precio;
            busqueda.Values["stock"] = stock;
            busqueda.Values["nomCate"] = nomCate;
            busqueda.Values["codCate"] = codCate;

            busqueda.Expires = DateTime.Now.AddDays(1d);

            Response.Cookies.Add(busqueda);
            Response.Redirect("frmPedido.aspx");

        }

    }
}