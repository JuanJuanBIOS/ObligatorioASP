<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoClientes.aspx.cs" Inherits="ObligatorioASPNET.MantenimientoClientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblInDocumento" runat="server" Text="Ingrese documento:"></asp:Label>
        <asp:TextBox ID="TBInDocumento" runat="server"></asp:TextBox>
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
            onclick="BtnBuscar_Click" />
        <br />
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Nombre:</td>
                <td>
                    <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Tarjeta:</td>
                <td>
                    <asp:TextBox ID="TBTarjeta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Teléfono:</td>
                <td>
                    <asp:TextBox ID="TBTelefono" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Dirección:</td>
                <td>
                    <asp:TextBox ID="TBDireccion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Fecha de Nacimiento:</td>
                <td>
                    <asp:TextBox ID="TBFechaNac" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="BtnCrear" runat="server" Text="Crear" />
                    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" Width="79px" />
                </td>
                <td>
                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" />
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
