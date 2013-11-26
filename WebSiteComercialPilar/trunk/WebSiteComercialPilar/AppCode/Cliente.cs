using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Cliente
{
    Conexion cn = new Conexion();

	public Cliente()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable listado()
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * from tb_Cliente", cn.getCN);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }

    //metodo para agregar un cliente y retorna el mensaje de confirmacion del proceso
    public string agregar(DataCliente dc)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_add_cliente", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = dc.CodUsu_Cli;
        cmd.Parameters.Add("@ruc", SqlDbType.Char).Value = dc.RUC;
        
        //abrir la conexion
        cn.getCN.Open();
        try
        {
            msg = cmd.ExecuteNonQuery().ToString() + "Registro Agregado";

        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        finally
        {
            cn.getCN.Close();
        }

        //enviamos el mensaje
        return msg;
    }

    //metodo para actualizar un cliente y retorna el mensaje de confirmacion del proceso
    public string actualizar(DataCliente dc)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_update_cliente", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = dc.CodUsu_Cli;
        cmd.Parameters.Add("@ruc", SqlDbType.Char).Value = dc.RUC;

        //abrir la conexion
        cn.getCN.Open();
        try
        {
            msg = cmd.ExecuteNonQuery().ToString() + "Registro Actualizado";

        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        finally
        {
            cn.getCN.Close();
        }

        //enviamos el mensaje
        return msg;
    }

    //metodo para eliminar un cliente y retorna el mensaje de confirmacion del proceso
    public string eliminar(DataCliente dc)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_delete_cliente", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = dc.CodUsu_Cli;
        

        //abrir la conexion
        cn.getCN.Open();
        try
        {
            msg = cmd.ExecuteNonQuery().ToString() + "Registro Eliminado";

        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        finally
        {
            cn.getCN.Close();
        }

        //enviamos el mensaje
        return msg;
    }
}