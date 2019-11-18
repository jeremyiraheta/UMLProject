<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cooperativa.aspx.cs" Inherits="UMLProject.Cooperativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <article class="column large-full entry format-standard">
        <h2>Agregar Cooperativa</h2>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
               <label for="name">Nombre</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtZona" runat="server"></asp:TextBox>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
               <label for="zona">Telefono</label>
           </div>
        <div class="row">            
                <label>
                        <asp:RadioButton ID="rbtCorte" runat="server" Checked="true" />
                        <span>Corte</span>
                    </label>
                <label>
                        <asp:RadioButton ID="rbtTransporte" runat="server" />
                        <span>Transporte</span>
                    </label>           
        </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">GUARDAR</a>
        </div>
    </article>
</asp:Content>
