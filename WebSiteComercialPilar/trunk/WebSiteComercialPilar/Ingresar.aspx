<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="WebSiteComercialPilar.Ingresar" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/MySyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: xx-large;
        }
        .style3
        {
            font-size: xx-large;
            color: #993300;
        }
        .style4
        {
            font-size: x-large;
            color: #996600;
        }
    </style>
</head>
<body class="bodyMarron">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="fondoMostaza">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/mueble.jpg" />
                    <br />
                    <br />
                    <span class="style3"><strong>MUEBLES PILAR S.A</strong></span><strong><br 
                        class="style2" />
                    </strong><span class="style4"><em><strong>Creaciones Originales y de Alta 
                    Calidad</strong></em></span><br />
                </td>
            </tr>
            <tr>
                <td class="fondoMedioVerde">
                    <asp:HyperLink ID="ingreso" runat="server" ForeColor="#6600FF" 
                        style="font-family: 'Bradley Hand ITC'; font-size: xx-large; font-weight: 700"
                        NavigateUrl="~/Novedades.aspx">INGRESAR</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
