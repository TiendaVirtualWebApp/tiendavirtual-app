<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFComments.aspx.cs" Inherits="Presentation.WFComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Comentarios</h1>
    <div>
        <asp:HiddenField ID="HFCommentId" runat="server" />

        <asp:Label ID="Label1" runat="server" Text="Ingrese el comentario"></asp:Label>
        <asp:TextBox ID="TBCommentText" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese la fecha"></asp:Label>
        <asp:TextBox ID="TBCommentDate" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Seleccione el producto"></asp:Label>
        <asp:DropDownList ID="DDLProductos" runat="server"></asp:DropDownList>
        <br />

        <asp:Label ID="Label4" runat="server" Text="Seleccione el cliente"></asp:Label>
        <asp:DropDownList ID="DDLClientes" runat="server"></asp:DropDownList>
        <br />

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <asp:GridView ID="GVComments" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVComments_SelectedIndexChanged" OnRowDeleting="GVComments_RowDeleting" DataKeyNames="Comen_id">
            <Columns>
                <asp:BoundField DataField="comen_id" HeaderText="Id"/>
                <asp:BoundField DataField="comen_texto" HeaderText="Comentario" />
                <asp:BoundField DataField="comen_fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="tbl_productos_pro_id" HeaderText="FkProducto" />
                <asp:BoundField DataField="Productos" HeaderText="Producto" />
                <asp:BoundField DataField="tbl_clientes_cli_id" HeaderText="FkCliente" />
                <asp:BoundField DataField="Informacion" HeaderText="Informacion cliente" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
