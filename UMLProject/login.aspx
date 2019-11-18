<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UMLProject.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="content__page">
        <div class="input-field col s6 row">
            <h2>Inicio de session</h2></div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtusername" runat="server" Width="278px"></asp:TextBox>
               <label for="user">Usuario</label>
           </div>
        <div class="input-field col s6 row">
               <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" Width="278px"></asp:TextBox>
               <label for="pass">Contraseña</label>
           </div>
        <div class="row" style="margin:0px 0px 0px 50%;">
            <asp:LinkButton ID="lOKs" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="lOK_Click">LOGIN</asp:LinkButton>
        </div>
    </div>
</asp:Content>
