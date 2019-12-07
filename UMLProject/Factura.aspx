<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="UMLProject.Factura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Comprobante</title>
</head>
<body>
    <div style="border-style:dashed;border-width:2px;width:300px;">
    <img src="/imgs/logo.jpg"  width="200px" height="200px" style="display:inline"/><h2>Tiquet</h2>
    <form id="form1" runat="server">
    
        <asp:Literal ID="output" runat="server"></asp:Literal>                  
    </form>
    </div>
    <h6><a href="#" onclick="window.print()" name="Click para imprimir">Imprima</a> como comprobante para retirar pedido</h6>    
</body>
</html>
