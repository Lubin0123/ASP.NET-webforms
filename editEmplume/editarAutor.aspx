<%@ Page Language="VB" AutoEventWireup="false" CodeFile="editarAutor.aspx.vb" Inherits="editarAutor" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .container{
            width: 600px;
            margin: 85px;
            margin-top: 3px;
            padding: 10px;
            background-color: #fff;
            font-family: 'Segoe UI', sans-serif;
            display:flex;
            flex-direction:column;
        }
        .imgFecha{
            margin-left:150px;
        }
        .btnRedPag {
            position: absolute;
            top: 10px;
            right: 10px;
            background-color: #007bff;
            color: white;
            padding: 8px 16px;
            border: none;
            border-radius: 4px;
            margin-right: -120px;
            margin-top: -270px;

        }
    </style>
</head>
<body>
    <div class="container" style="height:500px">
        <form class="container" runat="server">
            <asp:HiddenField ID="hdnIdAutor" runat="server" Value="idAutor" />
            <asp:Label ID="lblNomAutor" runat="server" Text=" Nombre:" Style="font-weight: bold; font-size: 16px; color: #333;
                margin-left:150px;">
            </asp:Label>
            <asp:TextBox ID="txtNomAutor"  style="width:300px; margin-left:auto; margin-right:auto; display:block;" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblApelliAutor" runat="server" Text=" Apellido:" Style="font-weight: bold; font-size: 16px; color: #333;
                margin-left:150px;">
            </asp:Label>
            <asp:TextBox ID="txtApelliAutor" style="width:300px; margin-left:auto; margin-right:auto; display:block;" runat="server"></asp:TextBox>
            <br />
            <div class="imgFecha">
            <asp:ImageButton ID="btnCalendario" runat="server" ImageUrl="~/imgs/calendar-check.svg" Width="23px" Height="24px"/>
            </div>
            <asp:TextBox ID="txtFechaNaci" style="width:300px; margin-left:auto; margin-right:auto; display:block;" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Panel ID="pnlCalendario" runat="server" Visible="False">
                <asp:Calendar ID="calFechaNacimient" runat="server" OnSelectionChanged="calFechaNacimient_SelectionChanged" />
            </asp:Panel>

            <br />
            <asp:Label ID="lblBiografria" runat="server" Text="Biografia:" Style="font-weight: bold; font-size: 16px; color: #333;
                margin-left:150px;">
            </asp:Label>
            <asp:TextBox ID="txtBiografia" style="width:300px; margin-left:auto; margin-right:auto; display:block;" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCrearAutor" style="width:300px; margin-left:auto; margin-right:auto; display:block;
            background-color: #28a745;" runat="server" Text="Crear Autor"/>
            <div style="position:relative;">
                <asp:Button ID="btnRegPag" runat="server" CssClass="btnRedPag" Text="Pagina Principal" />
            </div>

            <asp:DropDownList ID="dropAutores" runat="server" DataSourceID="sqlAutores" AutoPostBack="true">
                <asp:ListItem Value="nombreAutor"></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="sqlAutores" runat="server" />
            <asp:Label ID="LlblMessage" runat="server" CssClass="mensaje"></asp:Label>
            <asp:Label ID="LblError" runat="server" CssClass="mensajeAdvertencia"></asp:Label>
        </form>
    </div>
</body>
</html>
