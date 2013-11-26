using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DataTarjeta
/// </summary>
public class DataTarjeta
{
    private string nroTarjeta;
    private string descrip;
    private string codTipo;
    private string codUsu;
    private string codSeg;

    public string CodSeg
    {
        get { return codSeg; }
        set { codSeg = value; }
    }
    

    public string CodUsu
    {
        get { return codUsu; }
        set { codUsu = value; }
    }
    

    public string CodTipo
    {
        get { return codTipo; }
        set { codTipo = value; }
    }
    

    public string Descrip
    {
        get { return descrip; }
        set { descrip = value; }
    }
    


    public string NroTarjeta
    {
        get { return nroTarjeta; }
        set { nroTarjeta = value; }
    }
    

	public DataTarjeta()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}