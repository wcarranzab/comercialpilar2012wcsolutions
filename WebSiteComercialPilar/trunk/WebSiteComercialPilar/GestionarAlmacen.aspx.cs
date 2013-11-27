using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class GestionarAlmacen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String usu = Session["usuarioNombre"].ToString();
        }

    }
}