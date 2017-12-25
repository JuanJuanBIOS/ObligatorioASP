<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoAutos.aspx.cs" Inherits="ObligatorioASPNET.MantenimientoAutos" %>

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
        .style3
        {
            width: 176px;
            height: 26px;
        }
        .style4
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="ltr">

        <asp:Label ID="LblTituloUtilitarios" runat="server" 
                Text="Mantenimiento de Autos" Font-Bold="true" Font-Size =Large ></asp:Label>
            <br />
            <br />
    
    
        <asp:Label ID="LblInMatriculaAutos" runat="server" 
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
                    <asp:TextBox ID="TBMarcaAutos" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Modelo:</td>
                <td>
                    <asp:TextBox ID="TBModeloAutos" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Año:
                </td>
                <td class="style4">
                    <asp:TextBox ID="TBAnioAutos" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Cantidad de puertas:
                </td>
                <td class="style4">
                    <asp:TextBox ID="TBCantPuertasAutos" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Costo diario 
                    (US$):
                </td>
                <td>
                    <asp:TextBox ID="TBCostoDiarioAutos" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Categoría:
                </td>
                <td class="style4">
                    <asp:TextBox ID="TBCategoriaAutos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Tipo de Anclaje:</td>
                <td>
                    <asp:DropDownList ID="DDLTipoAutos" runat="server" Height="23px" Width="147px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Cinturón</asp:ListItem>
                        <asp:ListItem>ISOFIX</asp:ListItem>
                        <asp:ListItem>Latch</asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:Button ID="BtnCrearAutos" runat="server" Text="Crear" Enabled="false" 
                        onclick="BtnCrearAutos_Click"/>
                    <asp:Button ID="BtnModificarAutos" runat="server" Text="Modificar" Enabled="false"
                        onclick="BtnModificarAutos_Click" />
                    <asp:Button ID="BtnConfirmarAutos" runat="server" 
                        Text="Confirmar modificación" Enabled="false" 
                        onclick="BtnConfirmarAutos_Click"/>
                </td>
                <td>
                    <asp:Button ID="BtnEliminarAutos" runat="server" Text="Eliminar" 
                        Enabled="false" onclick="BtnEliminarAutos_Click" />
                    <asp:Button ID="BtnVolverAutos" runat="server" onclick="BtnVolverAuto_Click" 
                        Text="Volver al Menú Principal" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
