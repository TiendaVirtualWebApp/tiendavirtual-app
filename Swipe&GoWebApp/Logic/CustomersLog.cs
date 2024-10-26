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
    public class CustomersLog
    {
        CustomersDat objCust = new CustomersDat();

        // Método para mostrar todos los clientes
        public DataSet showClientes()
        {
            return objCust.showClientes();
        }
        //Metodo para mostrar DDL
        public DataSet showClientesDDL()
        {
            return objCust.showClientesDDL();
        }
        // Método para guardar un nuevo cliente
        public bool saveCliente(string _nombre, string _apellido, string _direccion, string _telefono)
        {
            return objCust.saveCliente(_nombre, _apellido,_direccion, _telefono);
        }
        // Método para actualizar un cliente
        public bool updateCliente(int _id, string _nombre, string _apellido, string _direccion, string _telefono)
        {
            return objCust.updateCliente(_id, _nombre, _apellido, _direccion, _telefono);
        }
        // Método para eliminar un cliente
        public bool deleteCliente(int _id)
        {
            return objCust.deleteCliente(_id);
        }
    }
}