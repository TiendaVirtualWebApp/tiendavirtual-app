using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class CommentsDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los comentarios
        public DataSet showComentarios()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectComentarios"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo comentario
        public bool saveComentario(string _texto, DateTime _fecha, int _fkproducto, int _fkcliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertComentarios"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_texto", MySqlDbType.Text).Value = _texto;
            objSelectCmd.Parameters.Add("v_fecha", MySqlDbType.DateTime).Value = _fecha;
            objSelectCmd.Parameters.Add("v_producto_id", MySqlDbType.Int32).Value = _fkproducto;
            objSelectCmd.Parameters.Add("v_cliente_id", MySqlDbType.Int32).Value = _fkcliente;

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

        // Método para actualizar un comentario
        public bool updateComentario(int _id, string _texto, DateTime _fecha, int _fkproducto, int _fkcliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateComentarios"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("v_texto", MySqlDbType.Text).Value = _texto;
            objSelectCmd.Parameters.Add("v_fecha", MySqlDbType.DateTime).Value = _fecha;
            objSelectCmd.Parameters.Add("v_producto_id", MySqlDbType.Int32).Value = _fkproducto;
            objSelectCmd.Parameters.Add("v_cliente_id", MySqlDbType.Int32).Value = _fkcliente;

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

        // Método para eliminar un comentario
        public bool deleteComentario(int _id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteComentarios"; // Nombre del procedimiento almacenado
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