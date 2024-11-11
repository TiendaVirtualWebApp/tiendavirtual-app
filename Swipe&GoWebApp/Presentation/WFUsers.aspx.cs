using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logic;
using System.Security.Cryptography;
using SimpleCrypto;

namespace Presentation
{
    public partial class WFUsers : System.Web.UI.Page
    {
        // Instancia de la clase UsersDat para interactuar con la lógica
        UsersLog objUser = new UsersLog();

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _correo;
        private string _contrasena;
        private string _direccion;
        private string _telefono;
        private string _tipo;
        private string _salt;
        private string _encryptedPaddword;
        // Bandera para saber si la operación fue exitosa
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo se ejecuta cuando se carga la página por primera vez (no en postbacks)
            if (!Page.IsPostBack)
            {
                showUsuarios(); // Mostrar todos los usuarios
            }
        }

        // Mostrar todos los usuarios en el GridView
        private void showUsuarios()
        {
            DataSet objData = new DataSet();
            objData = objUser.showUsuarios(); // Obtiene todos los usuarios
            GVUsuarios.DataSource = objData; // Asigna el DataSet al GridView
            GVUsuarios.DataBind(); // Enlaza los datos con el GridView
        }

        // Método para limpiar los TextBox 
        private void Clear()
        {
            TBNombre.Text = "";
            TBApellido.Text = "";
            TBCorreo.Text = "";
            TBContrasena.Text = "";
            TBDireccion.Text = "";
            TBTelefono.Text = "";
            TBTipo.Text = "";
            HFUsuariosId.Value = "";
        }

        // Guardar un nuevo usuario
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            // Capturar los datos del usuario
            _nombre = TBNombre.Text;
            _apellido = TBApellido.Text;
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;
            _direccion = TBDireccion.Text;
            _telefono = TBTelefono.Text;
            _tipo = TBTipo.SelectedValue;
            _salt = cryptoService.GenerateSalt();
            _encryptedPaddword = cryptoService.Compute(_contrasena);

            // Llamada a la lógica para guardar el usuario
            executed = objUser.saveUsuario(_nombre, _apellido, _correo, _encryptedPaddword, _direccion, _telefono, _tipo, _salt);

            if (executed)
            {
                LblMsj.Text = "¡Usuario guardado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear(); // Limpiar los TextBox después de guardar
                showUsuarios(); // Mostrar los usuarios actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al guardar el usuario!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Actualizar un usuario existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            // Capturar los datos del usuario
            _id = Convert.ToInt32(HFUsuariosId.Value);
            _nombre = TBNombre.Text;
            _apellido = TBApellido.Text;
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;
            _direccion = TBDireccion.Text;
            _telefono = TBTelefono.Text;
            _tipo = TBTipo.SelectedValue;
            _salt = cryptoService.GenerateSalt();
            _encryptedPaddword = cryptoService.Compute(_contrasena);

            // Llamada a la lógica para guardar el usuario
            executed = objUser.updateUsuario(_id, _nombre, _apellido, _correo, _encryptedPaddword, _direccion, _telefono, _tipo, _salt);

            if (executed)
            {
                LblMsj.Text = "¡Usuario actualizado exitosamente!";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                Clear();
                showUsuarios(); // Mostrar los usuarios actualizados
            }
            else
            {
                LblMsj.Text = "¡Error al actualizar el usuario!";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Evento para seleccionar una fila en el GridView y cargar los datos en los controles
        protected void GVUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del usuario seleccionado
            HFUsuariosId.Value = GVUsuarios.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVUsuarios.SelectedRow.Cells[1].Text;
            TBApellido.Text = GVUsuarios.SelectedRow.Cells[2].Text;
            TBCorreo.Text = GVUsuarios.SelectedRow.Cells[3].Text;
            TBDireccion.Text = GVUsuarios.SelectedRow.Cells[5].Text;
            TBTelefono.Text = GVUsuarios.SelectedRow.Cells[6].Text;
            TBTipo.SelectedValue = GVUsuarios.SelectedRow.Cells[7].Text;
            
        }

        // Evento para eliminar un usuario
        protected void GVUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(GVUsuarios.DataKeys[e.RowIndex].Values[0]);
            executed = objUser.deleteUsuario(userId);

            if (executed)
            {
                LblMsj.Text = "El usuario se eliminó exitosamente";
                GVUsuarios.EditIndex = -1;
                LblMsj.ForeColor = System.Drawing.Color.Green;
                showUsuarios();
            }
            else
            {
                LblMsj.Text = "Error al eliminar el usuario";
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
