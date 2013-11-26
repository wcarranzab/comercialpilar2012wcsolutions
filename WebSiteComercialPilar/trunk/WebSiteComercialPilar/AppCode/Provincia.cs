using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Provincia
/// </summary>
public class Provincia
{
    Conexion cn = new Conexion();

    public Provincia()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable listado(string pais,string dpto)
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * from tb_provincia where IdPais=@pais and codDpto=@dpto order by nomProv asc", cn.getCN);
        da.SelectCommand.Parameters.Add("@pais", SqlDbType.Char).Value = pais;
        da.SelectCommand.Parameters.Add("@dpto", SqlDbType.Char).Value = dpto;
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
}