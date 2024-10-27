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
    public class OrdersLog
    {
        OrdersDat objOr = new OrdersDat();

        // Método para mostrar todos los pedidos
        public DataSet showPedidos()
        {
            
            return objOr.showPedidos();
        }

        // Método para mostrar DDL
        public DataSet showPedidosDDL()
        {
            return objOr.showPedidosDDL();
        }

        // Método para guardar un nuevo pedido
        public bool savePedido(DateTime _fecha, string _estado, double _total, int _fkcliente)
        {
           
            return objOr.savePedido(_fecha, _estado, _total, _fkcliente);   
        }

        // Método para actualizar un pedido
        public bool updatePedido(int _id, DateTime _fecha, string _estado, double _total, int _fkcliente)
        {
            
           
            return objOr.updatePedido(_id, _fecha, _estado,_total, _fkcliente);
        }

        // Método para eliminar un pedido
        public bool deletePedido(int _id)
        {
            
            return objOr.deletePedido(_id);
        }

    }
}