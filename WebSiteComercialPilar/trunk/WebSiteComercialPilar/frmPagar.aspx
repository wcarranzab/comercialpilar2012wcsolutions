<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePopup.Master" AutoEventWireup="true" CodeBehind="frmPagar.aspx.cs" Inherits="WebSiteComercialPilar.frmPagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 85px;
            height: 27px;
        }
        .style4
        {
            width: 56px;
            height: 29px;
        }
    .style5
    {
        text-align: left;
    }
    .style6
    {
        width: 240px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <h1 style="text-align:center">Registrar Pago de Pedido</h1>

        <fieldset>
        <legend>Datos del CLiente</legend>
        <table style="width:100%;">
            <tr>
                <td width="22%" style="text-align: right">
                    Nombre:&nbsp; </td>
                <td class="style6">
                    &nbsp;&nbsp;<asp:Label ID="lblNombre" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Tipo de Comprobante:</td>
                <td class="style6">
                    &nbsp;&nbsp;<asp:Label ID="lblTipoComprobante" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Fecha de Pago:</td>
                <td class="style6">
                    &nbsp;&nbsp;<asp:Label ID="lblFechaPago" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Monto a Pagar:</td>
                <td class="style6">
                    &nbsp;&nbsp;<asp:Label ID="lblMonto" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </fieldset>

        <br />
        <hr />
        <br />

        <fieldset>
            <legend>Datos de la tarjeta</legend>  
            <table style="width: 100%;">
                <tr>
                    <td>
                        &nbsp;
                        &nbsp;
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        &nbsp;
                        Tarjeta de Crédito:&nbsp;
                        &nbsp;
                        <asp:TextBox ID="txtNroTarjeta" runat="server"></asp:TextBox>
                    &nbsp;<img alt="" class="style3" src="imagenes/imagenVisa.jpg" /></td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CVV/CVV2/:&nbsp;
                        &nbsp;
                        <asp:TextBox ID="txtCodigoSeg" runat="server" Width="40PX"></asp:TextBox>
                    &nbsp;<img alt="" class="style4" src="imagenes/codigo-de-seguridad.JPG" /></td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Button ID="btnProcesar" runat="server" style="text-align: center" 
                            Text="Procesar" onclick="btnProcesar_Click" CssClass="botonGrabar"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        
    </div>
</asp:Content>

