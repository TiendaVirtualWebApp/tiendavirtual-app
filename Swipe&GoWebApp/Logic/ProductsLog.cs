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
    public class ProductsLog
    {
        ProductsDat objProd = new ProductsDat();

        // Método para mostrar todos los comentarios
        public DataSet showProductos()
        {
            return objProd.showProductos();
        }
        //Metodo para mostrar unicamente el id y la descripcion de los Provedores, en el DropDownList
        public DataSet showProductosDDL()
        {
            return objProd.showProductosDDL();
        }
        // Método para guardar un nuevo comentario
        public bool saveProducto(string _nombre, string _descripcion, decimal _precio, int _fkcategoria, int _fkproveedor)
        {
            return objProd.saveProducto(_nombre, _descripcion, _precio, _fkcategoria,_fkproveedor);
        }
        // Método para actualizar un comentario

        public bool updateProducto(int _id, string _nombre, string _descripcion, decimal _precio, int _fkcategoria, int _fkproveedor)
        {
            return objProd.updateProducto(_id, _nombre, _descripcion,_precio, _fkcategoria, _fkproveedor);
        }
        // Método para eliminar un comentario
        public bool deleteProducto(int _id)
        {
            return objProd.deleteProducto(_id);
        }
    }
}