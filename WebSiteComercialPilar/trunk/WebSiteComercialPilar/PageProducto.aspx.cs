using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSiteComercialPilar
{
    public partial class PageProducto : System.Web.UI.Page
    {
        private Producto p = new Producto();
        String usu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                usu = Session["usuarioNombre"].ToString();
                cboCategoria.DataSource = p.listarCate();
                cboCategoria.DataTextField = "NombreCategoria";
                cboCategoria.DataValueField = "IdCategoria";
                cboCategoria.DataBind();

                GridView1.DataSource = p.listarProd();
                GridView1.DataBind();
            }

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            usu = Session["usuarioNombre"].ToString();

            DataProducto dp = new DataProducto();
            dp.Codigo = p.autogenera();
            dp.Descrip = txtNombre.Text;
            dp.Precio = double.Parse(txtPrecio.Text);
            dp.Stock = int.Parse(txtStock.Text);
            dp.Cod_Emple = usu;
            dp.Cod_Cate = int.Parse(cboCategoria.SelectedValue);

            //ejecutamos el metodo
            string msg = p.agregar(dp);

            //alerta que muestre el mensaje
            string script = @"<script type='text/javascript'> alert('{0}'); </script>";
            script = string.Format(script, msg);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            //visualizamos la actualizacion
            GridView1.DataSource = p.listarProd();
            GridView1.DataBind();

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            usu = Session["usuarioNombre"].ToString();
            DataProducto dp = new DataProducto();
            dp.Codigo = int.Parse(txtCodigo.Text);
            dp.Descrip = txtNombre.Text;
            dp.Precio = double.Parse(txtPrecio.Text);
            dp.Stock = int.Parse(txtStock.Text);
            dp.Cod_Emple = usu;
            dp.Cod_Cate = int.Parse(cboCategoria.SelectedValue);

            //ejecutamos el metodo
            string msg = p.actualizar(dp);

            //alerta que muestre el mensaje
            string script = @"<script type='text/javascript'> alert('{0}'); </script>";
            script = string.Format(script, msg);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            //visualizamos la actualizacion
            GridView1.DataSource = p.listarProd();
            GridView1.DataBind();

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            usu = Session["usuarioNombre"].ToString();

            DataProducto dp = new DataProducto();
            dp.Codigo = int.Parse(txtCodigo.Text);

            //ejecutamos el metodo
            string msg = p.eliminar(dp);

            //alerta que muestre el mensaje
            string script = @"<script type='text/javascript'> alert('{0}'); </script>";
            script = string.Format(script, msg);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            //visualizamos la actualizacion
            GridView1.DataSource = p.listarProd();
            GridView1.DataBind();

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //al seleccionar enviar los datos del Producto por Cookie
            Int32 f = GridView1.SelectedIndex;

            txtCodigo.Text = GridView1.Rows[f].Cells[1].Text;
            txtNombre.Text = GridView1.Rows[f].Cells[2].Text;
            string cate = GridView1.Rows[f].Cells[3].Text;
            cboCategoria.Text = p.buscaCate(cate).Rows[0].ItemArray.ElementAt(0).ToString();

            txtPrecio.Text = GridView1.Rows[f].Cells[4].Text;
            txtStock.Text = GridView1.Rows[f].Cells[5].Text;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

    }
}