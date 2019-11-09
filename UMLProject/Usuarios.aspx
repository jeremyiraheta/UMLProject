<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UMLProject.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.dropdown-trigger');
            var instances = M.Dropdown.init(elems, null);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <article class="s-content">

        <div class="masonry-wrap">

            <div class="masonry" style="position: relative; right:100%; height: 5388.88px;">
                <article class="column large-full entry format-standard">
                    <!--botones texbox-->
                    <div class="input-field col s6">
                        <input id="user" type="text" class="validate" />
                        <label for="user">Usuario</label>
                    </div>
                    <br />
                    <div class="input-field col s6">
                        <input id="password" type="password" class="validate" />
                        <label for="password">Contraseña</label>
                    </div>
                    <br />
                    <div class="input-field col s6">
                        <input id="confirm_password" type="password" class="validate" />
                        <label for="confirm_password">Confirmar Contraseña</label>
                    </div>
                    <br />
                    <!--Falta dropdown-->
                    <a class='dropdown-trigger btn' href='#' data-target='dropdown1'>Tipo de cuenta</a>

                    <!-- Dropdown Structure -->
                    <ul id='dropdown1' class='dropdown-content'>
                        <li><a href="#!">Cliente</a></li>
                        <li><a href="#!">Cooperativa</a></li>                        
                        <li><a href="#!">Ingenio</a></li>                        
                    </ul>
                    <br />
                    <!------------------------------------------------------------------------------------------------------->
                    <div class="input-field col s6">
                        <input id="name" type="text" class="validate" />
                        <label for="name">Nombre</label>
                    </div>
                    <div class="input-field col s6">
                        <input id="dui" type="text" class="validate" />
                        <label for="dui">DUI</label>
                    </div>
                    <br />
                    <div class="input-field col s6">
                        <input id="nit" type="text" class="validate" />
                        <label for="nit">NIT</label>
                    </div>
                    <br />
                    <div class="input-field col s6">
                        <input id="tel" type="tel" class="validate" />
                        <label for="tel">Telefono</label>
                    </div>
                    <br />
                    <div class="input-field col s6">
                        <input id="email" type="email" class="validate" />
                        <label for="email">Correo Electronico</label>
                    </div>
                    <br />
                    <a class="waves-effect waves-light btn-large">REGISTRARSE</a>
                </div>
            
            </div>
        </article>
    </div>
</asp:Content>
