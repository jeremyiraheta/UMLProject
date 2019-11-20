<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contenido.aspx.cs" Inherits="UMLProject.Contenido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row section-intro add-bottom">

                        <div class="column large-full" style="width:1000px;">

                            <h1 class="display-1" style="text-align:center;width:900px">
                                <asp:Literal ID="txtTitulo" runat="server"></asp:Literal></h1>

                            <p class="lead" style="width:900px;">
                                <asp:Literal ID="txtContenido" runat="server"></asp:Literal>
                            </p>

                        </div>

                    </div>
</asp:Content>
