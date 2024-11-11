using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic; // Assuming your ProvidersLog class is in the Logic namespace

namespace Presentation
{
    public partial class WFProviders : System.Web.UI.Page
    {
        // Instancia de la clase ProvidersLog para interactuar con la lógica
        ProvidersLog objProvider = new ProvidersLog();

        private int _id;
        private string _nombre;
        private string _contacto;
        private string _direccion;
        // Bandera para saber si la operación fue exitosa
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo se ejecuta cuando se carga la página por primera vez (no en postbacks)
            if (!Page.IsPostBack)
            {
                showProveedores(); // Mostrar todos los proveedores
            }
        }

        // Mostrar todos los proveedores en el GridView
        private void showProveedores()
        {
            DataSet objData = new DataSet();
            objData = objProvider.showProveedores(); // Obtiene todos los proveedores
            GVProveedores.DataSource = objData; // Asigna el DataSet al GridView
            GVProveedores.DataBind(); // Enlaza los datos con el GridView
        }

        // Método para limpiar los TextBox 
        private void Clear()
        {
            TBNombre.Text = "";
            TBContacto.Text = "";
            TBDireccion.Text = "";
            HFProveedoresId.Value = "";
        }

        // Guardar un nuevo proveedor
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // Capturar los datos del proveedor
            _nombre = TBNombre.Text;
            _contacto = TBContacto.Text;
            _direccion = TBDireccion.Text;

            // Llamada a la lógica para guardar el proveedor
            executed = objProvider.saveProveedor(_nombre, _contacto, _direccion);

            if (executed)
            {
                LblMsj.Text = "¡Proveedor guardado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear(); // Limpiar los TextBox después de guardar
                showProveedores(); // Mostrar los proveedores actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al guardar el proveedor!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Actualizar un proveedor existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Obtener los datos del proveedor
            _id = Convert.ToInt32(HFProveedoresId.Value);
            _nombre = TBNombre.Text;
            _contacto = TBContacto.Text;
            _direccion = TBDireccion.Text;

            // Llamada a la lógica de negocio para actualizar el proveedor
            executed = objProvider.updateProveedor(_id, _nombre, _contacto, _direccion);

            if (executed)
            {
                LblMsj.Text = "¡Proveedor actualizado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();
                showProveedores(); // Mostrar los proveedores actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar el proveedor!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila en el GridView y cargar los datos en los controles
        protected void GVProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del proveedor seleccionado
            HFProveedoresId.Value = GVProveedores.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVProveedores.SelectedRow.Cells[1].Text;
            TBContacto.Text = GVProveedores.SelectedRow.Cells[2].Text;
            TBDireccion.Text = GVProveedores.SelectedRow.Cells[3].Text;
        }

        // Evento para eliminar un proveedor
        protected void GVProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int proveedorId = Convert.ToInt32(GVProveedores.DataKeys[e.RowIndex].Values[0]);
            executed = objProvider.deleteProveedor(proveedorId);

            if (executed)
            {
                LblMsj.Text = "El proveedor se eliminó exitosamente";
                GVProveedores.EditIndex = -1;
                LblMsj.ForeColor = System.Drawing.Color.Green;
                showProveedores();
            }
            else
            {
                LblMsj.Text = "Error al eliminar el proveedor";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}