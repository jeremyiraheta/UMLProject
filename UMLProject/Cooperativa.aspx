<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cooperativa.aspx.cs" Inherits="UMLProject.Cooperativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <article class="column large-full entry format-standard" style="padding-left:25%;">
        <h2><asp:Label ID="Label1" runat="server" Text="Agregar Cooperativa"></asp:Label></h2>        
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtNombre" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
               <label for="name">Nombre</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtZona" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtZona"></asp:RequiredFieldValidator>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtTel" runat="server" Width="278px" TextMode="Phone"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTel"></asp:RequiredFieldValidator>
               <label for="zona">Telefono</label>
           </div>
        <div class="row">            
                <label>
                        <asp:RadioButton ID="rbtCorte" GroupName="g" runat="server" Checked="true" />
                        <span>Corte</span>
                    </label>
                <label>
                        <asp:RadioButton ID="rbtTransporte" GroupName="g" runat="server" />
                        <span>Transporte</span>
                    </label>          
        </div>
        <div class="row" id="buttons" runat="server">
            <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click" >GUARDAR</asp:LinkButton>
        </div>
    </article>
</asp:Content>
