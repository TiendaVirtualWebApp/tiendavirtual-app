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
    public class ProvidersLog
    {
        ProvidersDat objProv = new ProvidersDat();

        // Método para mostrar todos los proveedores
        public DataSet showProveedores()
        {
            return objProv.showProveedores();
        }
        //Metodo para mostrar unicamente el id y la descripcion de los Provedores, en el DropDownList
        public DataSet showProveedoresDDL()
        {
            return objProv.showProveedoresDDL();
        }
        // Método para guardar un nuevo proveedor
        public bool saveProveedor(string _nombre, string _contacto, string _direccion)
        {
            return objProv.saveProveedor(_nombre, _contacto, _direccion);
        }
        // Método para actualizar un proveedor
        public bool updateProveedor(int _id, string _nombre, string _contacto, string _direccion)
        {
            return objProv.updateProveedor(_id, _nombre, _contacto, _direccion);
        }
        // Método para eliminar un proveedor
        public bool deleteProveedor(int _id)
        {
            return objProv.deleteProveedor(_id);
        }
    }
}