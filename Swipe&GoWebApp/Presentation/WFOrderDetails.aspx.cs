using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFOrderDetails : System.Web.UI.Page
    {
        OrderDetailsLog objOrdDet = new OrderDetailsLog();
        OrdersLog objOrd = new OrdersLog();
        ProductsLog objProd = new ProductsLog();

        private int _id, _cantidad, _fkpedido, _fkproducto;
        private decimal _precio;
     
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showDetallesPedidos();
                showPedidosDDL();
                showProductosDDL();
            }
        }

        // Método para mostrar los pedidos en el DropDownList
        private void showPedidosDDL()
        {
            DDLPedido.DataSource = objOrd.showPedidosDDL();
            DDLPedido.DataValueField = "pedi_id";
            DDLPedido.DataTextField = "pedi_estado";
            DDLPedido.DataBind();
            DDLPedido.Items.Insert(0, "Seleccione");
        }

        // Método para mostrar los productos en el DropDownList
        private void showProductosDDL()
        {
            DDLProductos.DataSource = objProd.showProductosDDL();
            DDLProductos.DataValueField = "pro_id";
            DDLProductos.DataTextField = "Productos";
            DDLProductos.DataBind();
            DDLProductos.Items.Insert(0, "Seleccione");
        }

        // Método para mostrar todos los detalles de pedidos en el GridView
        private void showDetallesPedidos()
        {
            DataSet ds = new DataSet();
            ds = objOrdDet.showDetallesPedidos();
            GVOrderDetails.DataSource = ds;
            GVOrderDetails.DataBind();
        }

        // Método para limpiar los campos de entrada
        private void clear()
        {
            HFOrderDetailId.Value = "";
            TBCantidad.Text = "";
            TBPrecio.Text = "";
            DDLProductos.SelectedIndex = 0;
            DDLPedido.SelectedIndex = 0;
        }

        // Evento que se ejecuta al hacer clic en el botón Guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _cantidad = Convert.ToInt32(TBCantidad.Text);
            _precio = Convert.ToDecimal(TBPrecio.Text);
            _fkproducto = Convert.ToInt32(DDLProductos.SelectedValue);
            _fkpedido = Convert.ToInt32(DDLPedido.SelectedValue);

            executed = objOrdDet.saveDetallePedido(_cantidad, _precio, _fkproducto, _fkpedido);

            if (executed)
            {
                LblMsj.Text = "¡El detalle del pedido se guardó exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                clear();
                showDetallesPedidos();
            }
            else
            {
                LblMsj.Text = "¡Error al guardar el detalle del pedido!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento que se ejecuta al hacer clic en el botón Actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFOrderDetailId.Value);
            _cantidad = Convert.ToInt32(TBCantidad.Text);
            _precio = Convert.ToDecimal(TBPrecio.Text);
            _fkproducto = Convert.ToInt32(DDLProductos.SelectedValue);
            _fkpedido = Convert.ToInt32(DDLPedido.SelectedValue);


            executed = objOrdDet.updateDetallePedido(_id, _cantidad, _precio, _fkproducto, _fkpedido);

            if (executed)
            {
                LblMsj.Text = "¡El detalle del pedido se actualizó exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                clear();
                showDetallesPedidos();
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar el detalle del pedido!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila de la tabla
        protected void GVOrderDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFOrderDetailId.Value = GVOrderDetails.SelectedRow.Cells[0].Text;
            TBCantidad.Text = GVOrderDetails.SelectedRow.Cells[1].Text;
            TBPrecio.Text = GVOrderDetails.SelectedRow.Cells[2].Text;
            DDLProductos.SelectedValue = GVOrderDetails.SelectedRow.Cells[3].Text;
            DDLPedido.SelectedValue = GVOrderDetails.SelectedRow.Cells[5].Text;
           
        }

        // Evento para eliminar un detalle de pedido
        protected void GVOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int OrId = Convert.ToInt32(GVOrderDetails.DataKeys[e.RowIndex].Values[0]);
            executed = objOrdDet.deleteDetallePedido(OrId);

            if (executed)
            {
                LblMsj.Text = "El detalle del pedido se eliminó exitosamente";
                GVOrderDetails.EditIndex = -1;
                LblMsj.ForeColor = System.Drawing.Color.Green;
                showDetallesPedidos();
            }
            else
            {
                LblMsj.Text = "Error al eliminar el detalle del pedido";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}