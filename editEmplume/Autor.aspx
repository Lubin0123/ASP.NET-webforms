<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Autor.aspx.vb" Inherits="Autor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title style="font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Datos autor </title>
    <style>
        .container{
            width: 400px;
            margin: 40px;
            padding: 30px;
            background-color: #fff;
            box-shadow: 0 4px 20px rgba(0,0,0,0.1);
            border-radius: 12px;
            font-family: 'Segoe UI', sans-serif;
            display:flex;
            flex-direction:column;
        }
        .LlblMessage{
            color:blue;
            font-size:14px;
            margin-top: -10px;
        }
        .LlblError{
            color:red;
            font-size:14px;
            margin-top: -10px
        }
        
    </style>
</head>
<body>
    <form class="container" runat="server">
        <div  class="container" ="height: 500px">
            <asp:Label ID="lblNomAutor" runat="server" Text=" Nombre:"></asp:Label>
            <asp:TextBox ID="txtNomAutor" runat="server"></asp:TextBox>

            <br />
            <asp:Label ID="lblApelliAutor" runat="server" Text=" Apellido:"></asp:Label>
            <asp:TextBox ID="txtApelliAutor" runat="server"></asp:TextBox>
            <br />

            <br />     
            <asp:TextBox ID="txtFechaNaci" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:ImageButton ID="btnCalendario" runat="server" ImageUrl="~/imgs/calendar-check.svg" Width="23px" Height="24px"/>
            <asp:Panel ID="pnlCalendario" runat="server" Visible="False">
                <div>
                </div>
                <asp:Calendar ID="calFechaNac" runat="server" OnSelectionChanged="calFechaNac_SelectionChanged" />
            </asp:Panel>

            <br />
            <asp:Label ID="lblBiografria" runat="server" Text="Biografia:"></asp:Label>
            <asp:TextBox ID="txtBiografia" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCrearAutor" runat="server" Text="Crear Autor"/>


            <asp:Label ID="LlblMessage" runat="server" CssClass="mensaje"></asp:Label>
            <asp:Label ID="LblError" runat="server" CssClass="mensajeAdvertencia"></asp:Label>

        </div>
        <div>
            <asp:GridView ID="GwAutor" runat="server" Width="346px" DataSourceID="SqlAutor">
            </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlAutor" runat="server"></asp:SqlDataSource>
        
        
    </form>
</body>
</html>


