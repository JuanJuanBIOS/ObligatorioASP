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
        <asp:GridView ID="GVAlquileres" runat="server">
            <Columns>
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" 
                    SortExpression="Cliente" />
                <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate>
                <%#Eval ("Cliente.Cedula") %>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>

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
