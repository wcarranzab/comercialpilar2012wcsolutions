using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
	
    Conexion cn = new Conexion();

    public Usuario()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable muestraDatosUsuario(string usu)
    {
        SqlDataAdapter da = new SqlDataAdapter("usp_mostrar_datos_usuario", cn.getCN);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@usu", SqlDbType.Char).Value = usu;
        DataTable tb = new DataTable();
        da.Fill(tb);
        return tb;
    }



    public DataTable muestraDatosPago(string usu, int codPed)
    {
        SqlDataAdapter da = new SqlDataAdapter("usp_datos_cli_pago", cn.getCN);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@usu", SqlDbType.Char).Value = usu;
        da.SelectCommand.Parameters.Add("@codPed", SqlDbType.Int).Value = codPed;
        DataTable tb = new DataTable();
        da.Fill(tb);
        return tb;

    }

    public DataTable listado()
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * from tb_usuario", cn.getCN);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }

    //metodo para agregar un usuario y retorna el mensaje de confirmacion del proceso
    public string agregar(DataUsuario du)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_add_usuario", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;
        
        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = du.CodUsu;
        cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = du.NomUsu;
        cmd.Parameters.Add("@apePat", SqlDbType.VarChar).Value = du.ApePat;
        cmd.Parameters.Add("@apeMat", SqlDbType.VarChar).Value = du.ApeMat;
        cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = du.FechaNac;
        cmd.Parameters.Add("@domi", SqlDbType.VarChar).Value = du.Domicilio;
        cmd.Parameters.Add("@fono", SqlDbType.Char).Value = du.Telefono;
        cmd.Parameters.Add("@dni", SqlDbType.Char).Value = du.DNI;
        cmd.Parameters.Add("@tipoUsu", SqlDbType.VarChar).Value = du.TipoUsu;
        cmd.Parameters.Add("@pais", SqlDbType.Char).Value = du.IdPais;
        cmd.Parameters.Add("@depa", SqlDbType.Char).Value = du.CodDpto;
        cmd.Parameters.Add("@provi", SqlDbType.Char).Value = du.CodProv;
        cmd.Parameters.Add("@dist", SqlDbType.Char).Value = du.CodDis;
        cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = du.Clave;
        

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


    public void agregarTarjeta(DataTarjeta dt)
    {
        
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_add_Tarjeta", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@NroTarj", SqlDbType.Char).Value = dt.NroTarjeta;
        cmd.Parameters.Add("@Descrip", SqlDbType.VarChar).Value = dt.Descrip;
        cmd.Parameters.Add("@codTipoTarj", SqlDbType.Char).Value = dt.CodTipo;
        cmd.Parameters.Add("@codUsu_Cli", SqlDbType.Char).Value = dt.CodUsu;
        cmd.Parameters.Add("@codSeguridad", SqlDbType.Char).Value = dt.CodSeg;


        //abrir la conexion
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


    //metodo para actualizar un usuario y retorna el mensaje de confirmacion del proceso
    public string actualizar(DataUsuario du)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_update_usuario", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = du.CodUsu;
        cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = du.NomUsu;
        cmd.Parameters.Add("@apePat", SqlDbType.VarChar).Value = du.ApePat;
        cmd.Parameters.Add("@apeMat", SqlDbType.VarChar).Value = du.ApeMat;
        cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = du.FechaNac;
        cmd.Parameters.Add("@domi", SqlDbType.VarChar).Value = du.Domicilio;
        cmd.Parameters.Add("@fono", SqlDbType.Char).Value = du.Telefono;
        cmd.Parameters.Add("@dni", SqlDbType.Char).Value = du.DNI;
        cmd.Parameters.Add("@tipoUsu", SqlDbType.VarChar).Value = du.TipoUsu;
        cmd.Parameters.Add("@pais", SqlDbType.Char).Value = du.IdPais;
        cmd.Parameters.Add("@depa", SqlDbType.Char).Value = du.CodDpto;
        cmd.Parameters.Add("@provi", SqlDbType.Char).Value = du.CodProv;
        cmd.Parameters.Add("@dist", SqlDbType.Char).Value = du.CodDis;
        cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = du.Clave;


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

    //metodo para eliminar un usuario y retorna el mensaje de confirmacion del proceso
    public string eliminar(DataUsuario du)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_delete_usuario", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = du.CodUsu;
        
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

    public int buscaUsuario(string cod)
    {
        int res = 0;
        //comando que ejecute el procedure
        SqlCommand cmd = new SqlCommand("usp_buscaUsuario", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = cod;


        //abrir la conexion
        cn.getCN.Open();
        try
        {
            res = (int)cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            cn.getCN.Close();
        }

        //enviamos el mensaje
        return res;
    }

    public int validaUsuario(string cod, string clave)
    {
        int res = 0;
        //comando que ejecute el procedure
        SqlCommand cmd = new SqlCommand("usp_validaUsuario", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = cod;
        cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;


        //abrir la conexion
        cn.getCN.Open();
        try
        {
            res = (int)cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            cn.getCN.Close();
        }

        //enviamos el mensaje
        return res;
    }

    public int validaIngreso(string cod)
    {
        int res = 0;
        //comando que ejecute el procedure
        SqlCommand cmd = new SqlCommand("usp_validaIngreso", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = cod;
       
        //abrir la conexion
        cn.getCN.Open();
        try
        {
            res = (int)cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            cn.getCN.Close();
        }

        //enviamos el mensaje
        return res;
    }

    public int validaUsuFecha(string cod,DateTime fecha)
    {
        int res = 0;
        //comando que ejecute el procedure
        SqlCommand cmd = new SqlCommand("usp_validaUsuFecha", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = cod;
        cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;

        //abrir la conexion
        cn.getCN.Open();
        try
        {
            res = (int)cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            cn.getCN.Close();
        }

        //enviamos el mensaje
        return res;
    }

    public string actualizarClave(string cod,string clave)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_actualizaClave", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@cod", SqlDbType.Char).Value = cod;
        cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;


        //abrir la conexion
        cn.getCN.Open();
        try
        {
            msg = cmd.ExecuteNonQuery().ToString() + "Clave Actualizado";

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