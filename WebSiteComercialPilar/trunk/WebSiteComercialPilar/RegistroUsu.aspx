<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRegistroUsu.Master" AutoEventWireup="true" CodeBehind="RegistroUsu.aspx.cs" Inherits="WebSiteComercialPilar.RegistroUsu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            text-align: center;
            font-size: large;
            font-family: "Comic Sans MS";
        }
        .style6
        {
            width: 160px;
        }
        .style7
        {
            width: 160px;
            height: 23px;
        }
        .style8
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style5" colspan="4">
                <strong>REGISTRO DE USUARIO</strong></td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Usuario:</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="185px"></asp:TextBox>
            </td>
            <td>
                RUC:</td>
            <td>
                <asp:TextBox ID="txtRUC" runat="server" Width="185px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Nombre:</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="185px"></asp:TextBox>
            </td>
            <td>
                Apellido Paterno:</td>
            <td>
                <asp:TextBox ID="txtApePat" runat="server" Width="185px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                Apellido Materno:</td>
            <td class="style8">
                <asp:TextBox ID="txtApeMat" runat="server" Width="185px"></asp:TextBox>
            </td>
            <td class="style8">
                Fecha de Nacimiento:</td>
            <td class="style8">
                <asp:TextBox ID="txtFechaNac" runat="server" Width="185px"></asp:TextBox>
&nbsp;(yyyy-mm-dd)</td>
        </tr>
        <tr>
            <td class="style7">
                Domicilio:</td>
            <td class="style8" colspan="2">
                <asp:TextBox ID="txtDomi" runat="server" Width="336px"></asp:TextBox>
            </td>
            <td class="style8">
            </td>
        </tr>
        <tr>
            <td class="style6">
                Teléfono:</td>
            <td>
                <asp:TextBox ID="txtFono" runat="server" Width="185px"></asp:TextBox>
            </td>
            <td>
                DNI:</td>
            <td>
                <asp:TextBox ID="txtDni" runat="server" Width="185px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                País:</td>
            <td>
                <asp:DropDownList ID="cboPaises" runat="server" AutoPostBack="True" 
                    Height="20px" onselectedindexchanged="cboPaises_SelectedIndexChanged" 
                    Width="184px">
                </asp:DropDownList>
            </td>
            <td>
                Departamento:</td>
            <td>
                <asp:DropDownList ID="cboDpto" runat="server" AutoPostBack="True" Height="20px" 
                    onselectedindexchanged="cboDpto_SelectedIndexChanged" Width="184px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Provincia:</td>
            <td>
                <asp:DropDownList ID="cboProv" runat="server" AutoPostBack="True" Height="20px" 
                    onselectedindexchanged="cboProv_SelectedIndexChanged" Width="184px">
                </asp:DropDownList>
            </td>
            <td>
                Distrito:</td>
            <td>
                <asp:DropDownList ID="cboDist" runat="server" AutoPostBack="True" Height="20px" 
                    Width="184px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Password:</td>
            <td>
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="185px"></asp:TextBox>
            </td>
            <td>
                Nro. de tarjeta:</td>
            <td>
                <asp:TextBox ID="txtNroTarjeta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                Cod. Seguridad:&nbsp;</td>
            <td>
                <asp:TextBox ID="txtCodSeguridad" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Button ID="btnRegistrar" runat="server" Height="35px" 
                    onclick="btnRegistrar_Click" Text="REGISTRAR" Width="146px" />
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnCancelar" runat="server" Height="35px" 
                    onclick="btnCancelar_Click" Text="CANCELAR" Width="146px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

