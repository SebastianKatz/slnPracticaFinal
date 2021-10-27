<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebClub.aspx.cs" Inherits="WebClub.WebClub" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblJugador" runat="server" Text="Jugador"></asp:Label><br />
            Id:<asp:TextBox ID="txtId" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>:
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            Apellido:<asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            Fecha de nacimiento: <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPuesto" runat="server" Text="Puesto"></asp:Label>
            <asp:DropDownList ID="ddlPuesto" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <br />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <br />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <br />
            <br />
            <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por puesto"></asp:Label>
            <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="gridJugador" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
