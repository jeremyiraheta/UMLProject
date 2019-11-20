<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Corta.aspx.cs" Inherits="UMLProject.Corta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <article class="column large-full entry format-standard">
        <h2>Agregar Corta</h2>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtZona" runat="server" Width="278px"></asp:TextBox>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtCantidad" runat="server" Width="278px"></asp:TextBox>
               <label for="cantidad">Cantidad Maxima</label>
           </div>
        
        <div class="row">
            <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click">GUARDAR</asp:LinkButton>
        </div>
    </article>
</asp:Content>
