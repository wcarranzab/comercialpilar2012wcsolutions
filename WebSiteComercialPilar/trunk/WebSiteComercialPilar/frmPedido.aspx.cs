using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebSiteComercialPilar
{
    public partial class frmPedido : System.Web.UI.Page
    {
        #region "Propiedades"
        private string codigoProd;
        private string codigoCate;
        #endregion

        #region "Funciones"
        private void cargarLoad()
        {
            lblCodigo.Text = Request.Cookies["busqueda"].Values["codigo"];
            codigoCate = Request.Cookies["busqueda"].Values["codCate"];


            lblNombreProducto.Text = Request.Cookies["busqueda"].Values["descrip"];
            lblPrecio.Text = Request.Cookies["busqueda"].Values["precio"];
            lblStock.Text = Request.Cookies["busqueda"].Values["stock"];
            lblTipoPorducto.Text = Request.Cookies["busqueda"].Values["nomCate"];
            imgFoto.ImageUrl = "imagenes/productos/" + lblCodigo.Text + ".jpg";
        }

        private void limpiar()
        {
            lblNombreProducto.Text = string.Empty;
            lblTipoPorducto.Text = string.Empty;
            lblPrecio.Text = string.Empty;
            lblStock.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            lblMonto.Text = string.Empty;
            txtFechaEntrega.Text = string.Empty;

        }

        #endregion

        Usuario usu = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            DetallePedido pedido =
                new DetallePedido((DataTable)Session["carrito"]);

            if (!Page.IsPostBack)
            {
                if (Request.Cookies["busqueda"] != null)
                {
                    cargarLoad();
                }
                string usuario = Session["usuarioNombre"].ToString();
                if (usuario.Equals(""))
                {
                    txtNombreCliente.ReadOnly = false;
                    txtApellidos.ReadOnly = false;
                    txtTelefono.ReadOnly = false;
                    txtDireccion.ReadOnly = false;
                }
                else
                {
                    txtNombreCliente.Text = usu.muestraDatosUsuario(usuario).Rows[0][0].ToString();
                    txtApellidos.Text = usu.muestraDatosUsuario(usuario).Rows[0][1].ToString();
                    txtTelefono.Text = usu.muestraDatosUsuario(usuario).Rows[0][2].ToString();
                    txtDireccion.Text = usu.muestraDatosUsuario(usuario).Rows[0][3].ToString();
                    //lblCodigo.Text = usu.muestraDatosUsuario(usuario).Rows[0][4].ToString();
                    txtNombreCliente.ReadOnly = true;
                    txtApellidos.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    txtDireccion.ReadOnly = true;
                }
                GridView1.DataSource = pedido.getRegistros;
                GridView1.DataBind();

            }
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarProducto.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            DetallePedido pedido =
                new DetallePedido((DataTable)Session["carrito"]);
            int nroPed = 100;
            string codProd = Request.Cookies["busqueda"].Values["codigo"];
            string nroKardex = "10";
            Int16 cantidad = Convert.ToInt16(txtCantidad.Text);
            double precio = Convert.ToDouble(lblPrecio.Text);
            double descuento;
            if (cantidad >= 10)
            {
                descuento = Math.Round(Convert.ToDouble(Convert.ToInt32(precio) * 0.1));
            }
            else
                descuento = Math.Round(Convert.ToDouble(Convert.ToInt32(precio) * 0.05));

            if (txtCantidad.Text == "")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('Ingrese la cantidad a Agregar');</script>");
            }
            else if (Convert.ToInt16(lblStock.Text) < Convert.ToInt16(txtCantidad.Text))
            {

                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('La cantidad no puede ser mayor que el stock');</script>");
            }

            else
            {
                string mensaje = pedido.AgregarDetalle(nroPed, Convert.ToInt16(codProd), nroKardex, cantidad, descuento, precio);
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('" + mensaje + "');</script>");
            }

            Session["carrito"] = pedido.getRegistros;

            GridView1.DataSource = pedido.getRegistros;
            GridView1.DataBind();
            lblMonto.Text = pedido.importeTotal().ToString();
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            DetallePedido pedido =
                new DetallePedido((DataTable)Session["carrito"]);

            DataHojaPedido hojaPedido = new DataHojaPedido();
            hojaPedido.CodCli = Session["usuarioNombre"].ToString();
            hojaPedido.CodVend = "rtapara";
            hojaPedido.TipoComprobante = cbTipoComprobante.Text;
            hojaPedido.FecPedido = DateTime.Now;

            hojaPedido.FormaPago = cbFormaPago.Text;
            hojaPedido.TipoTarjeta = cbTipoTarjeta.Text;
            hojaPedido.Estado = "Pendiente";
            hojaPedido.CodPais = "001";
            hojaPedido.CodDept = "P001";
            hojaPedido.CodProv = "PR01";
            hojaPedido.CodDis = "PD02";

            if (cbTipoEmtrega.Text == "Delivery")
            {
                hojaPedido.FecEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            }
            else
            {
                hojaPedido.FecEntrega = DateTime.Now;
            }
            if (cbFormaPago.Text == "")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('Seleccione la forma de pago');</script>");
            }
            else if (cbTipoComprobante.Text == "")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('Seleccione el tipo de comprobante');</script>");
            }
            else if (cbTipoEmtrega.Text == "")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('Seleccione el tipo de entrega');</script>");
            }
            else if (cbTipoTarjeta.Text == "")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('Seleccione el tipo de tarjeta');</script>");
            }
            else
            {
                string mensaje = pedido.GrabarPedido(hojaPedido);
                Producto pro = new Producto();
                pro.actualizar_stock(Convert.ToInt16(lblCodigo.Text), Convert.ToInt16(txtCantidad.Text));

                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('" + mensaje + "');</script>");
            }

        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            DetallePedido pedido =
                new DetallePedido((DataTable)Session["carrito"]);

            pedido.Elimina();

            if (Request.Cookies["busqueda"] != null)
            {
                HttpCookie myCookie = new HttpCookie("busqueda");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            Response.Redirect("PrincipalCliente.aspx");
        }
        protected void bntPagar_Click(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["carrito"];
            DataRow dr = dt.Rows[e.RowIndex];
            dt.Rows.Remove(dr);
            GridView1.EditIndex = -1;
            GridView1.DataBind();

        }
        protected void cbTipoEmtrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoEmtrega.Text == "Directo")
            {
                txtFechaEntrega_CalendarExtender.Enabled = false;
                txtFechaEntrega.Text = Convert.ToString(DateTime.Now);
                txtFechaEntrega.ReadOnly = false;

            }
            else
            {
                txtFechaEntrega.ReadOnly = false;
                txtFechaEntrega_CalendarExtender.Enabled = true;
            }
        }

    }
}