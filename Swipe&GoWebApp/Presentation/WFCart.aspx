<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCart.aspx.cs" Inherits="Presentation.WFCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>Gestionar Carritos</h1>
    <div>
        <!-- HiddenField para almacenar el ID del carrito seleccionado -->
        <asp:HiddenField ID="HFCarritoId" runat="server" />

        <!-- Cantidad del Carrito -->
        <asp:Label ID="LabelCantidad" runat="server" Text="Cantidad:"></asp:Label>
        <asp:TextBox ID="TBCantidad" runat="server"></asp:TextBox>
        <br />

        <!-- Precio Unitario del Carrito -->
        <asp:Label ID="LabelPrecioUnitario" runat="server" Text="Precio Unitario:"></asp:Label>
        <asp:TextBox ID="TBPrecioUnitario" runat="server"></asp:TextBox>
        <br />

        <!-- Seleccionar Cliente -->
        <asp:Label ID="LabelCliente" runat="server" Text="Seleccione el Cliente:"></asp:Label>
        <asp:DropDownList ID="DDLClientes" runat="server"></asp:DropDownList>
        <br />

        <!-- Seleccionar Producto -->
        <asp:Label ID="LabelProducto" runat="server" Text="Seleccione un Producto:"></asp:Label>
        <asp:DropDownList ID="DDLProductos" runat="server"></asp:DropDownList>
        <br />

        <!-- Botones para guardar y actualizar carritos -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        <asp:GridView ID="GVCarrito" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCarrito_SelectedIndexChanged" OnRowDeleting="GVCarrito_RowDeleting" DataKeyNames="carri_id">
            <Columns>
                <asp:BoundField DataField="carri_id" HeaderText="ID" />
                <asp:BoundField DataField="carri_cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="carri_precio_unitario" HeaderText="Precio Unitario" />
                <asp:BoundField DataField="tbl_productos_pro_id" HeaderText="fkProducto" />
                <%--<asp:BoundField DataField="Productos" HeaderText="Producto" />--%>
                <asp:BoundField DataField="tbl_clientes_cli_id" HeaderText="fkCliente" />
                <asp:BoundField DataField="Informacion" HeaderText="Cliente" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
