<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="UMLProject.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <div class="container" style="width:1000px;">
        <h2>Crear Contenidos</h2>
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Titulo:"></asp:Label><br />
        <asp:TextBox ID="txtTitulo" runat="server" Width="375px" CssClass="blue"></asp:TextBox>        
        <div class="row">
            <asp:Label ID="Label2" runat="server" Text="Contenido:"></asp:Label>
        <asp:TextBox ID="txtContenido" runat="server" TextMode="MultiLine" CssClass="yellow" Width="864px" Height="179px"></asp:TextBox>
            <asp:LinkButton ID="btnPreview" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="btnPreview_Click" >PREVIEW</asp:LinkButton>
            <asp:LinkButton ID="btnOk" CssClass="waves-effect waves-light btn-large btn-flat btn-block" runat="server" OnClick="btnOk_Click" >GUARDAR</asp:LinkButton>
    </div>
            <div class="row">
                <asp:ListBox ID="ListBox2" CssClass="browser-default" runat="server"><asp:ListItem>item</asp:ListItem></asp:ListBox>
    </div>
    <div class="row" style="width:900px">
        <asp:Literal ID="txtPreview" runat="server"></asp:Literal>
    </div>
            </div>
        </div>
</asp:Content>
