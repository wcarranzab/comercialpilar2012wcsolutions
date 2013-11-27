using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class RegistroUsu : System.Web.UI.Page
    {
        private Usuario usu = new Usuario();
        private Cliente cli = new Cliente();
        private Paises p = new Paises();
        private Departamento d = new Departamento();
        private Provincia provi = new Provincia();
        private Distrito dis = new Distrito();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cboPaises.DataSource = p.listado();
                cboPaises.DataTextField = "nombrepais";
                cboPaises.DataValueField = "idpais";
                cboPaises.DataBind();


            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //instancia de DataUsuario
            DataUsuario du = new DataUsuario();
            du.CodUsu = txtUsuario.Text;
            du.NomUsu = txtNombre.Text;
            du.ApePat = txtApePat.Text;
            du.ApeMat = txtApeMat.Text;
            du.FechaNac = DateTime.Parse(txtFechaNac.Text);
            du.Domicilio = txtDomi.Text;
            du.Telefono = txtFono.Text;
            du.DNI = txtDni.Text;
            du.TipoUsu = "Cliente";
            du.IdPais = cboPaises.SelectedValue;
            du.CodDpto = cboDpto.SelectedValue;
            du.CodProv = cboProv.SelectedValue;
            du.CodDis = cboDist.SelectedValue;
            du.Clave = txtClave.Text;

            //instancia de DataCliente
            DataCliente dc = new DataCliente();
            dc.CodUsu_Cli = txtUsuario.Text;
            dc.RUC = txtRUC.Text;


            //ejecutamos el metodo
            string msg1 = usu.agregar(du);
            string msg2 = cli.agregar(dc);
            DataTarjeta tar = new DataTarjeta();
            tar.NroTarjeta = txtNroTarjeta.Text;
            tar.Descrip = "Debito";
            tar.CodTipo = "100";
            tar.CodUsu = txtUsuario.Text;
            tar.CodSeg = txtCodSeguridad.Text;

            usu.agregarTarjeta(tar);

            //alerta que muestre el mensaje
            string script = @"<script type='text/javascript'> alert('{0}'); </script>";
            script = string.Format(script, msg2);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            Session["usuarioNombre"] = txtUsuario.Text;
            Response.Redirect("PrincipalCliente.aspx?usuario=" + du.CodUsu);
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Novedades.aspx");

        }

        protected void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pais = cboPaises.SelectedValue;

            cboDpto.DataSource = d.listado(pais);
            cboDpto.DataTextField = "nomDpto";
            cboDpto.DataValueField = "codDpto";
            cboDpto.DataBind();
        }
        protected void cboDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pais = cboPaises.SelectedValue;
            string dpto = cboDpto.SelectedValue;

            cboProv.DataSource = provi.listado(pais, dpto);
            cboProv.DataTextField = "nomProv";
            cboProv.DataValueField = "codProv";
            cboProv.DataBind();
        }
        protected void cboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pais = cboPaises.SelectedValue;
            string dpto = cboDpto.SelectedValue;
            string prov = cboProv.SelectedValue;

            cboDist.DataSource = dis.listado(pais, dpto, prov);
            cboDist.DataTextField = "nomDis";
            cboDist.DataValueField = "codDis";
            cboDist.DataBind();
        }

    }
}