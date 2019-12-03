<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Corta.aspx.cs" Inherits="UMLProject.Corta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <article class="column large-full entry format-standard">
        <h2><asp:Label ID="title" runat="server" Text="Agregar Corta"></asp:Label></h2>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtZona" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtZona"></asp:RequiredFieldValidator>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtCantidad" runat="server" Width="278px" TextMode="Number"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCantidad"></asp:RequiredFieldValidator>
               <label for="cantidad">Cantidad Maxima</label>
           </div>
        
        <div class="row" id="buttons" runat="server">
            <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click">GUARDAR</asp:LinkButton>
        </div>
    </article>
</asp:Content>
