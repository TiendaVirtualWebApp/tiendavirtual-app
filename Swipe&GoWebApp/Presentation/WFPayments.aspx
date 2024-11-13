<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="Presentation.Payments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestionar Pagos</h1>
    <div>
        <!-- Campo oculto para almacenar el ID del pago -->
        <asp:HiddenField ID="HFPagoId" runat="server" />
        
        <!-- Fecha del pago -->
        <asp:Label ID="Label1" runat="server" Text="Fecha:"></asp:Label>
        <asp:TextBox ID="TBFecha" runat="server"></asp:TextBox>
        <br />

        <!-- Monto del pago -->
        <asp:Label ID="Label2" runat="server" Text="Monto:"></asp:Label>
        <asp:TextBox ID="TBMonto" runat="server"></asp:TextBox>
        <br />

        <!-- Método de pago -->
        <asp:Label ID="Label3" runat="server" Text="Método de Pago:"></asp:Label>
        <asp:TextBox ID="TBMetodoPago" runat="server"></asp:TextBox>
        <br />

        <!-- Estado del pago -->
        <asp:Label ID="Label4" runat="server" Text="Estado:"></asp:Label>
        <asp:TextBox ID="TBEstatus" runat="server"></asp:TextBox>
        <br />

        <!-- Seleccionar Pedido -->
        <asp:Label ID="Label5" runat="server" Text="Pedido:"></asp:Label>
        <asp:DropDownList ID="DDLPedidos" runat="server"></asp:DropDownList>
        <br />

        <!-- Seleccionar Cliente -->
        <asp:Label ID="Label7" runat="server" Text="Cliente:"></asp:Label>
        <asp:DropDownList ID="DDLClientes" runat="server"></asp:DropDownList>
        <br />

        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        <!-- GridView para mostrar la lista de pagos -->
        <asp:GridView ID="GVPagos" runat="server" AutoGenerateColumns="False" 
                      OnSelectedIndexChanged="GVPagos_SelectedIndexChanged" 
                      OnRowDeleting="GVPagos_RowDeleting" 
                      DataKeyNames="pag_id">
            <Columns>
                <asp:BoundField DataField="pag_id" HeaderText="ID Pago" />
                <asp:BoundField DataField="pag_fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="pag_monto" HeaderText="Monto" />
                <asp:BoundField DataField="pag_metodo_pago" HeaderText="Método de Pago" />
                <asp:BoundField DataField="pag_estado" HeaderText="Estado" />
                <asp:BoundField DataField="tbl_pedidos_pedi_id" HeaderText="ID Pedido" />
                <asp:BoundField DataField="pedi_estado" HeaderText="Estado del Pedido" />
                <asp:BoundField DataField="tbl_pedidos_tbl_clientes_cli_id" HeaderText="ID Cliente" />
                <asp:BoundField DataField="Informacion" HeaderText="Datos del Cliente" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>