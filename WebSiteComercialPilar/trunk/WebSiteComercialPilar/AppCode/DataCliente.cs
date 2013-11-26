using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DataCliente
/// </summary>
public class DataCliente
{
    //atributos
    string codUsu_Cli;
    string ruc;

    //propiedades
    public string CodUsu_Cli
    {
        get { return codUsu_Cli; }
        set { codUsu_Cli = value; }
    }

    public string RUC
    {
        get { return ruc; }
        set { ruc = value; }
    }

	public DataCliente()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}