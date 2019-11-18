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
               <asp:TextBox ID="txtZona" runat="server" Width="278px"></asp:TextBox>
               <label for="zona">Zona</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtHorario" runat="server" Width="278px"></asp:TextBox>
               <label for="horario">Horarios</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtLimite" runat="server" Width="278px"></asp:TextBox>
               <label for="limit_peso">Limite Peso</label>
           </div>
        <div class="row">
            <asp:HyperLink ID="lOK" CssClass="waves-effect waves-light btn-large" runat="server">GUARDAR</asp:HyperLink>
        </div>
    </article>
</asp:Content>
