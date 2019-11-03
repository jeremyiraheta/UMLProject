<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Info_Bancaria.aspx.cs" Inherits="UMLProject.Info_Bancaria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="row">
           <div class="input-field col s6">
               <input id="num" type="text" class="validate"/>
               <label for="num">Numero de Tarjeta</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="fecha" type="date" class="validate"/>
               <label for="fecha">Fecha Caducidad</label>
           </div>
            <div class="input-field col s6">
               <input id="code" type="text" class="validate"/>
               <label for="code">Codigo de Seguridad</label>
           </div>
        </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">GUARDAR</a>
        </div>
    </div>
</asp:Content>
