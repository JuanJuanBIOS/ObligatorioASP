﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoAutos.aspx.cs" Inherits="ObligatorioASPNET.MantenimientoAutos" %>

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
            width: 176px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="ltr">
    
    
        <asp:Label ID="LblInMatriculaAuto" runat="server" 
            Text="Ingrese la matrícula: "></asp:Label>
        <asp:TextBox ID="TBInMatriculaAutos" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscarAutos" runat="server" Text="Buscar" 
                        onclick="BtnBuscarAutos_Click" />
    
                    <br />
                    <br />
        <asp:Label ID="LblErrorAutos" runat="server" ForeColor="Red"></asp:Label>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style2">
                                Marca:</td>
                <td>
                    <asp:TextBox ID="TBMarcaAutos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Modelo:</td>
                <td>
                    <asp:TextBox ID="TBModeloAutos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Año:
                </td>
                <td>
                    <asp:TextBox ID="TBAnioAutos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Cantidad de puertas:
                </td>
                <td>
                    <asp:TextBox ID="TBCantPuertasAutos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Costo diario:
                </td>
                <td>
                    <asp:TextBox ID="TBCostoDiarioAutos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Categoría:
                </td>
                <td>
                    <asp:TextBox ID="TBCategoriaAutos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Tipo de Anclaje:</td>
                <td>
                    <asp:TextBox ID="TBTipoAutos" runat="server"></asp:TextBox>
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
                    <asp:Button ID="BtnCrearAutos" runat="server" Text="Crear" />
                    <asp:Button ID="BtnModificarAutos" runat="server" Text="Modificar" />
                </td>
                <td>
                    <asp:Button ID="BtnEliminarAutos" runat="server" Text="Eliminar" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
