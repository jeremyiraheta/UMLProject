<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GCooperativas.aspx.cs" Inherits="UMLProject.GCooperativas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h2>Gestion de Cooperativas</h2>
    <asp:Literal ID="cooperativas" runat="server"></asp:Literal>
    <hr />
    <h6>Gestion de Cooperativas de Corta</h6>
    <asp:Literal ID="corta" runat="server"></asp:Literal>
    <hr />
    <h6>Gestion de Cooperativas de Transporte</h6>
    <asp:Literal ID="transporte" runat="server"></asp:Literal>
    
</asp:Content>
