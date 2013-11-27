<%@ Page Title="" Language="C#" MasterPageFile="~/MasteCliente.Master" AutoEventWireup="true" CodeBehind="frmBuscarProducto.aspx.cs" Inherits="WebSiteComercialPilar.frmBuscarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-size: x-large;
            color: #3333CC;
        }
    </style>


    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style1" colspan="4">
                    Buscar Producto</td>
            </tr>
            <tr>
                <td width="15%">
                    &nbsp;</td>
                <td width="15%">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Stock" Checked="True" />
                </td>
                <td style="text-align: right">
                    Buscar:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtFiltro" runat="server" Width="195px" CssClass="cajaTexto"></asp:TextBox>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" onclick="btnbuscar_Click"
                    CssClass="botonBuscarSI" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                   <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" 
                        onitemcommand="DataList1_ItemCommand" HorizontalAlign="Center">
                        <EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" 
                                ImageUrl='<%# Eval("codProd", "imagenes/productos/{0}.jpg") %>' 
                                Height="200px" Width="200px" />
                            <br />
                            Codigo:
                            <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codProd") %>'></asp:Label>
                            <br />
                            Descripción:
                            <asp:Label ID="lblDescripProd" runat="server" Text='<%# Eval("descrip") %>'></asp:Label>
                            <br />
                            Precio:
                            <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("precio") %>'></asp:Label>
                            <br />
                            Stock:
                            <asp:Label ID="lblstock" runat="server" 
                                Text='<%# Eval("stock") %>'></asp:Label>
                            <br />
                            Categoria:
                            <asp:Label ID="lblNombreCategoria" runat="server" Text='<%# Eval("NombreCategoria") %>'></asp:Label>
                            <br />
                             <asp:Label ID="lblCodCate" runat="server" 
                                Text='<%# Eval("codCategoria") %>' Visible="false"></asp:Label>
                            <br />
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="botonSeleccionar" />
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" onclick="btnRegresar_Click"
                    CssClass="botonRegresar"/>
                </td>
            </tr>
        </table>
    
    </div>

</asp:Content>

