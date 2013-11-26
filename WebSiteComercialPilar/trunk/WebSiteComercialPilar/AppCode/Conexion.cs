using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    SqlConnection cn;

    public Conexion()
    {
        cn = new SqlConnection("server=.;database=BDComercialPilar;uid=sa;pwd=sql");
       // cn = new SqlConnection("server=APOLO;database=BDComercialPilar;Integrated Security=True");
    }

    public SqlConnection getCN
    {
        get { return cn; }
    }
}