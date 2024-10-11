using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class PaymentsDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los pagos de la tabla tbl_pagos
        public DataSet showPagos()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectPagos";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo pago en la tabla tbl_pagos
        public bool savePago(DateTime _fecha, double _monto, string _metodo_pago, string _estado, int _fkpedido, int _fkcliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertPagos";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_fecha", MySqlDbType.DateTime).Value = _fecha;
            objSelectCmd.Parameters.Add("v_monto", MySqlDbType.Double).Value = _monto;
            objSelectCmd.Parameters.Add("v_metodo_pago", MySqlDbType.VarChar).Value = _metodo_pago;
            objSelectCmd.Parameters.Add("v_estado", MySqlDbType.VarChar).Value = _estado;
            objSelectCmd.Parameters.Add("v_pedido_id", MySqlDbType.Int32).Value = _fkpedido;
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

        // Método para actualizar un pago en la tabla tbl_pagos
        public bool updatePago(int _id, DateTime _fecha, double _monto, string _metodo_pago, string _estado, int _fkpedido, int _fkcliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdatePagos";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("v_fecha", MySqlDbType.DateTime).Value = _fecha;
            objSelectCmd.Parameters.Add("v_monto", MySqlDbType.Double).Value = _monto;
            objSelectCmd.Parameters.Add("v_metodo_pago", MySqlDbType.VarChar).Value = _metodo_pago;
            objSelectCmd.Parameters.Add("v_estado", MySqlDbType.VarChar).Value = _estado;
            objSelectCmd.Parameters.Add("v_pedido_id", MySqlDbType.Int32).Value = _fkpedido;
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

        // Método para eliminar un pago en la tabla tbl_pagos
        public bool deletePago(int _id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeletePagos";
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