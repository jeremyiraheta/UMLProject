<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DoQuery.aspx.cs" Inherits="UMLProject.DoQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h1>Hacer Petiticiones a la Base de Datos</h1>
    <asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine" BackColor="Yellow"></asp:TextBox>
    <asp:Button ID="btnDo" runat="server" Text="Ejecutar" OnClick="btnDo_Click" />
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <asp:GridView ID="gridoutput" runat="server"></asp:GridView>
</asp:Content>
