<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageComun.Master" AutoEventWireup="true" CodeBehind="GestionarAlmacen.aspx.cs" Inherits="WebSiteComercialPilar.GestionarAlmacen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            font-size: large;
            font-family: "Bradley Hand ITC";
        color: #996600;
    }
    .style6
    {
        height: 59px;
        font-size: xx-large;
        font-family: "Bradley Hand ITC";
    }
        .style7
        {
            width: 968px;
        }
        .style8
        {
            color: #6600CC;
            font-size: large;
            font-family: "Bradley Hand ITC";
            width: 968px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table class="style1">
        <tr>
            <td class="style6" colspan="4" style="text-align: center">
                <strong>GESTIONAR ALMACÉN</strong></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center" class="style7">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/entrada.jpg" />
            </td>
            <td style="text-align: center" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style8" style="text-align: center">
                <strong>CONTROL DE ENTRADA</strong></td>
            <td class="style5" style="text-align: center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center" class="style7">
                <asp:HyperLink ID="Ingreso2" runat="server" 
                    style="font-family: 'Comic Sans MS'; font-size: medium" 
                    NavigateUrl="~/PageProducto.aspx">Mantenimiento de Productos</asp:HyperLink>
            </td>
            <td style="text-align: center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center" class="style7">
                &nbsp;</td>
            <td style="text-align: center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td style="text-align: center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

