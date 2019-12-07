<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Transporte.aspx.cs" Inherits="UMLProject.Transporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <article class="column large-full entry format-standard" style="padding-left:25%;">
        <h2><asp:Label ID="title" runat="server" Text="Agregar transporte"></asp:Label></h2>
        
        <div class="input-field col s12 row">
            <asp:Label ID="l1" runat="server">Tipo de transporte</asp:Label>
            <br />
            <asp:DropDownList ID="ddTipo" CssClass="browser-default" runat="server" Width="278px"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddTipo"></asp:RequiredFieldValidator>
            </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtZona" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtZona"></asp:RequiredFieldValidator>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtHorario" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHorario"></asp:RequiredFieldValidator>
               <label for="horario">Horarios</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtLimite" TextMode="Number" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLimite"></asp:RequiredFieldValidator>
               <label for="limit_carga">Limite Carga (KILOS)</label>
           </div>
        <div class="row" id="buttons" runat="server">
           <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOK_Click">GUARDAR</asp:LinkButton>
        </div>
    </article>
</asp:Content>
