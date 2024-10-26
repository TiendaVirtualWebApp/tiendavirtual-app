using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class UsersLog
    {
        UsersDat objUser = new UsersDat();

        // Método para mostrar todos los usuarios
        public DataSet showUsuarios()
        {
             return objUser.showUsuarios();
        }
        // Método para guardar un nuevo usuario
        public bool saveUsuario(string _nombre, string _apellido, string _correo, string _contrasena, string _direccion, string _telefono, string _tipo, string _salt)
        {
            return objUser.saveUsuario(_nombre, _apellido, _correo, _contrasena, _direccion, _telefono, _tipo, _salt);
        }
        // Método para actualizar un usuario
        public bool updateUsuario(int _id, string _nombre, string _apellido, string _correo, string _contrasena, string _direccion, string _telefono, string _tipo, string _salt)
        {
            return objUser.updateUsuario(_id, _nombre, _apellido, _correo, _contrasena, _direccion, _telefono, _tipo, _salt);
        }
        // Método para eliminar un usuario
        public bool deleteUsuario(int _id)
        {
            return objUser.deleteUsuario(_id);
        }
    }
}