using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DataHojaPedido
/// </summary>
public class DataHojaPedido
{
    private int nroPed;
    private string codCli;
    private string codVend;
    private string tipoComprobante;
    private DateTime fecPedido;
    private DateTime fecEntrega;
    private string formaPago;
    private string tipoTarjeta;
    private string estado;
    private string codDept;
    private string codPais;
    private string codProv;
    private string codDis;

    public string CodDis
    {
        get { return codDis; }
        set { codDis = value; }
    }
    

    public string CodProv
    {
        get { return codProv; }
        set { codProv = value; }
    }
    

    public string CodPais
    {
        get { return codPais; }
        set { codPais = value; }
    }
    

    public string CodDept
    {
        get { return codDept; }
        set { codDept = value; }
    }
    

    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }
    

    public string TipoTarjeta
    {
        get { return tipoTarjeta; }
        set { tipoTarjeta = value; }
    }
    

    public string FormaPago
    {
        get { return formaPago; }
        set { formaPago = value; }
    }
    

    public DateTime FecEntrega
    {
        get { return fecEntrega; }
        set { fecEntrega = value; }
    }
    

    public DateTime FecPedido
    {
        get { return fecPedido; }
        set { fecPedido = value; }
    }
    

    public string TipoComprobante
    {
        get { return tipoComprobante; }
        set { tipoComprobante = value; }
    }
    

    public string CodVend
    {
        get { return codVend; }
        set { codVend = value; }
    }
    

    public string CodCli
    {
        get { return codCli; }
        set { codCli = value; }
    }
    


    public int NroPedido
    {
        get { return nroPed; }
        set { nroPed = value; }
    }
    

	public DataHojaPedido()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}