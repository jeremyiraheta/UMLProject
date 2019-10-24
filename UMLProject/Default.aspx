<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UMLProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <header>

        Bienvenidos&nbsp; <asp:HyperLink ID="HyperLink1" runat="server" style="text-align: center; background-color: #FFFFFF;" NavigateUrl="~/login.aspx">iniciar sesion </asp:HyperLink>
&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/registrar.aspx">Registrarse</asp:HyperLink>

    </header>
    <p>
    esta es la pagina de inicio</p>
</asp:Content>
