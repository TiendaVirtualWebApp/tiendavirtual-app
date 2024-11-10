using Logic;
using System.Data;
using System;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFCategories : System.Web.UI.Page
    {
        // Instancia de la clase CategoriesLog para interactuar con la lógica 
        CategoriesLog objCat = new CategoriesLog();

        private string _nombre;
        private int _id;
        // Bandera para saber si la operación fue exitosa
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo se ejecuta cuando se carga la página por primera vez (no en postbacks)
            if (!Page.IsPostBack)
            {
                showCategorias(); // Mostrar todas las categorías
            }
        }

        // Mostrar todas las categorías en el GridView
        private void showCategorias()
        {
            DataSet objData = new DataSet();
            objData = objCat.showCategorias();// Obtiene todas las categorías
            GVCategories.DataSource = objData;         // Asigna el DataSet al GridView
            GVCategories.DataBind();              // Enlaza los datos con el GridView
        }

        //Metodo para limpiar los TextBox y los DDL
        private void Clear()
        {
            TBNombre.Text = "";  // Limpiar el TextBox
            HFCategoryId.Value = "";


        }
        // Guardar una nueva categoría
        protected void BtnSave_Click(object sender, EventArgs e)
        {
              // Captura el nombre de la categoría
            _nombre = TBNombre.Text;
            // Llamada a la lógica  para guardar la categoría
            executed = objCat.saveCategoria(_nombre);

            if (executed)
            {
                LblMsj.Text = "¡Categoría guardada exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();  // Limpiar el TextBox después de guardar
                showCategorias();       // Mostrar las categorías actualizadas
            }
            else
            {
                LblMsj.Text = "¡Error al guardar la categoría!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }


        }

      

        // Actualizar una categoría existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFCategoryId.Value);  // Obtener el ID de la categoría seleccionada
            _nombre = TBNombre.Text;    // Obtener el nombre de la categoría

            // Llamada a la lógica de negocio para actualizar la categoría
            executed = objCat.updateCategoria(_id, _nombre);

            if (executed)
            {
                LblMsj.Text = "¡Categoría actualizada exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();
                showCategorias();        // Mostrar las categorías actualizadas
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar la categoría!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila en el GridView y cargar los datos en los controles
        protected void GVCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID de la categoría seleccionada
            HFCategoryId.Value = GVCategories.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVCategories.SelectedRow.Cells[1].Text; // Cargar el nombre de la categoría
        }

        // Evento para eliminar una categoría
        protected void GVCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { 
       
            int categoryId = Convert.ToInt32(GVCategories.DataKeys[e.RowIndex].Values[0]);
             executed = objCat.deleteCategoria(categoryId);

            if (executed)
            {
                LblMsj.Text = "La Categoria se elimino exitosamente";
                GVCategories.EditIndex = -1;
                showCategorias();
            }
            else
            {
                LblMsj.Text = "Error al eliminar el producto";
            }
              
        }
    }
}