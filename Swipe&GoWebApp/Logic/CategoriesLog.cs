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
    public class CategoriesLog
    {
        CategoriesDat objCat =new CategoriesDat();

        // Método para mostrar todas las categorías de la tabla tbl_categorias
        public DataSet showCategorias()
        {
           
            return objCat.showCategorias();
        }

        // Método para mostrar DDL
        public DataSet showCategoriasDDL()
        {
           
            return objCat.showCategoriasDDL();
        }

        // Método para guardar una nueva categoría en la tabla tbl_categorias
        public bool saveCategoria(string _nombre)
        {
           
            
            return objCat.saveCategoria(_nombre);
        }

        // Método para actualizar una categoría en la tabla tbl_categorias
        public bool updateCategoria(int _id, string _nombre)
        {
           
            return objCat.updateCategoria(_id, _nombre);
        }

        // Método para eliminar una categoría en la tabla tbl_categorias
        public bool deleteCategoria(int _id)
        {
            
            return objCat.deleteCategoria(_id);
        }


    }
}