﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Autor.aspx.vb" Inherits="Autor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title style="font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Datos autor </title>
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
        .GwAutor{
            margin-top: 10px;
            display:flex;
            justify-content:center;
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

        .imgFecha{
            margin-left:150px;
            
        }
   
        
    </style>
</head>
<body>
    <div  class="container" style="height:500px">
        <form class="container" runat="server">
            <asp:Label ID="lblNomAutor" runat="server" Text=" Nombre:" Style="font-weight: bold; font-size: 16px; color: #333;
                margin-left:150px;"
            ></asp:Label>
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
            <asp:Calendar ID="calFechaNac" runat="server" OnSelectionChanged="calFechaNac_SelectionChanged" /></asp:Panel>
            <br />
            <asp:Label ID="lblBiografria" runat="server" Text="Biografia:" Style="font-weight: bold; font-size: 16px; color: #333;
                margin-left:150px;">
            </asp:Label>
            <asp:TextBox ID="txtBiografia" style="width:300px; margin-left:auto; margin-right:auto; display:block;" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCrearAutor" style="width:300px; margin-left:auto; margin-right:auto; display:block;
            background-color: #28a745;" runat="server" Text="Crear Autor"/>

            <asp:DropDownList ID="DropUpdateAutor" style="margin-left:150px; margin-right:auto; display:block; margin-top: 3px;" runat="server" DataTextField="Editar Autor"
                CssClass="form-select form-select-lg mb-3" AutoPostBack="true" OnSelectedIndexChanged="DropUpdateAutor_SelectedIndexChanged"
            >
            <asp:ListItem Text="-- Seleccione acción --" Value="" Selected="True" />
             <asp:ListItem Text="Editar Autor"   Value="Editar" />
            <asp:ListItem Text="Eliminar Autor" Value="Eliminar" />
            </asp:DropDownList>
            <br />

            <asp:Label ID="LlblMessage" runat="server" CssClass="mensaje"></asp:Label>
            <asp:Label ID="LblError" runat="server" CssClass="mensajeAdvertencia"></asp:Label>


            <div class="GwAutor">
                <asp:GridView ID="GwAutor" runat="server" Width="346px" DataSourceID="SqlAutor" AllowPaging="true" PageSize="10"
                    EmptyDataText="No hay Autores para mostrar">
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlAutor"  runat="server" ></asp:SqlDataSource>      
        </form>
    </div>
</body>
</html>


