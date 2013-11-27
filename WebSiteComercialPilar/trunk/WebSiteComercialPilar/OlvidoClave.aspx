<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRegistroUsu.Master" AutoEventWireup="true" CodeBehind="OlvidoClave.aspx.cs" Inherits="WebSiteComercialPilar.OlvidoClave" %>
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
                <strong>REESTABLECER CONTRASEÑA</strong></td>
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
                <asp:TextBox ID="txtUsuario" runat="server" Width="241px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="Ingrese Usuario" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                Fecha de Nacimiento:</td>
            <td>
                <asp:TextBox ID="txtFecha" runat="server" Width="241px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="Ingrese Fecha" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnComprobar" runat="server" Height="35px" 
                    onclick="btnComprobar_Click" Text="VALIDAR" Width="142px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

