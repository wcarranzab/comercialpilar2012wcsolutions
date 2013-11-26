using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Paises
/// </summary>
public class Paises
{
	
    Conexion cn = new Conexion();

    public Paises()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable listado()
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * from tb_paises order by NombrePais asc", cn.getCN);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
}