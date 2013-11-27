<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageComun.Master" AutoEventWireup="true" CodeBehind="RegistrarOrdenDeCompra.aspx.cs" Inherits="WebSiteComercialPilar.RegistrarOrdenDeCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%;">
    <tr>
        <td class="style7" colspan="3">
            <strong>ORDEN DE COMPRA</strong></td>
    </tr>
    <tr>
        <td width="25%" class="style2">
            <strong class="style2">DATOS DEL COMPROBANTE</strong></td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            Código del Comprobante:</td>
        <td width="25%">
            <asp:TextBox ID="txtCodigoComprobante" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnBuscarComprobante" runat="server" Text="BUSCAR COMPROBANTE" 
                onclick="btnBuscarComprobante_Click" />
        </td>
    </tr>
    <tr>
        <td class="style2">
            Fecha del Comprobante:</td>
        <td>
            <asp:TextBox ID="txtFechaComprobante" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
        </td>
        <td class="style1">
        </td>
        <td class="style1">
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
            <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                CellSpacing="2" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                Width="100%">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
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
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnMontoTotal" runat="server" Text="CALCULAR MONTO TOTAL" 
                Enabled="False" onclick="btnMontoTotal_Click" />
        </td>
        <td width="25%">
            <asp:TextBox ID="txtMontoTotal" runat="server" Enabled="False">0</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <strong class="style2">DATOS DE LA ORDEN </strong>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            Código de Orden:</td>
        <td>
            <asp:TextBox ID="txtCodOrden" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            Fecha de Registro:</td>
        <td>
            <asp:TextBox ID="txtFechaOrden" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            Proveedor:</td>
        <td>
            <asp:DropDownList ID="cboProveedor" runat="server" Height="19px" Width="124px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" colspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnGenerarOrden" runat="server" Text="GENERAR ORDEN DE COMPRA" 
                onclick="btnGenerarOrden_Click" />
        </td>
    </tr>
</table>
</asp:Content>

