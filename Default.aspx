<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ObligatorioASPNET.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:Label ID="LblTitulo" runat="server" Text="Menú Principal" Font-Bold = "true" Font-Size=X-Large ></asp:Label>
        <br />
    </p>
    <div>
    
        <asp:HyperLink ID="HyperLinkClientes" runat="server" NavigateURL="~/MantenimientoClientes.aspx">Mantenimiento de Clientes</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLinkAutos" runat="server" NavigateUrl="~/MantenimientoAutos.aspx">Mantenimiento de Autos</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLinkUtilitarios" runat="server" NavigateUrl="~/MantenimientoUtilitarios.aspx">Mantenimiento de Utilitarios</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLinkAlquiler" runat="server" 
            NavigateUrl="~/Realizar Alquiler.aspx">Realizar Alquiler</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLinkListado" runat="server" 
            NavigateUrl="~/Listados.aspx">Listado de vehículos disponibles</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLinkTotal" runat="server" 
            NavigateUrl="~/TotalRecaudadoPorVehiculos.aspx">Total recaudado por vehículo</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
