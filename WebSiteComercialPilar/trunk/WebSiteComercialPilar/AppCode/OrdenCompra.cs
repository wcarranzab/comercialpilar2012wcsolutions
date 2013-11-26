using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de OrdenCompra
/// </summary>
public class OrdenCompra
{
    Conexion cn = new Conexion();


    public OrdenCompra()
    {

        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public void agregarOrden(String id, String idComp, DateTime fecha1, Double monto, DateTime fecha2, String idProv)
    {

        SqlCommand cmd = new SqlCommand("agregaOrden", cn.getCN);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@id", SqlDbType.Char).Value = id;
        cmd.Parameters.Add("@idComp", SqlDbType.Char).Value = idComp;
        cmd.Parameters.Add("@fechaCom", SqlDbType.DateTime).Value = fecha1;
        cmd.Parameters.Add("@montoTot", SqlDbType.VarChar).Value = monto;
        cmd.Parameters.Add("@fechaOrd", SqlDbType.DateTime).Value = fecha2;
        cmd.Parameters.Add("@id", SqlDbType.Char).Value = idProv;

        try
        {
            cn.getCN.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.getCN.Close();
        }

    }

    public DataTable listarOrdenes()
    {
        SqlDataAdapter da = new SqlDataAdapter("listaOrdenes", cn.getCN);

        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataTable db = new DataTable();
        da.Fill(db);
        return db;
    }


}