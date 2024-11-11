using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic; // Assuming your CustomersLog class is in the Logic namespace

namespace Presentation
{
    public partial class WFCustomers : System.Web.UI.Page
    {
        // Instancia de la clase CustomersLog para interactuar con la lógica
        CustomersLog objCustomer = new CustomersLog();

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _telefono;
        // Bandera para saber si la operación fue exitosa
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo se ejecuta cuando se carga la página por primera vez (no en postbacks)
            if (!Page.IsPostBack)
            {
                showClientes(); // Mostrar todos los clientes
            }
        }

        // Mostrar todos los clientes en el GridView
        private void showClientes()
        {
            DataSet objData = new DataSet();
            objData = objCustomer.showClientes(); // Obtiene todos los clientes
            GVClientes.DataSource = objData; // Asigna el DataSet al GridView
            GVClientes.DataBind(); // Enlaza los datos con el GridView
        }

        // Método para limpiar los TextBox 
        private void Clear()
        {
            TBNombre.Text = "";
            TBApellido.Text = "";
            TBDireccion.Text = "";
            TBTelefono.Text = "";
            HFClienteId.Value = "";
        }

        // Guardar un nuevo cliente
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // Capturar los datos del cliente
            _nombre = TBNombre.Text;
            _apellido = TBApellido.Text;
            _direccion = TBDireccion.Text;
            _telefono = TBTelefono.Text;

            // Llamada a la lógica para guardar el cliente
            executed = objCustomer.saveCliente(_nombre, _apellido, _direccion, _telefono);

            if (executed)
            {
                LblMsj.Text = "¡Cliente guardado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear(); // Limpiar los TextBox después de guardar
                showClientes(); // Mostrar los clientes actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al guardar el cliente!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Actualizar un cliente existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Obtener los datos del cliente
            _id = Convert.ToInt32(HFClienteId.Value);
            _nombre = TBNombre.Text;
            _apellido = TBApellido.Text;
            _direccion = TBDireccion.Text;
            _telefono = TBTelefono.Text;

            // Llamada a la lógica de negocio para actualizar el cliente
            executed = objCustomer.updateCliente(_id, _nombre, _apellido, _direccion, _telefono);

            if (executed)
            {
                LblMsj.Text = "¡Cliente actualizado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();
                showClientes(); // Mostrar los clientes actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar el cliente!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila en el GridView y cargar los datos en los controles
        protected void GVClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del cliente seleccionado
            HFClienteId.Value = GVClientes.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVClientes.SelectedRow.Cells[1].Text;
            TBApellido.Text = GVClientes.SelectedRow.Cells[2].Text;
            TBDireccion.Text = GVClientes.SelectedRow.Cells[3].Text;
            TBTelefono.Text = GVClientes.SelectedRow.Cells[4].Text;
        }

        // Evento para eliminar un cliente
        protected void GVClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int clienteId = Convert.ToInt32(GVClientes.DataKeys[e.RowIndex].Values[0]);
            executed = objCustomer.deleteCliente(clienteId);

            if (executed)
            {
                LblMsj.Text = "El cliente se eliminó exitosamente";
                GVClientes.EditIndex = -1;
                showClientes();
            }
            else
            {
                LblMsj.Text = "Error al eliminar el cliente";
            }
        }
    }
}