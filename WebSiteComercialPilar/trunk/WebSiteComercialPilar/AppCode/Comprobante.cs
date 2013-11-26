using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de Comprobante
/// </summary>
public class Comprobante
{
    Conexion cn = new Conexion();
    public Comprobante()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable listarComprobantes()
    {
        SqlDataAdapter da = new SqlDataAdapter("listaComprobante", cn.getCN);

        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataTable db = new DataTable();
        da.Fill(db);
        return db;
    }

    public DataTable consulta(String id)
    {
        SqlDataAdapter da = new SqlDataAdapter("usp_listacomprobante", cn.getCN);
        //indicar que se ejecuta un Procedure
        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //parametros
        da.SelectCommand.Parameters.Add("@id", SqlDbType.Char).Value = id;


        //DataTable,poblar y retornar
        DataTable tb = new DataTable();
        da.Fill(tb);

        return tb;
    }

    /*Procedures para Pagar el Pedido*/

    public int Autogenerado()
    {
        int x = 0;
        SqlCommand cmd = new SqlCommand(
            "usp_autogenera_Comprobante", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        cn.getCN.Open();

        x = (Int32)cmd.ExecuteScalar();
        cn.getCN.Close();

        if (x == 0)
            return 1;
        else
        {
            x += 1;
            return x;
        }
    }

    public int valida_nro_tarjeta(string nro,string usu,string codSeg)
    {
        int x = 0;
        SqlCommand cmd = new SqlCommand(
            "validar_nro_tarjeta", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@nro", SqlDbType.Char).Value = nro;
        cmd.Parameters.Add("@usu", SqlDbType.Char).Value = usu;
        cmd.Parameters.Add("@codSeg", SqlDbType.Char).Value = codSeg;

        cn.getCN.Open();

        x = (Int32)cmd.ExecuteScalar();
        cn.getCN.Close();

            return x;
    }

    public string insertarComprobante(DataComprobante compro)
    {

        string msg = "";
        SqlCommand cmd = new SqlCommand("usp_inserta_comprobante", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@nroCom", SqlDbType.Char).Value = compro.NroCompro;
        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = compro.Fecha;
        cmd.Parameters.Add("@usu", SqlDbType.Char).Value = compro.CodUsu;
        cmd.Parameters.Add("@nroPed", SqlDbType.Int).Value = compro.NroPed;
        cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = compro.Tipo;
        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = compro.Estado;
        cmd.Parameters.Add("@idp", SqlDbType.Char).Value = compro.idPais;
        cmd.Parameters.Add("@codDept", SqlDbType.Char).Value = compro.CodDept;
        cmd.Parameters.Add("@codProv", SqlDbType.Char).Value = compro.IdProv;
        cmd.Parameters.Add("@codDis", SqlDbType.Char).Value = compro.CodDis;

        cn.getCN.Open();
        try
        {
            msg = cmd.ExecuteNonQuery().ToString() + "Se registro Correctamente el Pago";

        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        finally
        {
            cn.getCN.Close();
        }

        return msg;

    }

    public void insertar_boleta(string nroCompro) {

        SqlCommand cmd = new SqlCommand("usp_inserta_boleta", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@nroComp", SqlDbType.Char).Value = nroCompro;

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

    public void inserta_factura(string nroCompro)
    {

        SqlCommand cmd = new SqlCommand("usp_inserta_factura", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@nroComp", SqlDbType.Char).Value = nroCompro;

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





}