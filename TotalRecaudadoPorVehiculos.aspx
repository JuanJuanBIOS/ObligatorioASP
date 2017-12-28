<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TotalRecaudadoPorVehiculos.aspx.cs" Inherits="ObligatorioASPNET.TotalRecaudadoPorVehiculos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblTituloTotalRec" runat="server" 
            Text="Total Recaudado por Vehículo" Font-Bold="True" Font-Size =Large ></asp:Label>
        <br />
        <br />
    
        <asp:Label ID="LblInMatriculaTot" runat="server" 
            Text="Ingrese la matrícula: "></asp:Label>
        <asp:TextBox ID="TBInMatriculaTot" runat="server" Width="128px"></asp:TextBox>
        <asp:Button ID="BtnTotal" runat="server" Text="Total" 
            onclick="BtnTotal_Click" />
        <br />
        <br />
                    <asp:Button ID="BtnVolverUtilitarios" runat="server" 
                        onclick="BtnVolverUtilitario_Click" Text="Volver al Menú Principal" />
                <br />
        <br />
        <asp:Label ID="LblErrorTot" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LblTotalVehiculo" runat="server" Text="Total del Vehículo:"></asp:Label>
&nbsp;<asp:Label ID="LblTotal" runat="server" Font-Bold="True"></asp:Label>
        <br />
        <br />
<<<<<<< HEAD
        <asp:GridView ID="GVAlquileres" runat="server" AutoGenerateColumns = "false" >
        
=======
        <asp:GridView ID="GVAlquileres" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="GVAlquileres_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Cliente.Cedula" HeaderText="Cliente" />
                <asp:BoundField DataField="Vehiculo.Matricula" HeaderText="Matrícula" />
                <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" 
                    HeaderText="Fecha Inicio" />
                <asp:BoundField DataField="FechaFin" DataFormatString="{0:d}" 
                    HeaderText="Fecha Fin" />
                <asp:BoundField DataField="Costo" HeaderText="Costo" />
            </Columns>
>>>>>>> 599123f54b59b8ba6153558076e47da0f19ab414

        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
