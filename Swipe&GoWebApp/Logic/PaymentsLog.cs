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
    public class PaymentsLog
    {
        PaymentsDat objPay = new PaymentsDat();

        // Método para mostrar todos los pagos de la tabla tbl_pagos
        public DataSet showPagos()
        {
            return objPay.showPagos();
        }

        // Método para mostrar DDL
        public DataSet showPagosDDL()
        {
            return objPay.showPagosDDL();
        }

        // Método para guardar un nuevo pago en la tabla tbl_pagos
        public bool savePago(DateTime _fecha, double _monto, string _metodo_pago, string _estado, int _fkpedido, int _fkcliente)
        {
            return objPay.savePago(_fecha, _monto, _metodo_pago, _estado, _fkpedido, _fkcliente);
        }

        // Método para actualizar un pago en la tabla tbl_pagos
        public bool updatePago(int _id, DateTime _fecha, double _monto, string _metodo_pago, string _estado, int _fkpedido, int _fkcliente)
        {
            return objPay.updatePago(_id, _fecha, _monto, _metodo_pago, _estado, _fkpedido, _fkcliente);
        }

        // Método para eliminar un pago en la tabla tbl_pagos
        public bool deletePago(int _id)
        {
            return objPay.deletePago(_id);
        }



    }
}