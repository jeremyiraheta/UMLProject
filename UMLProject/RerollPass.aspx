<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RerollPass.aspx.cs" Inherits="UMLProject.RerollPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <div class="input-field col s6 row" id="recover" runat="server">
           <asp:Label ID="Label1" runat="server" Text="Seleccione la pregunta de recuperacion"></asp:Label>
           <asp:DropDownList ID="ddpregunta" CssClass="browser-default" Width="400px"  runat="server">
               <asp:ListItem Selected="True" Value="0">Nombre de Primera Mascota?</asp:ListItem>
               <asp:ListItem Value="1">Nombre de pelicula favorita?</asp:ListItem>
               <asp:ListItem Value="2">Nombre de pila?</asp:ListItem>
               <asp:ListItem Value="3">Palabra secreta?</asp:ListItem>
           </asp:DropDownList>
                        <asp:TextBox ID="txtRespuesta" runat="server" Width="281px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtRespuesta" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <label for="txtRespuesta">Respuesta Recuperacion</label>
                    </div>
    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" Width="278px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtpassword" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                         <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Debe tener almenos 6 caracteres" ForeColor="Red" ControlToValidate="txtpassword" ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
                        <label for="password">Contraseña</label>
                    </div>
                    <div class="input-field col s6 row">
                        <asp:TextBox ID="txtpassword2" TextMode="Password" runat="server" Width="278px"></asp:TextBox><br /><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtpassword2" ControlToCompare="txtpassword" ErrorMessage="Los password deben coincidir" ForeColor="Red"></asp:CompareValidator>

                        <label for="confirm_password">Confirmar Contraseña</label>
                    </div>
    <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOKs_Click">RECUPERAR</asp:LinkButton>
</asp:Content>
