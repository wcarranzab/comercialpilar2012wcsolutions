using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de DetallePedido
/// </summary>
public class DetallePedido
{
    DataTable rows;
    Conexion cn = new Conexion();
	public DetallePedido()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DetallePedido(DataTable tabla)
    {
        this.rows = tabla;
    }

    public DataTable getRegistros{
        get { return rows; }
    }

    public string AgregarDetalle(int nroPed, int codProd,
                                 string nroKardex,double cantidad, 
                                 double descuento, double precio)
    {
       string msg = "";
        DataRow fila = rows.Rows.Find(codProd);

        if (fila == null)
        {
            fila = rows.NewRow();
            fila[0] = nroPed;
            fila[1] = codProd;
            fila[2] = nroKardex;
            fila[3] = cantidad;
            fila[4] = descuento;
            fila[5] = precio;
            rows.Rows.Add(fila);
            msg = "Producto agregado";
        }
        else {
            msg = "Producto ya ha sido registrado";
        }
        return msg;
    }

    public void Elimina()
    {

        rows.Rows.Clear();

    }

    public double importeTotal()
    {
        double t = 0;
        if (rows.Rows.Count > 0)
            t = (Double)rows.Compute("Sum(total)", "");

        return t;
    }

    private int Autogenerado()
    {
        int x = 0;
        SqlCommand cmd = new SqlCommand(
            "usp_autogenera_hoja_pedido", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        cn.getCN.Open();

         x = (Int32) cmd.ExecuteScalar();
        cn.getCN.Close();

        if (x == 0)
            return 1;
        else
        {
            x += 1;
            return x;
        }
    }

    public int MaxPedido_pendiente_usu(string usu) {

        int x;
        SqlCommand cmd = new SqlCommand(
            "usp_max_pedido", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = usu;

        cn.getCN.Open();

        x = (Int32)cmd.ExecuteScalar();
        cn.getCN.Close();

        return x;
    }

    public string GrabarPedido(DataHojaPedido hojaPedido)
    {

        int x = Autogenerado();
        string msg;

        cn.getCN.Open();
        SqlTransaction tr = cn.getCN.BeginTransaction(IsolationLevel.Serializable);
        SqlCommand cmd = new SqlCommand(
            "usp_insertar_hoja_pedido", cn.getCN, tr);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@cod", SqlDbType.Int).Value = x;
        cmd.Parameters.Add("@cod_cli", SqlDbType.Char).Value = hojaPedido.CodCli;
        cmd.Parameters.Add("@cod_ven", SqlDbType.Char).Value = hojaPedido.CodVend;
        cmd.Parameters.Add("@tipoCompro", SqlDbType.VarChar).Value = hojaPedido.TipoComprobante;
        cmd.Parameters.Add("@fechaPedido", SqlDbType.DateTime).Value = hojaPedido.FecPedido;
        cmd.Parameters.Add("@fechaEntrega", SqlDbType.DateTime).Value = hojaPedido.FecEntrega;
        cmd.Parameters.Add("@formaPago", SqlDbType.VarChar).Value = hojaPedido.FormaPago;
        cmd.Parameters.Add("@tipoTarjeta", SqlDbType.VarChar).Value = hojaPedido.TipoTarjeta;
        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = hojaPedido.Estado;
        cmd.Parameters.Add("@idPais", SqlDbType.Char).Value = hojaPedido.CodPais;
        cmd.Parameters.Add("@codDpto", SqlDbType.Char).Value = hojaPedido.CodDept;
        cmd.Parameters.Add("@codProv", SqlDbType.Char).Value = hojaPedido.CodProv;
        cmd.Parameters.Add("@codDis", SqlDbType.Char).Value = hojaPedido.CodDis;

        try
        {
            cmd.ExecuteNonQuery();

            foreach (DataRow fila in rows.Rows)
            {
                cmd = new SqlCommand(
                    "usp_insertar_detalle_ped", cn.getCN, tr);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nroPed", SqlDbType.Int).Value = x;
                cmd.Parameters.Add("@codProd", SqlDbType.Int).Value = fila["codProd"];
                cmd.Parameters.Add("@nroKardex", SqlDbType.VarChar).Value = fila["nroKardex"];
                cmd.Parameters.Add("@importe", SqlDbType.Money).Value = fila["cantidad"];
                cmd.Parameters.Add("@cant", SqlDbType.Int).Value = Convert.ToInt16(fila["descuento"].ToString());
                cmd.Parameters.Add("@desc", SqlDbType.Money).Value = fila["precio"];
                cmd.Parameters.Add("@preUni", SqlDbType.Money).Value = fila["importe"];
                cmd.Parameters.Add("@impTotal", SqlDbType.Money).Value = fila["total"];

                cmd.ExecuteNonQuery();
            }

            msg = "Pedido Registrado exitosamente";
            tr.Commit();//actualizar a la base de datos si esta Ok
        }
        catch (Exception ex)
        {
            msg = ex.Message;
            tr.Rollback();//deshacer el proceso
        }
        finally
        {
            cn.getCN.Close();
        }
        return msg;//el metodo retorna el mensaje
    }

    public void actualizar_pedido(int cod)
    {

        SqlCommand cmd = new SqlCommand("usp_actualizar_estado", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@cod", SqlDbType.Int).Value = cod;

        cn.getCN.Open();
        try
        {
            cmd.ExecuteNonQuery().ToString();

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            cn.getCN.Close();
        }
    }
	public DataTable listarHojaPedidos()
    {
        SqlDataAdapter da = new SqlDataAdapter
        ("select * from tb_HojaPedido where estadoPedido='Pagado'", cn.getCN);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
}