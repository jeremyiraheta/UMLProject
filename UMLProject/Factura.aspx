<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="UMLProject.Factura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Comprobante</title>
</head>
<body>
    <img src="/imgs/logo.jpg"  width="200px" height="200px" style="display:inline"/><h2>Tiquet</h2>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="output" runat="server"></asp:Literal>
        <div></div>
        <h6>Imprima como comprobante para retirar pedido</h6>
    </div>
    </form>
</body>
</html>
