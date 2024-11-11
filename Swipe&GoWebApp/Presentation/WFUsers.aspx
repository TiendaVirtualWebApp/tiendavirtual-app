<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsers.aspx.cs" Inherits="Presentation.WFUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestionar Usuarios</h1>
    <div>
        <!-- Id de los usuarios -->
        <asp:HiddenField ID="HFUsuariosId" runat="server" />
        <!-- Nombre de los usuarios -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese su nombre:"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />
        <!-- Apellido de los usuarios -->
        <asp:Label ID="Label2" runat="server" Text="Ingrese su apellido:"></asp:Label>
        <asp:TextBox ID="TBApellido" runat="server"></asp:TextBox>
        <br />
        <!-- Correo de los usuarios -->
        <asp:Label ID="Label3" runat="server" Text="Ingrese su correo:"></asp:Label>
        <asp:TextBox ID="TBCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        <br />
        <!-- Contraseña de los usuarios -->
        <asp:Label ID="Label4" runat="server" Text="Ingrese su contraseña:"></asp:Label>
        <asp:TextBox ID="TBContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

        <br />
        <!-- Direccion de los usuarios -->
        <asp:Label ID="Label5" runat="server" Text="Ingrese su direccion:"></asp:Label>
        <asp:TextBox ID="TBDireccion" runat="server"></asp:TextBox>
        <br />
        <!-- Telefono de los usuarios -->
        <asp:Label ID="Label6" runat="server" Text="Ingrese su telefono:"></asp:Label>
        <asp:TextBox ID="TBTelefono" runat="server"></asp:TextBox>
        <br />
        <!-- Tipo de los usuarios -->
        <asp:Label ID="Label7" runat="server" Text="Tipo de usuario:"></asp:Label>
        <asp:DropDownList ID="TBTipo" runat="server" CssClass="form-select">
        <asp:ListItem Value="0">Seleccione</asp:ListItem>
        <asp:ListItem Value="Cliente">Cliente</asp:ListItem>
        <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
        </asp:DropDownList>
  


        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        <asp:GridView ID="GVUsuarios" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsuarios_SelectedIndexChanged" OnRowDeleting="GVUsuarios_RowDeleting" DataKeyNames="usu_id">
            <Columns>
                <asp:BoundField DataField="usu_id" HeaderText="Id" />
                <asp:BoundField DataField="usu_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="usu_apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="usu_correo" HeaderText="Correo" />
                <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña" />
                <asp:BoundField DataField="usu_direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="usu_telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="usu_tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="usu_salt" HeaderText="Salt" />


                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
