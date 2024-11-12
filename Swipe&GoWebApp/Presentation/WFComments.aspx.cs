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
    public partial class WFComments : System.Web.UI.Page
    {
        CommentsLog objCom = new CommentsLog();
        ProductsLog objProd = new ProductsLog();
        CustomersLog objCust = new CustomersLog();

        private int _id, _fkproducto, _fkcliente;
        private string _texto;
        private DateTime _fecha;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showComentarios();
                showProductosDDL();
                showClientesDDL();
            }
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

        // Método para mostrar los clientes en el DropDownList
        private void showClientesDDL()
        {
            DDLClientes.DataSource = objCust.showClientesDDL();
            DDLClientes.DataValueField = "cli_id";
            DDLClientes.DataTextField = "Informacion";
            DDLClientes.DataBind();
            DDLClientes.Items.Insert(0, "Seleccione");
        }

        // Método para mostrar todos los comentarios en el GridView
        private void showComentarios()
        {
            DataSet ds = new DataSet();
            ds = objCom.showComentarios();
            GVComments.DataSource = ds;
            GVComments.DataBind();
        }

        // Método para limpiar los campos de entrada
        private void clear()
        {
            HFCommentId.Value = "";
            TBCommentText.Text = "";
            TBCommentDate.Text = "";
            DDLProductos.SelectedIndex = 0;
            DDLClientes.SelectedIndex = 0;
        }

        // Evento que se ejecuta al hacer clic en el botón Guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _texto = TBCommentText.Text;
            _fecha = DateTime.ParseExact(TBCommentDate.Text, "MM-dd-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture); // Fecha desde el TextBox
            _fkproducto = Convert.ToInt32(DDLProductos.SelectedValue);
            _fkcliente = Convert.ToInt32(DDLClientes.SelectedValue);

            executed = objCom.saveComentario(_texto, _fecha, _fkproducto, _fkcliente);

            if (executed)
            {
                LblMsj.Text = "¡El comentario se guardó exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                clear();
                showComentarios();
            }
            else
            {
                LblMsj.Text = "¡Error al guardar el comentario!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento que se ejecuta al hacer clic en el botón Actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFCommentId.Value);
            _texto = TBCommentText.Text;
            _fecha = DateTime.ParseExact(TBCommentDate.Text, "MM-dd-yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            _fkproducto = Convert.ToInt32(DDLProductos.SelectedValue);
            _fkcliente = Convert.ToInt32(DDLClientes.SelectedValue);

            executed = objCom.updateComentario(_id, _texto, _fecha, _fkproducto, _fkcliente);

            if (executed)
            {
                LblMsj.Text = "¡El comentario se actualizó exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                clear();
                showComentarios();
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar el comentario!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }


        // Evento para seleccionar una fila de la tabla
        protected void GVComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCommentId.Value = GVComments.SelectedRow.Cells[0].Text;
            TBCommentText.Text = GVComments.SelectedRow.Cells[1].Text;
            TBCommentDate.Text = GVComments.SelectedRow.Cells[2].Text;
            DDLProductos.SelectedValue = GVComments.SelectedRow.Cells[3].Text;
            DDLClientes.SelectedValue = GVComments.SelectedRow.Cells[5].Text;
        }

        // Evento para eliminar un usuario
        protected void GVComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Comen_id = Convert.ToInt32(GVComments.DataKeys[e.RowIndex].Values[0]);
            executed = objCom.deleteComentario(Comen_id);

            if (executed)
            {
                LblMsj.Text = "El usuario se eliminó exitosamente";
                GVComments.EditIndex = -1;
                LblMsj.ForeColor = System.Drawing.Color.Green;
                showComentarios();
            }
            else
            {
                LblMsj.Text = "Error al eliminar el usuario";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}