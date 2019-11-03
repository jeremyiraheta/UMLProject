<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cooperativa.aspx.cs" Inherits="UMLProject.Cooperativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="row">
            <div class="input-field col s6">
               <input id="name" type="text" class="validate"/>
               <label for="name">Nombre</label>
           </div>
        </div>
        <div class="row">
           <div class="input-field col s6">
               <input id="zona" type="text" class="validate"/>
               <label for="zona">Zona</label>
           </div>
        </div>
        <div class="row">
            <form action="#">
                <p>
                    <label>
                        <input name="group1" type="radio" checked />
                        <span>Corte</span>
                    </label>
                </p>
                <p>
                    <label>
                        <input name="group1" type="radio" />
                        <span>Transporte</span>
                    </label>
                </p>
            </form>
        </div>
        <div class="row">
            <a class="waves-effect waves-light btn-large">GUARDAR</a>
        </div>
    </div>
</asp:Content>
