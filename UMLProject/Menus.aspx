<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="UMLProject.Menus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container" style="width: 1000px;">
        <asp:Literal ID="output" runat="server"></asp:Literal>
        <h2>Agregar Menus</h2>
        
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label><span style="width:20px;"> </span>
            <asp:TextBox ID="txtMnombre" runat="server" Width="200"></asp:TextBox><span style="width:20px;"> </span>
            <asp:LinkButton runat="server" ID="btnCrear" CssClass="waves-effect waves-light btn-large" OnClick="btnCrear_Click">Crear</asp:LinkButton>
            <asp:LinkButton runat="server" ID="btnBorrar" CssClass="waves-effect waves-light btn-large" OnClick="btnBorrar_Click" Enabled="false">Eliminar</asp:LinkButton>
            <asp:LinkButton runat="server" ID="btnNuevo" CssClass="waves-effect waves-light btn-large" Enabled="true" OnClick="btnNuevo_Click">Nuevo</asp:LinkButton>
            </div>
        <div class="row">
            <asp:Label ID="Label2" runat="server" Text="Menu " Width="200"></asp:Label><asp:Label ID="Label3" runat="server" Text="SubMenu " Width="200"></asp:Label><asp:Label ID="Label4" runat="server" Text="Articulo " Width="200"></asp:Label>            
        </div>
        <div class="row">
            <asp:ListBox ID="listmenu" CssClass="browser-default" Width="200" Height="200" runat="server" OnSelectedIndexChanged="listmenu_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox><asp:ListBox ID="listsubmenu" CssClass="browser-default" Width="200" Height="200" runat="server" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="listsubmenu_SelectedIndexChanged"></asp:ListBox><asp:ListBox ID="listarticulo" CssClass="browser-default" Width="200" Height="200" runat="server" Enabled="false"></asp:ListBox>
            <asp:LinkButton runat="server" CssClass="waves-effect waves-light btn-small" Enabled="false" ID="btnVincular" OnClick="btnVincular_Click">Vincular</asp:LinkButton>
        </div>
        <div class="row">
            <asp:Label ID="Label5" runat="server" Text="Url especifica:"></asp:Label><asp:TextBox runat="server" ID="url" Width="420px"></asp:TextBox>
        </div>
        <div class ="row">
            <asp:Label runat="server" ID="Lu" Text="Tipos de usuarios"></asp:Label><asp:ListBox ID="listTUsers" CssClass="browser-default" Width="200" Height="200" runat="server" OnSelectedIndexChanged="listTUsers_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox><asp:LinkButton runat="server" Enabled="false" CssClass="waves-effect waves-purple btn-small" ID="btnUsuarioVincular" ToolTip="Vincular menu a un tipo de usuario especifico" OnClick="btnUsuarioVincular_Click">Vincular</asp:LinkButton><asp:LinkButton runat="server" Enabled="false" CssClass="waves-effect waves-purple btn-small" ID="btnDesvincular" ToolTip="Desvincular menu a un tipo de usuario especifico" OnClick="btnDesvincular_Click">Desvincular</asp:LinkButton>
        </div>
        </div>
</asp:Content>
