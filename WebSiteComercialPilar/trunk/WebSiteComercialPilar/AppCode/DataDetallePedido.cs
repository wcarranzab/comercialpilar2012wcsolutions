using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de DataDetallePedido
/// </summary>
public class DataDetallePedido
{
    private DataTable detallePedido;
    
	public DataDetallePedido()
	{
        
        detallePedido = new DataTable();
        detallePedido.Columns.Add("nroPed", typeof(int));
        detallePedido.Columns.Add("codProd", typeof(int));
        detallePedido.Columns.Add("nroKardex", typeof(string));
        detallePedido.Columns.Add("cantidad", typeof(double));
        detallePedido.Columns.Add("descuento", typeof(double));
        detallePedido.Columns.Add("precio", typeof(double));
        detallePedido.Columns.Add("importe", typeof(double), "precio*cantidad");
        detallePedido.Columns.Add("total", typeof(double), "importe-descuento");
        detallePedido.PrimaryKey = new DataColumn[] {detallePedido.Columns[1]};
	}

    public DataTable getDetallePedido
    {
        get { return detallePedido; }
    }
}