using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class frmPagar : System.Web.UI.Page
    {
        DetallePedido dp = new DetallePedido();
        Usuario usu = new Usuario();
        Comprobante com = new Comprobante();

        private int codPed;
        private string tipoCompro;
        private string idpais;
        private string idDept;
        private string idProv;
        private string idDis;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string usuario = Session["usuarioNombre"].ToString();
                codPed = dp.MaxPedido_pendiente_usu(usuario);

                lblNombre.Text = usu.muestraDatosPago(usuario, codPed).Rows[0][0].ToString();
                lblTipoComprobante.Text = usu.muestraDatosPago(usuario, codPed).Rows[0][1].ToString();
                lblMonto.Text = usu.muestraDatosPago(usuario, codPed).Rows[0][2].ToString();
                tipoCompro = usu.muestraDatosPago(usuario, codPed).Rows[0][4].ToString();
                idpais = usu.muestraDatosPago(usuario, codPed).Rows[0][5].ToString();
                idDept = usu.muestraDatosPago(usuario, codPed).Rows[0][6].ToString();
                idProv = usu.muestraDatosPago(usuario, codPed).Rows[0][7].ToString();
                idDis = usu.muestraDatosPago(usuario, codPed).Rows[0][8].ToString();
                lblFechaPago.Text = Convert.ToString(DateTime.Now.Date);
            }


        }
        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            string usuario = Session["usuarioNombre"].ToString();
            int valida_tarjeta = com.valida_nro_tarjeta(txtNroTarjeta.Text, usuario, txtCodigoSeg.Text);

            if (valida_tarjeta == 0)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('El nro de Tarjeta no es valido');</script>");
            }
            else
            {
                codPed = dp.MaxPedido_pendiente_usu(usuario);
                tipoCompro = usu.muestraDatosPago(usuario, codPed).Rows[0][4].ToString();
                idpais = usu.muestraDatosPago(usuario, codPed).Rows[0][5].ToString();
                idDept = usu.muestraDatosPago(usuario, codPed).Rows[0][6].ToString();
                idProv = usu.muestraDatosPago(usuario, codPed).Rows[0][7].ToString();
                idDis = usu.muestraDatosPago(usuario, codPed).Rows[0][8].ToString();


                DataComprobante comprobante = new DataComprobante();
                string nroCom = Convert.ToString(com.Autogenerado());
                comprobante.NroCompro = nroCom;
                comprobante.Fecha = Convert.ToDateTime(lblFechaPago.Text);
                comprobante.CodUsu = usuario;
                comprobante.NroPed = codPed;
                comprobante.Tipo = tipoCompro;
                comprobante.Estado = "Emitido";
                comprobante.idPais = idpais;
                comprobante.CodDept = idDept;
                comprobante.IdProv = idProv;
                comprobante.CodDis = idDis;

                dp.actualizar_pedido(codPed);
                string mensaje = com.insertarComprobante(comprobante);
                if (tipoCompro.Equals("Boleta"))
                    com.insertar_boleta(nroCom);
                else
                    com.inserta_factura(nroCom);
                ClientScript.RegisterStartupScript(typeof(Page), "Mensaje",
                "<script language=JavaScript>alert('" + mensaje + "');</script>");
            }
        }

    }
}