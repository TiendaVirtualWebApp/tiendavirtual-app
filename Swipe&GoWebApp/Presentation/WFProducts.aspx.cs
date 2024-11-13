using Logic;
using System.Data;
using System;
using System.Web.UI.WebControls;
using System.Globalization;


namespace Presentation
{
    public partial class WFProducts : System.Web.UI.Page
    {
        CategoriesLog objCat = new CategoriesLog();
        ProvidersLog objProv = new ProvidersLog();
        ProductsLog objProd = new ProductsLog();

        private int _id;
        private string _nombre ;
        private string _descripcion;
        private decimal _precio;
        private int _NomCat;
        private int _NomPro;
        private int fkCategoria;
        private int fkProveedor;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                showProductos();
                showCategoriasDDL();
                showProveedoresDDL();
            }
        }

        private void showCategoriasDDL()
        {
            DDLCategoria.DataSource = objCat.showCategoriasDDL();
            DDLCategoria.DataValueField = "cate_id";
            DDLCategoria.DataTextField = "cate_nombre";
            DDLCategoria.DataBind();
            DDLCategoria.Items.Insert(0, "Seleccione");
        }

        private void showProveedoresDDL()
        {
            DDLProveedor.DataSource = objProv.showProveedoresDDL();
            DDLProveedor.DataValueField = "prove_id";
            DDLProveedor.DataTextField = "Informacion";
            DDLProveedor.DataBind();
            DDLProveedor.Items.Insert(0, "Seleccione");
        }

        private void showProductos()
        {
            DataSet objData = objProd.showProductos();
            GVProducts.DataSource = objData;
            GVProducts.DataBind();
        }

        private void Clear()
        {
            HFProductsId.Value = "";
            TBNombre.Text = "";
            TBDescripcion.Text = "";
            TBPrecio.Text = "";
            DDLCategoria.SelectedIndex = 0;
            DDLProveedor.SelectedIndex = 0;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;
            _descripcion = TBDescripcion.Text;
            _precio = Convert.ToDecimal(TBPrecio.Text);
            _NomCat = Convert.ToInt32(DDLCategoria.SelectedValue);
            _NomPro = Convert.ToInt32(DDLProveedor.SelectedValue);

                executed = objProd.saveProducto(_nombre, _descripcion, _precio, _NomCat, _NomPro);

                if (executed)
                {
                    LblMsj.Text = "¡Producto guardado exitosamente!";
                    LblMsj.ForeColor = System.Drawing.Color.Green;
                    Clear();
                    showProductos();
                }
                else
                {
                    LblMsj.Text = "¡Error al guardar el producto!";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }
           
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFProductsId.Value);
            _nombre = TBNombre.Text;
            _descripcion = TBDescripcion.Text;
            _precio = Convert.ToDecimal(TBPrecio.Text);
            _NomCat = Convert.ToInt32(DDLCategoria.SelectedValue);
            _NomPro = Convert.ToInt32(DDLProveedor.SelectedValue);

            executed = objProd.updateProducto(_id, _nombre, _descripcion, _precio, _NomCat, _NomPro);

            if (executed)
                {
                    LblMsj.Text = "¡Producto actualizado exitosamente!";
                    LblMsj.ForeColor = System.Drawing.Color.Green;
                    Clear();
                showProductos();
                }
                else
                {
                    LblMsj.Text = "¡Error al actualizar el producto!";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }           
        }

        protected void GVProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFProductsId.Value = GVProducts.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVProducts.SelectedRow.Cells[1].Text;
            TBDescripcion.Text = GVProducts.SelectedRow.Cells[2].Text;
            TBPrecio.Text = GVProducts.SelectedRow.Cells[3].Text;
            DDLCategoria.SelectedValue = GVProducts.SelectedRow.Cells[4].Text;
            DDLProveedor.SelectedValue = GVProducts.SelectedRow.Cells[6].Text;
        }

        protected void GVProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pro_id = Convert.ToInt32(GVProducts.DataKeys[e.RowIndex].Values[0]);
            executed = objProd.deleteProducto(pro_id);

            if (executed)
            {
                LblMsj.Text = "¡Orden eliminada exitosamente!";
                GVProducts.EditIndex = -1;
                showProductos();
            }
            else
            {
                LblMsj.Text = "¡Error al eliminar la orden!";
            }
        }
    }
}
