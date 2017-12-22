<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoUtilitarios.aspx.cs" Inherits="ObligatorioASPNET.MantenimientoUtilitarios" %>

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
    
        <asp:Label ID="LblInMatriculaUtilitario" runat="server" 
            Text="Ingrese la matrícula: "></asp:Label>
        <asp:TextBox ID="TBInMatriculaUtilitario" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscarUtilitario" runat="server" Text="Buscar" 
            onclick="BtnBuscarUtilitario_Click1" />
        <br />
        <br />
        <asp:Label ID="LblErrorUtilitario" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Marca:</td>
                <td>
                    <asp:TextBox ID="TBMarcaUtilitario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Modelo:</td>
                <td>
                    <asp:TextBox ID="TBModeloUtilitario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Año: 
                </td>
                <td>
                    <asp:TextBox ID="TBAnioUtilitario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                   Cantidad de puertas:
                </td>
                <td>
                    <asp:TextBox ID="TBCantPuertasUtilitario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Costo diario:
                </td>
                <td>
                    <asp:TextBox ID="TBCostoDiarioUtilitario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Categoría:
                </td>
                <td>
                    <asp:TextBox ID="TBCategoriaUtilitario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Capacidad:
                </td>
                <td>
                    <asp:TextBox ID="TBCapacidadUtilitario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Tipo:
                </td>
                <td>
                    <asp:TextBox ID="TBTipoUtilitario" runat="server"></asp:TextBox>
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
                    <asp:Button ID="BtnCrearUtilitario" runat="server" Text="Crear" />
                    <asp:Button ID="BtnModificarUtilitario" runat="server" Text="Modificar" />
                </td>
                <td>
                    <asp:Button ID="BtnEliminarUtilitario" runat="server" Text="Eliminar" />
                    <asp:Button ID="BtnVolverUtilitario" runat="server" 
                        onclick="BtnVolverUtilitario_Click" Text="Volver al Menú Principal" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
