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
    public class CartLog
    {

        CartDat objCart= new CartDat();
        // Método para mostrar todos los carritos de la tabla tbl_carrito
        public DataSet showCarrito()
        {
           
            return objCart.showCarrito();
        }

        // Método para mostrar DDL  
        public DataSet showCarritoDDL()
        {
           
            return objCart.showCarritoDDL();
        }

        // Método para guardar un nuevo carrito en la tabla tbl_carrito
        public bool saveCarrito(int _cantidad, decimal _precio_unitario, int _fkproducto, int _fkcliente)
        {
            
            return objCart.saveCarrito(_cantidad, _precio_unitario,_fkproducto, _fkcliente);
        }

        // Método para actualizar un carrito en la tabla tbl_carrito
        public bool updateCarrito(int _id, int _cantidad, decimal _precio_unitario, int _fkproducto, int _fkcliente)
        {

            return objCart.updateCarrito(_id, _cantidad, _precio_unitario, _fkproducto, _fkcliente);
        }

        // Método para eliminar un carrito en la tabla tbl_carrito
        public bool deleteCarrito(int _id)
        {
           
            return objCart.deleteCarrito(_id);
        }
    }
}