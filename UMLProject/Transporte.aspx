<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Transporte.aspx.cs" Inherits="UMLProject.Transporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.dropdown-trigger');
            var instances = M.Dropdown.init(elems, null);
        });
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <article class="column large-full entry format-standard">
        <h2>Agregar transporte</h2>
        <div class="input-field col s12 row">
                <a class='dropdown-trigger btn' href='#' data-target='dropdown1'>Tipo de transporte</a>                    
                    <!-- Dropdown Structure -->
                    <ul id='dropdown1' class='dropdown-content'>
                        <li><a href="#!">Remolque vagones</a></li>
                        <li><a href="#!">Camion</a></li>                        
                        <li><a href="#!">Trailer</a></li>                        
                        <li><a href="#!">Rabones</a></li>
                    </ul>
                    <br />
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
           <asp:HyperLink ID="lOK" CssClass="waves-effect waves-light btn-large" runat="server">GUARDAR</asp:HyperLink>
        </div>
    </article>
</asp:Content>
