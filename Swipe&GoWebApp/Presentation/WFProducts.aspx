<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProducts.aspx.cs" Inherits="Presentation.WFProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestionar Productos</h1>
    <div>
        <!-- HiddenField para almacenar el FK de la orden seleccionada -->
        <asp:HiddenField ID="HFProductsId" runat="server" />

        <!-- Nombre del producto -->
        <asp:Label ID="Label1" runat="server" Text="Nombre del producto"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />

        <!-- Descripcion del producto -->
        <asp:Label ID="Label2" runat="server" Text="Descripcion del producto"></asp:Label>
        <asp:TextBox ID="TBDescripcion" runat="server"></asp:TextBox>
        <br />

        <!-- Precio del producto -->
        <asp:Label ID="Label3" runat="server" Text="Precio del producto"></asp:Label>
        <asp:TextBox ID="TBPrecio" runat="server"></asp:TextBox>
        <br />
        <!-- Seleccionar Cliente -->
        <asp:Label ID="Label7" runat="server" Text="Seleccione la Categoria"></asp:Label>
        <asp:DropDownList ID="DDLCategoria" runat="server"></asp:DropDownList>
        <br />

        <!-- Seleccionar Proveedor -->
        <asp:Label ID="Label4" runat="server" Text="Seleccione el Proveedor"></asp:Label>
        <asp:DropDownList ID="DDLProveedor" runat="server"></asp:DropDownList>
        <br />


        <!-- Botones para guardar y actualizar órdenes -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        <asp:GridView ID="GVProducts" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVProducts_SelectedIndexChanged" OnRowDeleting="GVProducts_RowDeleting" DataKeyNames="pro_id">
            <Columns>
                <asp:BoundField DataField="pro_id" HeaderText="Id" />
                <asp:BoundField DataField="pro_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="pro_descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="pro_precio" HeaderText="Precio" />
                <asp:BoundField DataField="categoria_id" HeaderText="fkCategoria" />
                <asp:BoundField DataField="categoria_nombre" HeaderText="Nombre de la categoria" />
                <asp:BoundField DataField="proveedor_id" HeaderText="fkProveedor" />
                <asp:BoundField DataField="proveedor_nombre" HeaderText="Nombre del Proveedor" />

                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
