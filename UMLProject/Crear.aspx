<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" ValidateRequest="false" EnableEventValidation="false" Inherits="UMLProject.Crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        const CopyToClipboard = str => {
            const el = document.createElement('textarea');  // Create a <textarea> element
            el.value = str;                                 // Set its value to the string that you want copied
            el.setAttribute('readonly', '');                // Make it readonly to be tamper-proof
            el.style.position = 'absolute';
            el.style.left = '-9999px';                      // Move outside the screen to make it invisible
            document.body.appendChild(el);                  // Append the <textarea> element to the HTML document
            const selected =
              document.getSelection().rangeCount > 0        // Check if there is any content selected previously
                ? document.getSelection().getRangeAt(0)     // Store selection if found
                : false;                                    // Mark as false to know no selection existed before
            el.select();                                    // Select the <textarea> content
            document.execCommand('copy');                   // Copy - only works as a result of a user action (e.g. click events)
            document.body.removeChild(el);                  // Remove the <textarea> element
            if (selected) {                                 // If a selection existed before copying
                document.getSelection().removeAllRanges();    // Unselect everything on the HTML document
                document.getSelection().addRange(selected);   // Restore the original selection
            }
            alert('Copiado al Clipboard' + str);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <div class="container" style="width: 1000px;">
        <h2><asp:Label ID="title" runat="server">Crear Contenidos</asp:Label></h2>
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Titulo:"></asp:Label><br />
            <asp:TextBox ID="txtTitulo" runat="server" Width="375px" CssClass="blue"></asp:TextBox>
            <div class="row" id="buttons" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Contenido:"></asp:Label>
                <asp:TextBox ID="txtContenido" runat="server" Font-Size="Medium" TextMode="MultiLine" CssClass="yellow" Width="864px" Height="179px"></asp:TextBox>
                <asp:LinkButton ID="btnPreview" CssClass="waves-effect waves-light btn-large" runat="server" OnClick="btnPreview_Click">PREVIEW</asp:LinkButton>
                <asp:LinkButton ID="btnOk" CssClass="waves-effect waves-light btn-large btn-flat btn-block" runat="server" OnClick="btnOk_Click">GUARDAR</asp:LinkButton>
            </div>
            <div class="row"><asp:FileUpload ID="upload" Font-Size="Small" Width="200" runat="server" ToolTip="Elija el archivo a subir" AllowMultiple="True" /></div>
            <br />
            <div class="row-top">
                <asp:LinkButton ID="btnSubir" CssClass="waves-effect waves-light btn-large btn-flat btn-block" runat="server" OnClick="btnSubir_Click">SUBIR</asp:LinkButton><asp:LinkButton ID="btnDelete" CssClass="waves-effect waves-light btn-large btn-flat btn-block" runat="server" OnClick="btnDelete_Click">ELIMINAR</asp:LinkButton><asp:HyperLink ID="btnCopys" CssClass="waves-effect waves-light btn-large btn-flat btn-block" runat="server">COPIAR</asp:HyperLink>        
            </div>
            <br />
            <div class="row">
                <asp:ListBox ID="imgs" CssClass="browser-default" Width="400" Height="200" runat="server" OnSelectedIndexChanged="imgs_SelectedIndexChanged" AutoPostBack="true"> </asp:ListBox>      <asp:Image ID="img" Height="200" Width="200" CssClass="" runat="server" />                   
                </div>

        </div>
    </div>
    <div class="row" style="width: 900px; padding-left: 50px;">
        <asp:Literal ID="txtPreview" runat="server"></asp:Literal>
    </div>
</asp:Content>
