<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pesaje.aspx.cs" Inherits="UMLProject.Pesaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
     <article class="column large-full entry format-standard" style="padding-left:25%;">
         <h2><asp:Label ID="Label1" runat="server" Text="Agregar Pesaje"></asp:Label></h2>      
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtZona" runat="server" Width="278px"></asp:TextBox>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtHorario" runat="server" Width="278px"></asp:TextBox>
               <label for="horario">Horarios</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtLimite" runat="server" Width="278px"></asp:TextBox>
               <label for="limit_peso">Limite Peso</label>
           </div>
        <div class="row">
            <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click">GUARDAR</asp:LinkButton>
        </div>
    </article>
</asp:Content>
