using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFCart : System.Web.UI.Page
    {
        // Instancia de la clase CarritoLog para interactuar con la lógica de negocio
        CartLog objCarrito = new CartLog();
        CustomersLog objCust = new CustomersLog();
        ProductsLog objProd = new ProductsLog();

        private int _id, _cantidad, _productoId, _clienteId;
        private decimal _precioUnitario;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si la página se está cargando por primera vez o si es una devolución de datos del servidor
            if (!Page.IsPostBack)
            {
                showCarrito(); // Mostrar todos los carritos
                showClientesDDL();
                showProductosDDL();
            }
        }

        private void showClientesDDL()
        {
            DDLClientes.DataSource = objCust.showClientesDDL();
            DDLClientes.DataValueField = "cli_id";
            DDLClientes.DataTextField = "Informacion"; // Ajustado para mostrar la información
            DDLClientes.DataBind();
            DDLClientes.Items.Insert(0, "Seleccione");
        }

        private void showProductosDDL()
        {
            DDLProductos.DataSource = objProd.showProductosDDL();
            DDLProductos.DataValueField = "pro_id";
            DDLProductos.DataTextField = "Productos";
            DDLProductos.DataBind();
            DDLProductos.Items.Insert(0, "Seleccione");
        }

        // Método para mostrar todos los carritos en el GridView
        private void showCarrito()
        {
            DataSet ds = new DataSet();
            ds = objCarrito.showCarrito();
            GVCarrito.DataSource = ds;
            GVCarrito.DataBind();
        }

        // Método para limpiar los TextBox y los HiddenField
        private void clear()
        {
            HFCarritoId.Value = "";
            TBCantidad.Text = "";
            TBPrecioUnitario.Text = "";
            DDLProductos.SelectedIndex = 0; // Limpia la selección del producto
            DDLClientes.SelectedIndex = 0;  // Limpia la selección del cliente
        }

        // Evento que se ejecuta cuando se da clic en el botón de guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _cantidad = Convert.ToInt32(TBCantidad.Text); // Capturar el valor que se ingrese en el TextBox
            _precioUnitario = Convert.ToDecimal(TBPrecioUnitario.Text);
            _productoId = Convert.ToInt32(DDLProductos.SelectedValue); // Usa el valor seleccionado en el DDL de productos
            _clienteId = Convert.ToInt32(DDLClientes.SelectedValue);  // Usa el valor seleccionado en el DDL de clientes

            executed = objCarrito.saveCarrito(_cantidad, _precioUnitario, _productoId, _clienteId);

            if (executed)
            {
                LblMsj.Text = "¡El carrito se guardó exitosamente!";
                clear(); // Limpiar los TextBox después de guardar
                showCarrito(); // Mostrar los carritos actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al guardar!";
            }
        }

        // Evento que se ejecuta cuando se da clic en el botón de actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFCarritoId.Value); // Obtener el ID del carrito seleccionado
            _cantidad = Convert.ToInt32(TBCantidad.Text);
            _precioUnitario = Convert.ToDecimal(TBPrecioUnitario.Text);
            _productoId = Convert.ToInt32(DDLProductos.SelectedValue); // Usa el valor seleccionado en el DDL de productos
            _clienteId = Convert.ToInt32(DDLClientes.SelectedValue);  // Usa el valor seleccionado en el DDL de clientes

            executed = objCarrito.updateCarrito(_id, _cantidad, _precioUnitario, _productoId, _clienteId);

            if (executed)
            {
                LblMsj.Text = "¡El carrito se actualizó exitosamente!";
                clear(); // Limpiar los TextBox después de actualizar
                showCarrito(); // Mostrar los carritos actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar!";
            }
        }

        // Evento para seleccionar una fila de la tabla
        protected void GVCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCarritoId.Value = GVCarrito.SelectedRow.Cells[0].Text;
            TBCantidad.Text = GVCarrito.SelectedRow.Cells[1].Text;
            TBPrecioUnitario.Text = GVCarrito.SelectedRow.Cells[2].Text;
            DDLProductos.SelectedValue = GVCarrito.SelectedRow.Cells[3].Text; // Ajusta el DDL para mostrar el producto
            DDLClientes.SelectedValue = GVCarrito.SelectedRow.Cells[4].Text;  // Ajusta el DDL para mostrar el cliente
        }

        // Evento para eliminar un carrito
        protected void GVCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int carritoId = Convert.ToInt32(GVCarrito.DataKeys[e.RowIndex].Values[0]);
            executed = objCarrito.deleteCarrito(carritoId);

            if (executed)
            {
                LblMsj.Text = "¡El carrito se eliminó exitosamente!";
                GVCarrito.EditIndex = -1;
                showCarrito();
            }
            else
            {
                LblMsj.Text = "¡Error al eliminar!";
            }
        }
    }
}


