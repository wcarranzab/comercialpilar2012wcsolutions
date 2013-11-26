using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DataComprobante
/// </summary>
public class DataComprobante
{
    private string nroCompro;
    private DateTime fecha;
    private string codUsu;
    private int nroPed;
    private string tipo;
    private string estado;
    private string idpais;
    private string codDept;
    private string idProv;  
    private string codDis;

    public string CodDis
    {
        get { return codDis; }
        set { codDis = value; }
    }
    

    public string CodDept
    {
        get { return codDept; }
        set { codDept = value; }
    }
    
    


    public string IdProv
    {
        get { return idProv; }
        set { idProv = value; }
    }
    

    public string idPais
    {
        get { return idpais; }
        set { idpais = value; }
    }
    

    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }
    

    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }
    

    public int NroPed
    {
        get { return nroPed; }
        set { nroPed = value; }
    }
    

    public string CodUsu
    {
        get { return codUsu; }
        set { codUsu = value; }
    }
    

    public DateTime Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }
    

    public string NroCompro
    {
        get { return nroCompro; }
        set { nroCompro = value; }
    }
    

	public DataComprobante()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}