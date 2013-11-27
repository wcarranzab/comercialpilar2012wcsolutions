<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Novedades.aspx.cs" Inherits="WebSiteComercialPilar.Novedades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        font-size: x-large;
        font-family: "Bradley Hand ITC";
        color: #990000;
    }
    .style6
    {
        text-align: justify;
        background-color: #FFD784;
    }
    .style8
    {
        background-color: #FFD784;
    }
        .style9
        {
            text-align: justify;
            background-color: #FFD784;
            font-family: Calibri;
            font-size: medium;
            color: #663300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style5" colspan="2" 
            style="text-align: center; background-color: #996633">
            <strong>COMERCIAL -MUEBLERÍA PILAR S.A</strong></td>
    </tr>
    <tr>
        <td class="style8" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/mueble.jpg" />
        </td>
        <td class="style9">
            <strong>“Comercial Pilar S.A” se distingue por su exclusiva atención en cuanto a la Venta de todo tipo de Muebles. Es una Tienda Comercial ubicada en el Centro de Lima, un excelente negocio que se rige bajo diferentes departamentos, los cuales son el departamento de Compra, Venta y el de Almacén. Su giro de negocio consiste en comprar todo tipo de Muebles al mejor Proveedor, para luego, de acuerdo a la demanda de ese mueble en el mercado, lo cotizan, calculando una utilidad para finalmente a través de una venta cierren dicha operación, convirtiéndose de esta manera en una de las tiendas de muebles más preferidas de la zona.
            </strong>
        </td>
    </tr>
    <tr>
        <td class="style6" colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

