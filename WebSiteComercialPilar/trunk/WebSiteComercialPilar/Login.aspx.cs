using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class Login : System.Web.UI.Page
    {
        private Usuario usu = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            int res1 = usu.buscaUsuario(txtUsuario.Text);
            int res2 = usu.validaUsuario(txtUsuario.Text, txtClave.Text);
            int res3 = usu.validaIngreso(txtUsuario.Text);
            string msg = "";

            if (res1 < 1)
            {
                msg = "El Usuario no existe";
                string script = @"<script type='text/javascript'> alert('{0}'); </script>";
                script = string.Format(script, msg);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {


                if (res1 == 1 && res2 == 1 && res3 >= 1)
                {
                    Session["usuarioNombre"] = txtUsuario.Text;
                    Response.Redirect("PrincipalCliente.aspx?usuario=" + txtUsuario.Text);

                }
                else
                {
                    if (res1 == 1 && res2 == 1 && res3 < 1)
                    {
                        Session["usuarioNombre"] = txtUsuario.Text;
                        Response.Redirect("PrincipalEmpleado.aspx?usuario=" + txtUsuario.Text);

                    }
                    else
                    {
                        msg = "Contraseña Incorrecta";
                        string script = @"<script type='text/javascript'> alert('{0}'); </script>";
                        script = string.Format(script, msg);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }

                }
            }
        }

    }
}