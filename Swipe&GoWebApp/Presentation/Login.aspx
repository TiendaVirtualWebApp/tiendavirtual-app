<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- Mensaje --%>
            <asp:Label ID="Label3" runat="server" Text="Inicia sesión"></asp:Label>
            <br />
            <%-- Correo --%>
            <asp:Label ID="Label1" runat="server" Text="Correo"></asp:Label>
            <asp:TextBox ID="TxtCorreo" runat="server" TextMode="Email"></asp:TextBox>
            <%-- Contraseña --%>
             <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="TxtContrasena" runat="server" TextMode="Password"></asp:TextBox>
            <%-- Boton y mensaje --%>
            <asp:Button ID="BtnIniciar" runat="server" Text="Iniciar" />
            <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
           
            
        </div>
    </form>
</body>
</html>
