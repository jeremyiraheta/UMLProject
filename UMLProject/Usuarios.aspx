<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UMLProject.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    
    <div class="container">
        <!--botones texbox-->
        <div class="row">
           <div class="input-field col s6">
               <input id="user" type="text" class="validate"/>
               <label for="user">Usuario</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="password" type="password" class="validate"/>
               <label for="password">Contraseña</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="confirm_password" type="password" class="validate"/>
               <label for="confirm_password">Confirmar Contraseña</label>
           </div>
        </div>
        <!--Falta dropdown-->
        <div class="row">
            <div class="input-field col s12">
                <select>
                    <option value="" disabled selected>Choose your option</option>
                    <option value="1">Option 1</option>
                    <option value="2">Option 2</option>
                    <option value="3">Option 3</option>
                </select>
                <label>Seleccione tipo de cuenta</label>
            </div>
        </div>
        <!------------------------------------------------------------------------------------------------------->
        <div class="row">
            <div class="input-field col s6">
               <input id="name" type="text" class="validate"/>
               <label for="name">Nombre</label>
           </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
               <input id="dui" type="text" class="validate"/>
               <label for="dui">DUI</label>
           </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
               <input id="nit" type="text" class="validate"/>
               <label for="nit">NIT</label>
           </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
               <input id="tel" type="tel" class="validate"/>
               <label for="tel">Telefono</label>
           </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
               <input id="email" type="email" class="validate"/>
               <label for="email">Correo Electronico</label>
           </div>
        </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">REGISTRARSE</a>
        </div>
    </div>
</asp:Content>
