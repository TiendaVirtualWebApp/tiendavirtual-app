<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFOrders.aspx.cs" Inherits="Presentation.WFOrders" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h1>Gestionar Pedidos</h1>
    <div>
        <!-- HiddenField para almacenar el ID de la orden seleccionada -->
        <asp:HiddenField ID="HFOrderId" runat="server" />

        <!-- Fecha de la Orden -->
        <asp:Label ID="LabelFecha" runat="server" Text="Fecha de la Orden:"></asp:Label>
        <asp:TextBox ID="TBFecha" runat="server"></asp:TextBox>
        <br />

        <!-- Estado de la Orden -->
        <asp:Label ID="LabelEstado" runat="server" Text="Estado de la Orden:"></asp:Label>
        <asp:TextBox ID="TBEstado" runat="server"></asp:TextBox>
        <br />

        <!-- Total de la Orden -->
        <asp:Label ID="LabelTotal" runat="server" Text="Total de la Orden:"></asp:Label>
        <asp:TextBox ID="TBTotal" runat="server"></asp:TextBox>
        <br />

        <!-- ID del Cliente -->
        <asp:Label ID="LabelClienteId" runat="server" Text="ID del Cliente:"></asp:Label>
        <asp:TextBox ID="TBClienteId" runat="server"></asp:TextBox>
        <br />

        <!-- Botones para guardar y actualizar órdenes -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

       <asp:GridView ID="GVOrders" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVOrders_SelectedIndexChanged" OnRowDeleting="GVOrders_RowDeleting" DataKeyNames="pedi_id">
    <Columns>
        <asp:BoundField DataField="pedi_id" HeaderText="ID" />
        <asp:BoundField DataField="pedi_fecha" HeaderText="Fecha" />
        <asp:BoundField DataField="pedi_estado" HeaderText="Estado" />
        <asp:BoundField DataField="pedi_total" HeaderText="Total" />
        <asp:BoundField DataField="tbl_clientes_cli_id" HeaderText="Cliente ID" />
        <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

    </div>
</asp:Content>
