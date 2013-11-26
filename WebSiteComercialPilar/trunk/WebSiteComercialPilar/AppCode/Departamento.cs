using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Departamento
/// </summary>
public class Departamento
{
	
    Conexion cn = new Conexion();

    public Departamento()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable listado(string pais)
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * from tb_departamento where IdPais = @pais order by nomDpto asc", cn.getCN);
        da.SelectCommand.Parameters.Add("@pais", SqlDbType.Char).Value = pais;
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
}