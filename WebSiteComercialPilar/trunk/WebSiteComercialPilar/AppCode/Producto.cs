using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Producto
/// </summary>
public class Producto
{
    Conexion cn = new Conexion();

	public Producto()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable listadoProducto()
    {
        SqlDataAdapter da = new SqlDataAdapter("usp_lista_prod", cn.getCN);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;   
        DataTable tb = new DataTable();
        da.Fill(tb);
        return tb;
    }

    public DataTable listaFiltroConStock(string filtro)
    {
        SqlDataAdapter da = new SqlDataAdapter("usp_lista_filtro", cn.getCN);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
        DataTable tb = new DataTable();
        da.Fill(tb);
        return tb;
    }

    public DataTable listaFiltroSinStock(string filtro)
    {
        SqlDataAdapter da = new SqlDataAdapter("usp_lista_filtro_sin_stock", cn.getCN);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
        DataTable tb = new DataTable();
        da.Fill(tb);
        return tb;
    }

    public void actualizar_stock(int codProd, int cant) {

        SqlCommand cmd = new SqlCommand("usp_actualizar_stock", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@codProd", SqlDbType.Int).Value = codProd;
        cmd.Parameters.Add("@cant", SqlDbType.Int).Value = cant;

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

 //metodo para buscar las categorias de los productos
    public DataTable buscaCate(string cate)
    {
        SqlDataAdapter da = new SqlDataAdapter("Select IdCategoria from tb_categorias where NombreCategoria=@cat", cn.getCN);
        da.SelectCommand.Parameters.Add("@cat", SqlDbType.VarChar).Value = cate;
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
    
    //metodo para listar las categorias de los productos
    public DataTable listarCate()
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * from tb_categorias", cn.getCN);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }

    //Autogenera el Producto
    public int autogenera()
    {
        //instanciar la conexion
        Conexion cn = new Conexion();

        SqlCommand cmd = new SqlCommand("Select max(codProd) from tb_Producto", cn.getCN);

        //abrir la conexion
        cn.getCN.Open();
        int x = (int)cmd.ExecuteScalar(); //ejecuta y retorna el valor
        //cerrar la conexion
        cn.getCN.Close();

        if (x == null)
            return 1;
        else
        {
            x += 1;
            return x;
        }
    }

    //metodo para listar los productos
    public DataTable listarProd()
    {
        SqlDataAdapter da = new SqlDataAdapter
        ("Select p.codProd,p.descrip,c.NombreCategoria,p.precio,p.stock from tb_Producto p join tb_categorias c on p.codCategoria = c.IdCategoria", cn.getCN);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }

    //metodo para agregar un producto y retorna el mensaje de confirmacion del proceso
    public string agregar(DataProducto dp)
    {
        string msg = "";
        //comando que ejecute el procedure insert
        SqlCommand cmd = new SqlCommand("usp_add_producto", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = dp.Codigo;
        cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = dp.Descrip;
        cmd.Parameters.Add("@pre", SqlDbType.Money).Value = dp.Precio;
        cmd.Parameters.Add("@cant", SqlDbType.Int).Value = dp.Stock;
        cmd.Parameters.Add("@codEmp", SqlDbType.Char).Value = dp.Cod_Emple;
        cmd.Parameters.Add("@codCate", SqlDbType.Int).Value = dp.Cod_Cate;

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

    //metodo para actualizar un producto y retorna el mensaje de confirmacion del proceso
    public string actualizar(DataProducto dp)
    {
        string msg = "";
        //comando que ejecute el procedure update
        SqlCommand cmd = new SqlCommand("usp_update_producto", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = dp.Codigo;
        cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = dp.Descrip;
        cmd.Parameters.Add("@pre", SqlDbType.Money).Value = dp.Precio;
        cmd.Parameters.Add("@cant", SqlDbType.Int).Value = dp.Stock;
        cmd.Parameters.Add("@codEmp", SqlDbType.Char).Value = dp.Cod_Emple;
        cmd.Parameters.Add("@codCate", SqlDbType.Int).Value = dp.Cod_Cate;

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

    //metodo para eliminar un producto y retorna el mensaje de confirmacion del proceso
    public string eliminar(DataProducto dp)
    {
        string msg = "";
        //comando que ejecute el procedure update
        SqlCommand cmd = new SqlCommand("usp_delete_producto", cn.getCN);
        cmd.CommandType = CommandType.StoredProcedure;

        //lista de Parametros
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = dp.Codigo;

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