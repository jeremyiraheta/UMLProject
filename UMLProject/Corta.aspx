<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Corta.aspx.cs" Inherits="UMLProject.Corta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="row">
           <div class="input-field col s6">
               <input id="zona" type="text" class="validate"/>
               <label for="zona">Zona</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="cantidad" type="text" class="validate"/>
               <label for="cantidad">Cantidad Maxima</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="precio" type="text" class="validate"/>
               <label for="precio">Precio</label>
           </div>
        </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">GUARDAR</a>
        </div>
    </div>
</asp:Content>
