<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio201.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 563px; width: 400px">
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Número con tabla de multiplicar hasta el 25"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Ingrese un número"></asp:Label>
            :
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEjecutar" runat="server" OnClick="btnEjecutar_Click" Text="Ejecutar" />
            <br />
            <br />
            <asp:ListBox ID="lbTabla" runat="server" Height="451px"></asp:ListBox>
        </div>
    </form>
</body>
</html>
