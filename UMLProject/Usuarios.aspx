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
   <article class="column large-full entry format-standard">

       <h2>Crear Usuario</h2>
                    <!--botones texbox-->
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtusername" runat="server" Width="278px"></asp:TextBox>
                        <label for="user">Usuario</label>
                    </div>                    
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" Width="278px"></asp:TextBox>
                        <label for="password">Contraseña</label>
                    </div>
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtpassword2" TextMode="Password" runat="server" Width="278px"></asp:TextBox>
                        <label for="confirm_password">Confirmar Contraseña</label>
                    </div>                    
                    <!--Falta dropdown-->
                    <a class='dropdown-trigger btn' href='#' data-target='dropdown1'>Tipo de cuenta</a>                    
                    <!-- Dropdown Structure -->
                    <ul id='dropdown1' class='dropdown-content'>
                        <li><a href="#!">Cliente</a></li>
                        <li><a href="#!">Cooperativa</a></li>                                             
                    </ul>
                    <br />
                    <!------------------------------------------------------------------------------------------------------->
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtname" runat="server" Width="278px"></asp:TextBox>
                        <label for="name">Nombre</label>
                    </div>
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtdui" runat="server" Width="278px"></asp:TextBox>
                        <label for="dui">DUI</label>
                    </div>                    
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtnit" runat="server" Width="278px"></asp:TextBox>
                        <label for="nit">NIT</label>
                    </div>                    
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txttel" runat="server" Width="278px"></asp:TextBox>
                        <label for="tel">Telefono</label>
                    </div>                    
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtemail" runat="server" Width="278px"></asp:TextBox>
                        <label for="email">Correo Electronico</label>
                    </div>
                    <br />
                    <asp:HyperLink ID="lOK" CssClass="waves-effect waves-light btn-large" runat="server">REGISTRARSE</asp:HyperLink>
                    </article>    
</asp:Content>
