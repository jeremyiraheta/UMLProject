<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pesaje.aspx.cs" Inherits="UMLProject.Pesaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
     <article class="column large-full entry format-standard">
         <h2>Agregar Pesaje</h2>
        <div class="input-field col s12 row">
                <a class='dropdown-trigger btn' href='#' data-target='dropdown1'>Tipo de pesa</a>                    
                    <!-- Dropdown Structure -->
                    <ul id='dropdown1' class='dropdown-content'>
                        <li><a href="#!">T1</a></li>
                        <li><a href="#!">T2</a></li>                        
                        <li><a href="#!">T3</a></li>                        
                        <li><a href="#!">T4</a></li>
                    </ul>
                    <br />
            </div>
        <div class="input-field col s6 row">
               <input id="zona" type="text" class="validate"/>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <input id="horario" type="text" class="validate"/>
               <label for="horario">Horarios</label>
           </div>
        <div class="input-field col s6 row">
               <input id="limit_peso" type="text" class="validate"/>
               <label for="limit_peso">Limite Peso</label>
           </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">GUARDAR</a>
        </div>
    </article>
</asp:Content>
