using System;
using System.Data;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class Payments : System.Web.UI.Page
    {
        // Instancias para interactuar con la lógica
        PaymentsLog objPago = new PaymentsLog();
        CustomersLog objCust = new CustomersLog();
        OrdersLog objOrder = new OrdersLog();

        private int _id;
        private DateTime _fecha;
        private double _monto;
        private string _metodoPago;
        private string _estado;
        private int _pedidoId;
        private int _clienteId;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showPagos();
                showClientesDDL();
                showPedidosDDL();
            }
        }

        private void showClientesDDL()
        {
            DDLClientes.DataSource = objCust.showClientesDDL();
            DDLClientes.DataValueField = "cli_id";
            DDLClientes.DataTextField = "Informacion";
            DDLClientes.DataBind();
            DDLClientes.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        private void showPedidosDDL()
        {
            DDLPedidos.DataSource = objOrder.showPedidosDDL();
            DDLPedidos.DataValueField = "pedi_id";
            DDLPedidos.DataTextField = "pedi_estado";
            DDLPedidos.DataBind();
            DDLPedidos.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        private void showPagos()
        {
            DataSet objData = objPago.showPagos();
            GVPagos.DataSource = objData;
            GVPagos.DataBind();
        }

        private void Clear()
        {
            TBFecha.Text = "";
            TBMonto.Text = "";
            TBMetodoPago.Text = "";
            TBEstatus.Text = "";
            DDLClientes.SelectedIndex = 0;
            DDLPedidos.SelectedIndex = 0;
            HFPagoId.Value = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _fecha = DateTime.ParseExact(TBFecha.Text, "MM-dd-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
                _monto = Convert.ToDouble(TBMonto.Text);
                _metodoPago = TBMetodoPago.Text;
                _estado = TBEstatus.Text;
                _pedidoId = Convert.ToInt32(DDLPedidos.SelectedValue);
                _clienteId = Convert.ToInt32(DDLClientes.SelectedValue);

                executed = objPago.savePago(_fecha, _monto, _metodoPago, _estado, _pedidoId, _clienteId);

                if (executed)
                {
                    LblMsj.Text = "¡Pago guardado exitosamente!";
                    LblMsj.ForeColor = System.Drawing.Color.Green;
                    Clear();
                    showPagos();
                }
                else
                {
                    LblMsj.Text = "¡Error al guardar el pago!";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error: " + ex.Message;
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _id = Convert.ToInt32(HFPagoId.Value);
                _fecha = DateTime.ParseExact(TBFecha.Text, "MM-dd-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
                _monto = Convert.ToDouble(TBMonto.Text);
                _metodoPago = TBMetodoPago.Text;
                _estado = TBEstatus.Text;
                _pedidoId = Convert.ToInt32(DDLPedidos.SelectedValue);
                _clienteId = Convert.ToInt32(DDLClientes.SelectedValue);

                executed = objPago.updatePago(_id, _fecha, _monto, _metodoPago, _estado, _pedidoId, _clienteId);

                if (executed)
                {
                    LblMsj.Text = "¡Pago actualizado exitosamente!";
                    LblMsj.ForeColor = System.Drawing.Color.Green;
                    Clear();
                    showPagos();
                }
                else
                {
                    LblMsj.Text = "¡Error al actualizar el pago!";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error: " + ex.Message;
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GVPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFPagoId.Value = GVPagos.SelectedRow.Cells[0].Text;
            TBFecha.Text = GVPagos.SelectedRow.Cells[1].Text;
            TBMonto.Text = GVPagos.SelectedRow.Cells[2].Text;
            TBMetodoPago.Text = GVPagos.SelectedRow.Cells[3].Text;
            TBEstatus.Text = GVPagos.SelectedRow.Cells[4].Text;
            DDLPedidos.SelectedValue = GVPagos.SelectedRow.Cells[5].Text;
            DDLClientes.SelectedValue = GVPagos.SelectedRow.Cells[7].Text;
        }

        protected void GVPagos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int paymentId = Convert.ToInt32(GVPagos.DataKeys[e.RowIndex].Values[0]);
            executed = objPago.deletePago(paymentId);

            if (executed)
            {
                LblMsj.Text = "¡El pago se eliminó exitosamente!";
                GVPagos.EditIndex = -1;
                showPagos();
            }
            else
            {
                LblMsj.Text = "¡Error al eliminar!";
            }
        }
    }
}
