<%@ Page Title="" Language="C#" MasterPageFile="~/MasteCliente.Master" AutoEventWireup="true" CodeBehind="PrincipalCliente.aspx.cs" Inherits="WebSiteComercialPilar.PrincipalCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            font-size: large;
            font-family: "Bradley Hand ITC";
        }
        .style6
        {
            font-size: x-large;
            font-family: "Bradley Hand ITC";
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="3">
                <span class="style5"><strong>Bienvenido</strong></span>
                <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Font-Size="Large" 
                    style="font-family: 'Bradley Hand ITC'"></asp:Label>
                <strong><span class="style6">!</span></strong></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Salir" CssClass="botonRegresar" 
                    onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

