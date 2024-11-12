using Logic;
using System.Data;
using System;
using System.Web.UI.WebControls;
using System.Globalization;


namespace Presentation
{
    public partial class WFOrders : System.Web.UI.Page
    {
        OrdersLog objOrder = new OrdersLog();
        CustomersLog objCust = new CustomersLog();

        private int _id;
        private DateTime _fecha;
        private string _estado;
        private double _total;
        private int fkCliente;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TBFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                showOrders();
                showClientesDDL();
            }
        }

        private void showClientesDDL()
        {
            DDLClientes.DataSource = objCust.showClientesDDL();
            DDLClientes.DataValueField = "cli_id";
            DDLClientes.DataTextField = "Informacion"; // Ajustado para mostrar la informacion
            DDLClientes.DataBind();
            DDLClientes.Items.Insert(0, "Seleccione");
        }

        private void showOrders()
        {
            DataSet objData = objOrder.showPedidos();
            GVOrders.DataSource = objData;
            GVOrders.DataBind();
        }

        private void Clear()
        {
            TBFecha.Text = "";
            DDLEstado.SelectedValue = "";
            TBTotal.Text = "";
            DDLClientes.SelectedIndex = 0;
            HFOrderId.Value = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
          
            _fecha=DateTime.Parse(TBFecha.Text);
            _estado = DDLEstado.SelectedValue; // Obtiene el estado seleccionado en el DropDownList
            _total = Convert.ToDouble(TBTotal.Text);

            if (int.TryParse(DDLClientes.SelectedValue, out fkCliente))
            {
                executed = objOrder.savePedido(_fecha, _estado, _total, fkCliente);

                if (executed)
                {
                    LblMsj.Text = "¡Orden guardada exitosamente!";
                    LblMsj.ForeColor = System.Drawing.Color.Green;
                    Clear();
                    showOrders();
                }
                else
                {
                    LblMsj.Text = "¡Error al guardar la orden!";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                LblMsj.Text = "Por favor, seleccione un cliente válido.";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFOrderId.Value);
            _fecha = DateTime.Parse(TBFecha.Text);
            _estado = DDLEstado.SelectedValue; // Obtiene el estado seleccionado en el DropDownList
            _total = Convert.ToDouble(TBTotal.Text);

            if (int.TryParse(DDLClientes.SelectedValue, out fkCliente))
            {
                executed = objOrder.updatePedido(_id, _fecha, _estado, _total, fkCliente);

                if (executed)
                {
                    LblMsj.Text = "¡Orden actualizada exitosamente!";
                    LblMsj.ForeColor = System.Drawing.Color.Green;
                    Clear();
                    showOrders();
                }
                else
                {
                    LblMsj.Text = "¡Error al actualizar la orden!";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                LblMsj.Text = "Por favor, seleccione un cliente válido.";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GVOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFOrderId.Value = GVOrders.SelectedRow.Cells[0].Text;
            TBFecha.Text = GVOrders.SelectedRow.Cells[1].Text;
            DDLEstado.SelectedValue = GVOrders.SelectedRow.Cells[2].Text;
            TBTotal.Text = GVOrders.SelectedRow.Cells[3].Text;
            DDLClientes.SelectedValue = GVOrders.SelectedRow.Cells[4].Text;
        }

        protected void GVOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderId = Convert.ToInt32(GVOrders.DataKeys[e.RowIndex].Values[0]);
            executed = objOrder.deletePedido(orderId);

            if (executed)
            {
                LblMsj.Text = "¡Orden eliminada exitosamente!";
                GVOrders.EditIndex = -1;
                showOrders();
            }
            else
            {
                LblMsj.Text = "¡Error al eliminar la orden!";
            }
        }
    }
}
