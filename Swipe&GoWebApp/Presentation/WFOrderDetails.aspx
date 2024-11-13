<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFOrderDetails.aspx.cs" Inherits="Presentation.WFOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestionar Detalles de Pedidos</h1>
    <div>
        <!-- HiddenField para almacenar el ID del detalle del pedido -->
        <asp:HiddenField ID="HFOrderDetailId" runat="server" />

        <!-- Cantidad del detalle del pedido -->
        <asp:Label ID="Label1" runat="server" Text="Cantidad:"></asp:Label>
        <asp:TextBox ID="TBCantidad" runat="server"></asp:TextBox>
        <br />

        <!-- Precio Unitario -->
        <asp:Label ID="Label2" runat="server" Text="Precio:"></asp:Label>
        <asp:TextBox ID="TBPrecio" runat="server"></asp:TextBox>
        <br />

        <!-- Pedido ID -->
        <asp:Label ID="Label3" runat="server" Text="Pedido:"></asp:Label>
        <asp:DropDownList ID="DDLPedido" runat="server"></asp:DropDownList>
        <br />

        <!-- Producto ID -->
        <asp:Label ID="Label4" runat="server" Text="Producto ID:"></asp:Label>
        <asp:DropDownList ID="DDLProductos" runat="server"></asp:DropDownList>
        <br />

        <!-- Botones para guardar y actualizar detalles de pedido -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        <asp:GridView ID="GVOrderDetails" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVOrderDetails_SelectedIndexChanged" OnRowDeleting="GVOrderDetails_RowDeleting" DataKeyNames="det_id">
            <Columns>
                <asp:BoundField DataField="det_id" HeaderText="ID" />
                <asp:BoundField DataField="det_cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="det_precio" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="tbl_productos_pro_id" HeaderText="Producto ID" />
                <asp:BoundField DataField="Productos" HeaderText="Productos" />
                <asp:BoundField DataField="tbl_pedidos_pedi_id" HeaderText="Pedido ID" />
                <asp:BoundField DataField="pedi_estado" HeaderText="Estado Pedido" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>