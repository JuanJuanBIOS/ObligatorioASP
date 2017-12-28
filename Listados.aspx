<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listados.aspx.cs" Inherits="ObligatorioASPNET.Listados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
        }
        .style12
        {
            height: 23px;
            width: 301px;
        }
        .style13
        {
            width: 205px;
        }
        .style14
        {
            height: 23px;
            width: 205px;
        }
        .style23
        {
            width: 301px;
        }
        .style24
        {
        }
        .style25
        {
            height: 23px;
            width: 10px;
        }
        .style26
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblTituloListados" runat="server" 
            Text="Listado de vehículos disponibles" Font-Bold="True" Font-Size =Large ></asp:Label>
    
    </div>
    <table class="style1">
        <tr>
            <td class="style24">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style24">
                Fecha de Inicio:
                <br />
                <asp:TextBox ID="TBInicioListado" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style13">
                <asp:Calendar ID="CalInicioListado" runat="server" 
                    onselectionchanged="CalInicioListado_SelectionChanged"></asp:Calendar>
            </td>
            <td class="style23" rowspan="3">
                <asp:Label ID="LblListado" runat="server" ForeColor="Blue"></asp:Label>
                <asp:GridView ID="GVDisponiblesListado" runat="server" 
                    onrowdatabound="GVDisponiblesListado_RowDataBound">
            
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style24">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style24">
                Fecha de Fin:<br />
                <asp:TextBox ID="TBFinListado" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:Calendar ID="CalFinListado" runat="server" 
                    onselectionchanged="CalFinListado_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="style25">
            </td>
            <td class="style14">
            </td>
            <td class="style12">
            </td>
        </tr>
        <tr>
            <td class="style24" colspan="2">
                <asp:Label ID="LblErrorListado" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26" colspan="2">
            </td>
            <td class="style12">
            </td>
        </tr>
        <tr>
            <td class="style24" colspan="2">
                <asp:Button ID="BtnVerListado" runat="server" 
                    Text="Ver  Listado de Vehículos disponibles" 
                    onclick="BtnVerListado_Click" />
            </td>
            <td class="style23">
                <asp:Button ID="BtnVolverListado" runat="server" 
                    onclick="BtnVolverListado_Click" Text="Volver al Menú Principal" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
