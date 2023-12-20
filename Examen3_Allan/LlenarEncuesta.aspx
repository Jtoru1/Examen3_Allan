<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="LlenarEncuesta.aspx.cs" Inherits="Examen3_Allan.LlenarEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 class="display-4">LlenarEncuesta</h1>
        <p class="lead">Contenido Específico para Llenar Encuestas.</p>
    <asp:Button ID="Mostrar_Encuesta" runat="server" Text="AgregarEncuesta" OnClick="Mostrar_Encuesta_Click" />

        <br />

        <br />
        <div>
            <asp:Panel ID="pnlEncuesta" runat="server" Visible="false">
                 
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <br />
                <label for="txtfecha">Fecha:</label>
                <asp:Calendar ID="calFechaNacimiento" runat="server"></asp:Calendar>
                <asp:Button ID="btnValidarFecha" runat="server" Text="Validar Fecha" OnClick="btnValidarFecha_Click" />
                <br />
                <label for="txtcorreo">Correo:</label>
                <asp:TextBox ID="txtcorreo" runat="server"></asp:TextBox>
                <br />
                <label for="txtpartido">Partido:</label>
                <asp:DropDownList ID="ddlPartidosPoliticos" runat="server"></asp:DropDownList>
                <br />
              
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

            </asp:Panel>
            <br />

            <br />
        </div>
    </div>
</asp:Content>
