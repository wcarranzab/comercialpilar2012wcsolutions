using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DataUsuario
/// </summary>
public class DataUsuario
{
	//atributos
    string codUsu;
    string nomUsu;
    string apePat;
    string apeMat;
    DateTime fechaNac;
    string domicilio;
    string telefono;
    string dni;
    string tipoUsu;
    string idPais;
    string codDpto;
    string codProv;
    string codDis;
    string clave;

    //propiedades
    public string CodUsu
    {
        get { return codUsu; }
        set { codUsu = value; }
    }
    public string NomUsu
    {
        get { return nomUsu; }
        set { nomUsu = value; }
    }
    public string ApePat
    {
        get { return apePat; }
        set { apePat = value; }
    }
    public string ApeMat
    {
        get { return apeMat; }
        set { apeMat = value; }
    }
    public DateTime FechaNac
    {
        get { return fechaNac; }
        set { fechaNac = value; }
    }
    public string Domicilio
    {
        get { return domicilio; }
        set { domicilio = value; }
    }
    public string Telefono
    {
        get { return telefono; }
        set { telefono = value; }
    }
    public string DNI
    {
        get { return dni; }
        set { dni = value; }
    }
    public string TipoUsu
    {
        get { return tipoUsu; }
        set { tipoUsu = value; }
    }
    public string IdPais
    {
        get { return idPais; }
        set { idPais = value; }
    }
    public string CodDpto
    {
        get { return codDpto; }
        set { codDpto = value; }
    }
    public string CodProv
    {
        get { return codProv; }
        set { codProv = value; }
    }
    public string CodDis
    {
        get { return codDis; }
        set { codDis = value; }
    }

    public string Clave
    {
        get { return clave; }
        set { clave = value; }
    }

    public DataUsuario()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}