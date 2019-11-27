<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Transporte.aspx.cs" Inherits="UMLProject.Transporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <article class="column large-full entry format-standard" style="padding-left:25%;">
        <h2><asp:Label ID="Label1" runat="server" Text="Agregar transporte"></asp:Label></h2>
        
        <div class="input-field col s12 row">
            <asp:DropDownList ID="ddTipo" CssClass="browser-default" runat="server" Width="278px"></asp:DropDownList>
            </div>
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
               <label for="limit_carga">Limite Carga</label>
           </div>
        <div class="row">
           <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOK_Click">GUARDAR</asp:LinkButton>
        </div>
    </article>
</asp:Content>
