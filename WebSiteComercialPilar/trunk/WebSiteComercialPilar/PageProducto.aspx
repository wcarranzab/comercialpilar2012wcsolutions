<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageComun.Master" AutoEventWireup="true" CodeBehind="PageProducto.aspx.cs" Inherits="WebSiteComercialPilar.PageProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
        .style6
        {
            height: 23px;
            color: #3333FF;
            font-size: x-large;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style6" colspan="3">
                    <strong>MANTENIMIENTO DE PRODUCTOS</strong></td>
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
                <td>
                    Código:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtCodigo" runat="server" Enabled="False" Height="19px" 
                        ReadOnly="True" Width="211px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                    Nombre:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtNombre" runat="server" Height="22px" Width="211px"></asp:TextBox>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtNombre" Display="Dynamic" 
                        ErrorMessage="Ingrese Descripción del Producto" ForeColor="Red">*</asp:RequiredFieldValidator>
                   
                </td>
                <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar"
                    CssClass="botonGrabar" onclick="btnAgregar_Click" />
                </td>
                    
            </tr>
            <tr>
                <td>
                    Categoria:</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="cboCategoria" runat="server" Height="23px" Width="219px">
                    </asp:DropDownList>
                </td>
                <td>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                    CssClass="botonGrabar" onclick="btnActualizar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    Precio:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPrecio" runat="server" Height="22px" Width="211px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtPrecio" Display="Dynamic" 
                        ErrorMessage="El Precio tiene que ser Positivo" ForeColor="Red" 
                        Operator="GreaterThan" Type="Double" ValueToCompare="0">*</asp:CompareValidator>
                </td>
                <td>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                    CssClass="botonGrabar" onclick="btnEliminar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    Stock:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtStock" runat="server" Height="22px" Width="211px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToValidate="txtStock" Display="Dynamic" 
                        ErrorMessage="El Stock tiene que ser Positivo" ForeColor="Red" 
                        Operator="GreaterThan" Type="Integer" ValueToCompare="0">*</asp:CompareValidator>
                </td>
            </tr>
           
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                        ShowMessageBox="True" />
                </td>
            </tr>
           
            
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        >
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="codProd" HeaderText="Cod. Producto" />
                            <asp:BoundField DataField="descrip" HeaderText="Descripción" />
                            <asp:BoundField DataField="NombreCategoria" HeaderText="Categoria" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" />
                            <asp:BoundField DataField="stock" HeaderText="Stock" />
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
            
        </table>
    
    </div>

</asp:Content>


