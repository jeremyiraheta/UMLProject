<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UMLProject.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="row">
           <div class="input-field col s6">
               <input id="user" type="text" class="validate"/>
               <label for="user">Usuario</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="pass" type="password" class="validate"/>
               <label for="pass">Contraseña</label>
           </div>
        </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">INGRESAR</a>
        </div>
    </div>
</asp:Content>
