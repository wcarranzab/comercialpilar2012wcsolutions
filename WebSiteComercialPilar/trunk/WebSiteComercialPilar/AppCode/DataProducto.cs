using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DataProducto
/// </summary>
public class DataProducto
{

    private int codigo;
    private string descrip;
    private double precio;
    private int stock;
    private string cod_emple;
    private int cod_cat;

    public int Cod_Cate
    {
        get { return cod_cat; }
        set { cod_cat = value; }
    }
    

    public string Cod_Emple
    {
        get { return cod_emple; }
        set { cod_emple = value; }
    }
    

    public int Stock
    {
        get { return stock; }
        set { stock = value; }
    }
    

    public double Precio
    {
        get { return precio; }
        set { precio = value; }
    }
    

    public string Descrip
    {
        get { return descrip; }
        set { descrip = value; }
    }
    

    public int Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }
    

	public DataProducto()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}