<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Transporte.aspx.cs" Inherits="UMLProject.Transporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="row">
            <div class="input-field col s12">
                <select>
                    <option value="" disabled selected>Choose your option</option>
                    <option value="1">Option 1</option>
                    <option value="2">Option 2</option>
                    <option value="3">Option 3</option>
                </select>
                <label>Seleccione tipo de transporte</label>
            </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="zona" type="text" class="validate"/>
               <label for="zona">Zona</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="horario" type="text" class="validate"/>
               <label for="horario">Horarios</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="limit_carga" type="text" class="validate"/>
               <label for="limit_carga">Limite Carga</label>
           </div>
        </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">GUARDAR</a>
        </div>
    </div>
</asp:Content>
