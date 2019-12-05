<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UMLProject.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">    
        <asp:Literal ID="output" runat="server"></asp:Literal>
   <article class="column large-full entry format-standard">       
       <h2><asp:Label ID="title" runat="server" Text="Crear Usuario"></asp:Label></h2>       
                    <!--botones texbox-->
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtusername" runat="server" Width="278px"></asp:TextBox><br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Minimo 5 letras, no use letras raras" ForeColor="Red" ControlToValidate="txtusername" ValidationExpression="^(?=.{5,50}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?&lt;![_.])$"></asp:RegularExpressionValidator>
                        <label for="user">Usuario</label>
                    </div>                    
                    <div class="" id="pass" runat="server">
                        <div class="input-field col s6 row">
                        <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtpassword" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                         <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Debe tener almenos 6 caracteres" ForeColor="Red" ControlToValidate="txtpassword" ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
                        <label for="password">Contraseña</label>
                    </div>
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtpassword2" TextMode="Password" runat="server" Width="278px"></asp:TextBox><br /><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtpassword2" ControlToCompare="txtpassword" ErrorMessage="Los password deben coincidir" ForeColor="Red"></asp:CompareValidator>

                        <label for="confirm_password">Confirmar Contraseña</label>
                    </div>
                    </div>                                        
       <asp:DropDownList ID="ddTipo" runat="server" CssClass="browser-default" Width="278px"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddTipo" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <!------------------------------------------------------------------------------------------------------->
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtname" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtname" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <label for="name">Nombre</label>
                    </div>
       <div class="input-field col s6 row">
                        <asp:TextBox ID="txtApellido" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApellido" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <label for="apellido">Apellido</label>
                    </div>
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtdui" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtdui" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="No tiene un formato de DUI valido 00000000-0" ForeColor="Red" ControlToValidate="txtdui" ValidationExpression="^\d{8}-\d$"></asp:RegularExpressionValidator>
                        <label for="txtdui">DUI</label>
                    </div>                    
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtnit" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtnit" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="No tiene un formato de NIT valido 0000-000000-000-0" ForeColor="Red" ControlToValidate="txtnit" ValidationExpression="^[0-9]{4}-[0-9]{6}-[0-9]{3}-[0-9]{1}$"></asp:RegularExpressionValidator>
                        <label for="txtnit">NIT</label>
                    </div>                    
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txttel" runat="server" Width="278px" TextMode="Phone"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txttel" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Numero no valido formato correcto 0000-0000" ForeColor="Red" ControlToValidate="txttel" ValidationExpression="\d{4}[- ]*\d{4}"></asp:RegularExpressionValidator>
                        <label for="txttel">Telefono</label>
                    </div>                    
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtemail" runat="server" Width="278px" TextMode="Email"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtemail" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Mail no valido" ForeColor="Red" ControlToValidate="txtemail" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"></asp:RegularExpressionValidator>
                        <label for="txtemail">Correo Electronico</label>
                    </div>
       <div class="input-field col s6 row">
                        <asp:TextBox ID="txtDireccion" runat="server" Width="281px" TextMode="MultiLine" Height="54px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtDireccion" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <label for="txtDireccion">Direccion</label>
                    </div>
       <div class="input-field col s6 row">
           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           <asp:DropDownList ID="DropDownList1" runat="server">
               <asp:ListItem Selected="True" Value="0">Nombre de Primera Mascota</asp:ListItem>
               <asp:ListItem Value="1">Nombre de pelicula favorita</asp:ListItem>
               <asp:ListItem Value="2">Nombre de pila</asp:ListItem>
               <asp:ListItem Value="3">Palabra secreta</asp:ListItem>
           </asp:DropDownList>
                        <asp:TextBox ID="txtRespuesta" runat="server" Width="281px" TextMode="MultiLine" Height="54px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtRespuesta" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <label for="txtRespuesta">Respuesta Recuperacion</label>
                    </div>
                    <br />
                    <div class="row" id="buttons" runat="server">
                        <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click">REGISTRARSE</asp:LinkButton>
                    </div>
                    </article>   
</asp:Content>
