<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProviders.aspx.cs" Inherits="Presentation.WFProviders"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestionar Proveedores</h1>
    <div>
        <!-- Id de los proveedores -->
        <asp:HiddenField ID="HFProveedoresId" runat="server" />
         <!-- Nombre de los proveedores -->
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />
         <!-- Contacto de los proveedores -->
        <asp:Label ID="Label2" runat="server" Text="Contacto:"></asp:Label>
        <asp:TextBox ID="TBContacto" runat="server"></asp:TextBox>
        <br />
         <!-- Direccion de los proveedores -->
        <asp:Label ID="Label3" runat="server" Text="Dirección:"></asp:Label>
        <asp:TextBox ID="TBDireccion" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        <asp:GridView ID="GVProveedores" runat="server" AutoGenerateColumns="False" 
                     OnSelectedIndexChanged="GVProveedores_SelectedIndexChanged" 
                     OnRowDeleting="GVProveedores_RowDeleting" DataKeyNames="prove_id">
            <Columns>
                <asp:BoundField DataField="prove_id" HeaderText="ID" />
                <asp:BoundField DataField="prove_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="prove_contacto" HeaderText="Contacto" />
                <asp:BoundField DataField="prove_direccion" HeaderText="Dirección" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
