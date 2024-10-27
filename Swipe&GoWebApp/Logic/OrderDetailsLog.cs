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
    public class OrderDetailsLog
    {
        OrderDetailsDat objOrde = new OrderDetailsDat();

        // Método para mostrar todos los detalles de pedidos
        public DataSet showDetallesPedidos()
        {
            return objOrde.showDetallesPedidos();
        }

        // Método para mostrar DDL
        public DataSet showDetallesPedidosDDL()
        {
            return objOrde.showDetallesPedidosDDL();
        }

        // Método para guardar un nuevo detalle de pedido
        public bool saveDetallePedido(int _cantidad, decimal _precio, int _fkproducto, int _fkpedido)
        {
            return objOrde.saveDetallePedido(_cantidad, _precio, _fkproducto,_fkpedido);
        }

        // Método para actualizar un detalle de pedido
        public bool updateDetallePedido(int _id, int _cantidad, decimal _precio, int _fkproducto, int _fkpedido)
        {
            return objOrde.updateDetallePedido(_id, _cantidad, _precio, _fkproducto, _fkpedido);
        }

        // Método para eliminar un detalle de pedido
        public bool deleteDetallePedido(int _id)
        {
            return objOrde.deleteDetallePedido(_id);
        }
    }
}