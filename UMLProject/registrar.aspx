<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="registrar.aspx.cs" Inherits="UMLProject.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">volver</asp:HyperLink>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="registrate para porder hacer pedidos o hacer negcios"></asp:Label>
    <br />
    <br />
    ingrese sus nombres:<br />
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
&nbsp;
    <asp:RequiredFieldValidator ID="validarNombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    ingrese sus apellidos:<br />
    <asp:TextBox ID="txtApellido" runat="server" OnTextChanged="txtApellido_TextChanged"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="validarApe" runat="server" ControlToValidate="txtApellido" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    ingrese su correo
    electronico:<br />
    <asp:TextBox ID="txtCorreo" runat="server" OnTextChanged="txtCorreo_TextChanged"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="validarcorreo" runat="server" ControlToValidate="txtCorreo" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    Debe elegir tipo de cuenta elija cliente para hacer pedidos o cooperativa para buscar contratos de corta
    <br />
    o transporte y hacer negocio con nosotros<br />
    <asp:RadioButtonList ID="radioTipodeCuenta" runat="server" Width="229px">
        <asp:ListItem>Cliente</asp:ListItem>
        <asp:ListItem>Cooperativa</asp:ListItem>
    </asp:RadioButtonList>
    <asp:RequiredFieldValidator ID="validarTipoCuenta" runat="server" ControlToValidate="radioTipodeCuenta" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Nombre de Usuario:<br />
    <asp:TextBox ID="txtNombreDeUsuario" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="validarNombreUsu" runat="server" ControlToValidate="txtApellido" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    Clave:<br />
    <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
&nbsp;
    <asp:RequiredFieldValidator ID="validarclave" runat="server" ControlToValidate="txtClave" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btmRegistrarse" runat="server" OnClick="btmRegistrarse_Click" Text="Registrarse" />
    <br />
    <br />
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <br />

</asp:Content>
