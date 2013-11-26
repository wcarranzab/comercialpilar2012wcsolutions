using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Distrito
/// </summary>
public class Distrito
{
	
    Conexion cn = new Conexion();

    public Distrito()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable listado(string pais,string dpto,string provi)
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * from tb_distrito where IdPais=@pais and codDpto=@dpto and codProv=@provi order by nomDis asc", cn.getCN);
        da.SelectCommand.Parameters.Add("@pais", SqlDbType.Char).Value = pais;
        da.SelectCommand.Parameters.Add("@dpto", SqlDbType.Char).Value = dpto;
        da.SelectCommand.Parameters.Add("@provi", SqlDbType.Char).Value = provi;
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
}