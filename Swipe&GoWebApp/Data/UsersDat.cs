using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{


    public class UsersDat // Nombre de la clase
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los usuarios
        public DataSet showUsuarios()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectUsuarios"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo usuario
        public bool saveUsuario(string _nombre, string _apellido, string _correo, string _contrasena, string _direccion, string _telefono, string _tipo, string _salt)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertUsuarios"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarChar).Value = _nombre;
            objSelectCmd.Parameters.Add("v_apellido", MySqlDbType.VarChar).Value = _apellido;
            objSelectCmd.Parameters.Add("v_correo", MySqlDbType.VarChar).Value = _correo;
            objSelectCmd.Parameters.Add("v_contrasena", MySqlDbType.Text).Value = _contrasena;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarChar).Value = _direccion;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarChar).Value = _telefono;
            objSelectCmd.Parameters.Add("v_tipo", MySqlDbType.Enum).Value = _tipo;
            objSelectCmd.Parameters.Add("v_salt", MySqlDbType.Text).Value = _salt;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para actualizar un usuario
        public bool updateUsuario(int _id, string _nombre, string _apellido, string _correo, string _contrasena, string _direccion, string _telefono, string _tipo, string _salt)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateUsuarios"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarChar).Value = _nombre;
            objSelectCmd.Parameters.Add("v_apellido", MySqlDbType.VarChar).Value = _apellido;
            objSelectCmd.Parameters.Add("v_correo", MySqlDbType.VarChar).Value = _correo;
            objSelectCmd.Parameters.Add("v_contrasena", MySqlDbType.Text).Value = _contrasena;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarChar).Value = _direccion;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarChar).Value = _telefono;
            objSelectCmd.Parameters.Add("v_tipo", MySqlDbType.Enum).Value = _tipo;
            objSelectCmd.Parameters.Add("v_salt", MySqlDbType.Text).Value = _salt;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para eliminar un usuario
        public bool deleteUsuario(int _id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteUsuarios"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _id;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}