<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Facturar.aspx.cs" Inherits="UMLProject.Facturar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <h2><asp:Label ID="title" runat="server" Text="Crear Pedido"></asp:Label></h2>
    <asp:Label ID="Label1" runat="server" Text="Productos"></asp:Label>
    <asp:DropDownList ID="ddProductos" runat="server"></asp:DropDownList><asp:TextBox ID="txtCantidad" runat="server" Text="1" TextMode="Number" Width="200px"></asp:TextBox>
    <asp:LinkButton ID="btnAdd" runat="server" Text="Agregar Producto" OnClick="btnAdd_Click"></asp:LinkButton>
    <table>
        <thead><tr><th>No</th><th>Producto</th><th>Precio</th><th>Cantidad</th><th>SubTotal</th><th>Edicion</th></tr></thead>
        <tbody runat="server" id="tbody">

        </tbody>
    </table>
    <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click">GUARDAR</asp:LinkButton>
</asp:Content>
