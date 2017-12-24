<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Realizar Alquiler.aspx.cs" Inherits="ObligatorioASPNET.Realizar_Alquiler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 88px;
        }
        .style5
        {
            width: 156px;
        }
        .style6
        {
        }
        .style7
        {
            width: 149px;
        }
        .style8
        {
            width: 149px;
            height: 193px;
        }
        .style9
        {
            width: 221px;
            height: 193px;
        }
        .style10
        {
            width: 88px;
            height: 193px;
        }
        .style11
        {
            width: 156px;
            height: 193px;
        }
        .style12
        {
            height: 193px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LBLTituloAlquiler" runat="server" Text="Realizar Alquiler" Font-Bold="true" Font-Size =Large ></asp:Label>
    
        <br />
        <table class="style1">
            <tr>
                <td class="style7">
                    C.I. del Cliente:
                </td>
                <td class="style6">
                    <asp:TextBox ID="TBClienteAlquiler" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    Matrícula del Vehículo:
                </td>
                <td>
                    <asp:TextBox ID="TBMatriculaAlquiler" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    Fecha de Inicio:
                    <asp:TextBox ID="TBInicioAlquiler" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="style9">
                    <asp:Calendar ID="CalInicioAlquiler" runat="server" 
                        onselectionchanged="CalInicioAlquiler_SelectionChanged"></asp:Calendar>
                </td>
                <td class="style10">
                </td>
                <td class="style11">
                    Fecha de fin:
                    <asp:TextBox ID="TBFinAlquiler" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="style12">
                    <asp:Calendar ID="CalFinAlquiler" runat="server" 
                        onselectionchanged="CalFinAlquiler_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6" colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6" colspan="3">
                    <asp:Label ID="LblErrorAlquiler" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="BtnOkAlquiler" runat="server" onclick="BtnOkAlquiler_Click" 
                        Text="Ok" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6" colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Button ID="BtnRealizarAlquiler" runat="server" 
                        onclick="BtnRealizarAlquiler_Click" Text="Realizar Alquiler" />
                </td>
                <td class="style6">
                    <asp:Button ID="BtnConfirmarAlquiler" runat="server" 
                        onclick="BtnConfirmarAlquiler_Click" Text="Confirmar Alquiler" 
                        Enabled="False" />
                </td>
                <td class="style4">
                    <asp:Button ID="BtnCancelarAlquiler" runat="server" Enabled="False" 
                        onclick="BtnCancelarAlquiler_Click" Text="Cancelar Alquiler" />
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnVolverAlquiler" runat="server" 
                        onclick="BtnVolverAlquiler_Click" Text="Volver al Menú Principal" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
