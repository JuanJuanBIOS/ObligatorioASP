<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoAutos.aspx.cs" Inherits="ObligatorioASPNET.MantenimientoAutos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="ltr">
    
        <asp:Label ID="LblInMatriculaAuto" runat="server" 
            Text="Ingrese la matrícula del Auto:"></asp:Label>
        <asp:TextBox ID="TBInMatriculaAutos" runat="server"></asp:TextBox>
        <asp:Label ID="LblErrorAutos" runat="server" ForeColor="Red"></asp:Label>
        <asp:Button ID="BtnBuscarAutos" runat="server" Text="Buscar" />
    
    </div>
    </form>
</body>
</html>
