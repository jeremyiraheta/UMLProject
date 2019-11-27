<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="UMLProject.Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
     <asp:Literal ID="output" runat="server"></asp:Literal>
     <article class="column large-full entry format-standard" style="padding-left:25%;">
         <h2><asp:Label ID="Label1" runat="server" Text="Agregar Pedido"></asp:Label></h2>      
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtCantidad" runat="server" Width="278px"></asp:TextBox>
               <label for="txtCantidad">Cantidad</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtTotal" runat="server" Width="278px"></asp:TextBox>
               <label for="txtTotal">Total</label>
           </div>
        
        <div class="row">
            <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click">GUARDAR</asp:LinkButton>
        </div>
    </article>
</asp:Content>
