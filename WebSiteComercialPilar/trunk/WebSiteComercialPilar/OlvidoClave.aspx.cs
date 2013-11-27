using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class OlvidoClave : System.Web.UI.Page
    {
        private Usuario usu = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnComprobar_Click(object sender, EventArgs e)
        {
            string usua = txtUsuario.Text;
            DateTime fecha = DateTime.Parse(txtFecha.Text);

            int res = usu.validaUsuFecha(usua, fecha);
            String msg = "";

            if (res == 1)
            {
                Response.Redirect("ActualizarClave.aspx?usu=" + usua);
            }
            else
            {
                msg = "Los Datos no coinciden";
                string script = @"<script type='text/javascript'> alert('{0}'); </script>";
                script = string.Format(script, msg);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

    }
}