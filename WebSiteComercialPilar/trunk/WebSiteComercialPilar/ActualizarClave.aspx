<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRegistroUsu.Master" AutoEventWireup="true" CodeBehind="ActualizarClave.aspx.cs" Inherits="WebSiteComercialPilar.ActualizarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            text-align: center;
            font-size: large;
            font-family: "Comic Sans MS";
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style5" colspan="3">
                <strong style="text-align: center">REESTABLECER CONTRASEÑA</strong></td>
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
            <td style="text-align: right">
                Usuario:</td>
            <td>
                <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                Nueva Contraseña:</td>
            <td>
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="194px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                Reescribir Contraseña:</td>
            <td>
                <asp:TextBox ID="txtClave1" runat="server" TextMode="Password" Width="194px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnActualizar" runat="server" Height="32px" 
                   Text="ACTUALIZAR" Width="192px" onclick="btnActualizar_Click" />
                   
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

