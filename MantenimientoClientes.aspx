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
    
        <asp:Label ID="LblTituloClientes" runat="server" 
            Text="Mantenimiento de Clientes" Font-Bold="True" Font-Size =Large ></asp:Label>
        <br />
    
        <asp:Label ID="LblInDocumento" runat="server" Text="Ingrese documento:"></asp:Label>
        <asp:TextBox ID="TBInDocumento" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscarClientes" runat="server" Text="Buscar" 
            onclick="BtnBuscar_Click" />
        <br />
        <br />
        <asp:Label ID="LblErrorClientes" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Nombre:</td>
                <td>
                    <asp:TextBox ID="TBNombreClientes" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Tarjeta:</td>
                <td>
                    <asp:TextBox ID="TBTarjetaClientes" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Teléfono:</td>
                <td>
                    <asp:TextBox ID="TBTelefonoClientes" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Dirección:</td>
                <td>
                    <asp:TextBox ID="TBDireccionClientes" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Fecha de Nacimiento:</td>
                <td>
                    <asp:TextBox ID="TBFechaNacClientes" runat="server"></asp:TextBox>
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
                    <asp:Button ID="BtnCrearClientes" runat="server" Text="Crear" />
                    <asp:Button ID="BtnModificarClientes" runat="server" Text="Modificar" Width="79px" 
                        onclick="BtnModificarClientes_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnEliminarClientes" runat="server" Text="Eliminar" 
                        onclick="BtnEliminarClientes_Click" />
                    <asp:Button ID="BtnVolverClientes" runat="server" onclick="BtnVolver_Click" 
                        Text="Volver al Menú Principal" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="BtnConfirmarClientes" runat="server" 
                        Text="Confirmar modificación" Enabled="false" 
                        onclick="BtnConfirmarClientes_Click"/>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
