﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoUtilitarios.aspx.cs" Inherits="ObligatorioASPNET.MantenimientoUtilitarios" %>

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
            width: 189px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblInMatriculaUtilitarios" runat="server" 
            Text="Ingrese la matrícula: "></asp:Label>
        <asp:TextBox ID="TBInMatriculaUtilitarios" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscarUtilitarios" runat="server" Text="Buscar" 
            onclick="BtnBuscarUtilitario_Click1" />
        <br />
        <br />
        <asp:Label ID="LblErrorUtilitarios" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Marca:</td>
                <td>
                    <asp:TextBox ID="TBMarcaUtilitarios" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Modelo:</td>
                <td>
                    <asp:TextBox ID="TBModeloUtilitarios" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Año: 
                </td>
                <td>
                    <asp:TextBox ID="TBAnioUtilitarios" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                   Cantidad de puertas:
                </td>
                <td>
                    <asp:TextBox ID="TBCantPuertasUtilitarios" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Costo diario:
                </td>
                <td>
                    <asp:TextBox ID="TBCostoDiarioUtilitarios" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Categoría:
                </td>
                <td>
                    <asp:TextBox ID="TBCategoriaUtilitarios" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Capacidad:
                </td>
                <td>
                    <asp:TextBox ID="TBCapacidadUtilitarios" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Tipo:
                </td>
                <td>
                    <asp:TextBox ID="TBTipoUtilitarios" runat="server"></asp:TextBox>
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
                    <asp:Button ID="BtnCrearUtilitarios" runat="server" Text="Crear" 
                        Enabled="false" onclick="BtnCrearUtilitarios_Click1"/>
                    <asp:Button ID="BtnModificarUtilitarios" runat="server" Text="Modificar" 
                        Enabled="false" onclick="BtnModificarUtilitarios_Click"/>
                    <asp:Button ID="BtnConfirmarUtilitarios" runat="server" 
                        Text="Confirmar modificación" Enabled="false"/>
                </td>
                <td>
                    <asp:Button ID="BtnEliminarUtilitarios" runat="server" Text="Eliminar" 
                        Enabled="false"/>
                    <asp:Button ID="BtnVolverUtilitarios" runat="server" 
                        onclick="BtnVolverUtilitario_Click" Text="Volver al Menú Principal" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
