<%@ Page Title="" Language="C#" MasterPageFile="~/MasteCliente.Master" AutoEventWireup="true" CodeBehind="frmPedido.aspx.cs" Inherits="WebSiteComercialPilar.frmPedido" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
    function ventanaSecundaria() {
        window.open("frmPagar.aspx", "popup", "resizable=yes, top=" + parseInt(((screen.height) / 2) - 200) + ", width=600 ,height=400, left=" + parseInt(((screen.width) / 2) - 300) + ", menubar=no, scrollbars=no, status=no, titlebar=no, toolbar=no,directories=no")
    }

</script> 


    <style type="text/css">
        .style1
        {
            text-align: center;
            height: 23px;
            color: #3333FF;
        }
        .style2
        {
            text-decoration: underline;
            color: #3333CC;
        }
        .style3
        {
            height: 23px;
        }
    </style>

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width:100%;">
            <tr>
                <td class="style1" colspan="4">
                    REGISTRAR PEDIDO</td>
            </tr>
            <tr>
            
                <td class="style2" width="25%">
                    
                    Datos del Cliente</td>
                <td colspan="2">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblCodigo" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Apellidos:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Telefono:</td>
                <td colspan="2" style="text-align: center" width="40%">
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Direccion:</td>
                <td colspan="2" style="text-align: center" width="40%">
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                </td>s
                <td>
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    Datos del Producto</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Nombre:</td>
                <td colspan="2">
                    <asp:Label ID="lblNombreProducto" runat="server"></asp:Label>
                   
                </td>
                <td style="text-align: left">
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" onclick="btnbuscar_Click"
                    CssClass="botonBuscarSI" />
                   
                </td>
            </tr>
            <tr>
                <td>
                    Categoria:</td>
                <td colspan="2">
                    <asp:Label ID="lblTipoPorducto" runat="server"></asp:Label>
                </td>
                <td rowspan="3" style="text-align: left">
                    <asp:Image ID="imgFoto" runat="server" Width="80px" Height="80px"/>
                    </td>
            </tr>
            <tr>
                <td>
                    Precio:</td>
                <td colspan="2">
                    <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Stock:</td>
                <td colspan="2">
                    <asp:Label ID="lblStock" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Cantidad:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="style2">
                    Detalle del Pedido</td>
                <td colspan="2" style="text-align: left">

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" onclick="btnAgregar_Click"
                    CssClass="botonAgregar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" onrowdeleting="GridView1_RowDeleting" 
                        >
                        <Columns>
                            <asp:BoundField DataField="nroPed" HeaderText="Nro. Pedido" 
                                Visible="False" />
                            <asp:BoundField DataField="codProd" HeaderText="Cod. Producto" />
                            <asp:BoundField DataField="nroKardex" HeaderText="Nro. Kardex" 
                                Visible="False" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="descuento" HeaderText="Descuento" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" />
                            <asp:BoundField DataField="importe" HeaderText="Importe S/D" />
                            <asp:BoundField DataField="total" HeaderText="Importe Total" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Monto total:</td>
                <td class="style3" colspan="2">
                    <asp:Label ID="lblMonto" runat="server">0.0</asp:Label>
                &nbsp;S/</td>
                <td class="style3">
                    </td>
            </tr>
            <tr>
                <td class="style3">
                    Fecha de Entrega:</td>
                <td class="style3" colspan="2">
                    <asp:TextBox ID="txtFechaEntrega" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaEntrega_CalendarExtender" runat="server" 
                        TargetControlID="txtFechaEntrega" Format="dd/MM/yyyy" Enabled="False">
                    </asp:CalendarExtender>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Tipo de entrega:</td>
                <td width="20%" style="text-align: left">
                    <asp:CheckBoxList ID="cbTipoEmtrega" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cbTipoEmtrega_SelectedIndexChanged">
                        <asp:ListItem>Delivery</asp:ListItem>
                        <asp:ListItem>Directo</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    Tipo de Comprobante:</td>
                <td style="text-align: left">
                    <asp:CheckBoxList ID="cbTipoComprobante" runat="server">
                        <asp:ListItem>Boleta</asp:ListItem>
                        <asp:ListItem>Factura</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    Forma de Pago:</td>
                <td style="text-align: left">
                    <asp:CheckBoxList ID="cbFormaPago" runat="server">
                        <asp:ListItem>Credito</asp:ListItem>
                        <asp:ListItem>Debito</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    Tipo de Tarjeta:</td>
                <td style="text-align: left">
                    <asp:CheckBoxList ID="cbTipoTarjeta" runat="server">
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>Master Card</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" onclick="btnRegresar_Click"
                    CssClass="botonRegresar"/>
                </td>
                <td colspan="2" style="text-align: center">

                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" onclick="btnGrabar_Click"
                    CssClass="botonGrabar" />
                </td>
                <td>
                    <asp:Button ID="bntPagar" runat="server" CssClass="botonSeleccionar" 
                        onclick="bntPagar_Click" Text="Pagar" OnClientClick="ventanaSecundaria();" />
                </td>
            </tr>
        </table>
    
    </div>

</asp:Content>

