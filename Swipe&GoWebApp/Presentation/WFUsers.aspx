<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsers.aspx.cs" Inherits="Presentation.WFUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestionar Usuarios</h1>
    <div>
        <!-- Id de los usuarios -->
        <asp:HiddenField ID="HFUsuariosId" runat="server" />
        <!-- Nombre de los usuarios -->
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />
        <!-- Apellido de los usuarios -->
        <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="TBApellido" runat="server"></asp:TextBox>
        <br />
        <!-- Correo de los usuarios -->
        <asp:Label ID="Label3" runat="server" Text="Correo:"></asp:Label>
        <asp:TextBox ID="TBCorreo" runat="server"></asp:TextBox>
        <br />
        <!-- Contraseña de los usuarios -->
        <asp:Label ID="Label4" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="TBContrasena" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <!-- Direccion de los usuarios -->
        <asp:Label ID="Label5" runat="server" Text="Direccion:"></asp:Label>
        <asp:TextBox ID="TBDireccion" runat="server"></asp:TextBox>
        <br />
        <!-- Telefono de los usuarios -->
        <asp:Label ID="Label6" runat="server" Text="Telefono:"></asp:Label>
        <asp:TextBox ID="TBTelefono" runat="server"></asp:TextBox>
        <br />
        <!-- Tipo de los usuarios -->
        <asp:Label ID="Label7" runat="server" Text="Tipo:"></asp:Label>
        <asp:TextBox ID="TBTipo" runat="server"></asp:TextBox>
        <br />
        <!-- Salt de los usuarios -->
        <asp:Label ID="Label8" runat="server" Text="Salt:"></asp:Label>
        <asp:TextBox ID="TBSalt" runat="server"></asp:TextBox>
        <br />


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
                <asp:BoundField DataField="usu_contrasena" HeaderText="Contrasena" />
                <asp:BoundField DataField="usu_direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="usu_telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="usu_tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="usu_salt" HeaderText="Salt" />


                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
