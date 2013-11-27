using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class ActualizarClave : System.Web.UI.Page
    {
        private Usuario usu = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Request.QueryString["usu"];
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string msg = "";

            if (txtClave.Text.Equals(txtClave1.Text))
            {
                string msg1 = usu.actualizarClave(lblUsuario.Text, txtClave.Text); ;

                //alerta que muestre el mensaje
                string script = @"<script type='text/javascript'> alert('{0}'); </script>";
                script = string.Format(script, msg1);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                Response.Redirect("PrincipalCliente.aspx");

            }
            else
            {
                msg = "Las Contraseñas no coinciden";
                string script = @"<script type='text/javascript'> alert('{0}'); </script>";
                script = string.Format(script, msg);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }

        }

    }
}