<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UMLProject.login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">


    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">volver</asp:HyperLink>
    <br />
    <br />
    Nombre de Usuario:
    <br />
    <asp:TextBox ID="txtNombreU" runat="server" OnTextChanged="txtNombreU_TextChanged"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validarNombreUsu" runat="server" ControlToValidate="txtNombreU" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Clave:<br />
    <asp:TextBox ID="txtClave" runat="server" OnTextChanged="txtClave_TextChanged"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validarNombreUsu0" runat="server" ControlToValidate="txtClave" Display="Dynamic" ErrorMessage="rellene este campo" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btnIniciar" runat="server" OnClick="btnIniciar_Click" Text="Iniciar sesion" />
&nbsp;&nbsp;
    <br />
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <br />
    <br />


</asp:Content>
