using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de Proveedor
/// </summary>
public class Proveedor
{
    Conexion cn = new Conexion();

    public Proveedor()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable listarProveedores()
    {
        SqlDataAdapter da = new SqlDataAdapter("listaProveedor", cn.getCN);

        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataTable db = new DataTable();
        da.Fill(db);
        return db;
    }

}