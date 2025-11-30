<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio203.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 241px;
            width: 414px;
        }
    </style>
</head>
<body style="height: 560px">
    <form id="frmProductos" runat="server">
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="tsbNuevo" runat="server" Height="20px" ImageUrl="~/img/nuevo.png" OnClick="tsbNuevo_Click" Width="20px" />
&nbsp;<asp:ImageButton ID="tsbGuardar" runat="server" Height="20px" ImageUrl="~/img/guardar.png" OnClick="tsbGuardar_Click" Width="20px" />
&nbsp;<asp:ImageButton ID="tsbCancelar" runat="server" Height="20px" ImageUrl="~/img/cancelar.png" OnClick="tsbCancelar_Click" Width="20px" />
&nbsp;<asp:ImageButton ID="tsbEliminar" runat="server" Height="20px" ImageUrl="~/img/eliminar.png" OnClick="tsbEliminar_Click" Width="20px" />
&nbsp;Buscar por id:
        <asp:TextBox ID="tstId" runat="server"></asp:TextBox>
&nbsp;<asp:ImageButton ID="tsbBuscar" runat="server" Height="20px" ImageUrl="~/img/buscar.png" OnClick="tsbBuscar_Click" Width="20px" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp; id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nombre<br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp; Precio&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Stock<br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSalir" runat="server" OnClick="btnSalir_Click" Text="SALIR" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    </form>
</body></html>