<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCategories.aspx.cs" Inherits="Presentation.WFCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h1>Gestionar Categorías</h1>
    <div>
        <!-- HiddenField para almacenar el ID de la categoría seleccionada -->
        <asp:HiddenField ID="HFCategoryId" runat="server" />

        <!-- Nombre de la Categoría -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre de la categoría:"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />

        <!-- Botones para guardar y actualizar categorías -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

       <asp:GridView ID="GVCategories" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCategories_SelectedIndexChanged" OnRowDeleting="GVCategories_RowDeleting" DataKeyNames="cate_id">
    <Columns>
        <asp:BoundField DataField="cate_id" HeaderText="Id" />
        <asp:BoundField DataField="cate_nombre" HeaderText="Nombre" />
        <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

    </div>
</asp:Content>
