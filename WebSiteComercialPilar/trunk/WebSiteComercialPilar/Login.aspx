<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="Login.aspx.cs" Inherits="WebSiteComercialPilar.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            font-family: "Comic Sans MS";
            font-size: large;
            color: #0033CC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="3" style="text-align: center" class="style5">
                <strong>INGRESO AL SISTEMA PILAR</strong></td>
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
                <asp:TextBox ID="txtUsuario" runat="server" Width="201px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="Ingrese Usuario" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                Password:</td>
            <td>
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="201px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtClave" Display="Dynamic" 
                    ErrorMessage="Ingrese Contraseña" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button 
                    ID="btnIngreso" runat="server" Height="27px" Text="INGRESAR" Width="149px" 
                    onclick="btnIngreso_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="olvido" runat="server" NavigateUrl="~/OlvidoClave.aspx">¿Olvidaste tu Contraseña?</asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="nuevo" runat="server" NavigateUrl="~/RegistroUsu.aspx">¿No tienes Uusario? Regístrate</asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

