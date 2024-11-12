using Logic;
using System.Data;
using System;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Presentation
{
    public partial class WFOrders : System.Web.UI.Page
    {
        // Instancia de la clase OrdersLog para interactuar con la lógica 
        OrdersLog objOrder = new OrdersLog();

        private int _id;
        private DateTime _fecha;
        private string _estado;
        private Double _total;
        private int _clienteId;
        // Bandera para saber si la operación fue completada
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo se ejecuta cuando se carga la página por primera vez (no en postbacks)
            if (!Page.IsPostBack)
            {
                showOrders(); // Mostrar todas las órdenes
            }
        }

        // Mostrar todas las órdenes en el GridView
        private void showOrders()
        {
            DataSet objData = new DataSet();
            objData = objOrder.showPedidos(); // Obtiene todas las órdenes
            GVOrders.DataSource = objData;   // Asigna el DataSet al GridView
            GVOrders.DataBind();             // Enlaza los datos con el GridView
        }

        // Método para limpiar los TextBox y los HiddenField
        private void Clear()
        {
            TBFecha.Text = "";  // Limpiar el TextBox de Fecha
            TBEstado.Text = ""; // Limpiar el TextBox de Estado
            TBTotal.Text = "";  // Limpiar el TextBox de Total
            TBClienteId.Text = ""; // Limpiar el TextBox de Cliente ID
            HFOrderId.Value = "";  // Limpiar el HiddenField
        }

        // Guardar una nueva orden
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // Captura los detalles de la orden
            _fecha = DateTime.ParseExact(TBFecha.Text, "MM-dd-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture); // Fecha desde el TextBox
            _estado = TBEstado.Text; // Estado desde el TextBox
             _total = Convert.ToDouble(TBTotal.Text); // Total desde el TextBox
            _clienteId = Convert.ToInt32(TBClienteId.Text); // Cliente ID desde el TextBox

            // Llamada a la lógica para guardar la orden
            executed = objOrder.savePedido(_fecha, _estado, _total, _clienteId);

            if (executed)
            {
                LblMsj.Text = "¡Pedido guardado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();  // Limpiar los TextBox después de guardar
                showOrders(); // Mostrar las órdenes actualizadas
            }
            else
            {
                LblMsj.Text = "¡Error al guardar la orden!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Actualizar una orden existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFOrderId.Value);  // Obtener el ID de la orden seleccionada
            _fecha = DateTime.ParseExact(TBFecha.Text, "MM-dd-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture); // Fecha desde el TextBox
            _estado = TBEstado.Text; // Estado desde el TextBox
            _total = Convert.ToDouble(TBTotal.Text); // Total desde el TextBox
            _clienteId = Convert.ToInt32(TBClienteId.Text); // Cliente ID desde el TextBox

            // Llamada a la lógica de negocio para actualizar la orden
            executed = objOrder.updatePedido(_id, _fecha, _estado, _total, _clienteId);

            if (executed)
            {
                LblMsj.Text = "¡Orden actualizada exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();
                showOrders(); // Mostrar las órdenes actualizadas
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar la orden!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila en el GridView y cargar los datos en los controles
        protected void GVOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID de la orden seleccionada
            HFOrderId.Value = GVOrders.SelectedRow.Cells[0].Text;
            TBFecha.Text = GVOrders.SelectedRow.Cells[1].Text; // Cargar la fecha de la orden
            TBEstado.Text = GVOrders.SelectedRow.Cells[2].Text; // Cargar el estado de la orden
            TBTotal.Text = GVOrders.SelectedRow.Cells[3].Text; // Cargar el total de la orden
            TBClienteId.Text = GVOrders.SelectedRow.Cells[4].Text; // Cargar el ID del cliente
        }

        // Evento para eliminar una orden
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
