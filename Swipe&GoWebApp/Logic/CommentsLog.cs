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
    public class CommentsLog
    {
        CommentsDat objCom = new CommentsDat();

        // Método para mostrar todos los comentarios
        public DataSet showComentarios()
        { 
            return objCom.showComentarios();
        }

        // Método para mostrar DDL
        public DataSet showComentarioDDL()
        {
            return objCom.showComentarioDDL();
        }

        // Método para guardar un nuevo comentario
        public bool saveComentario(string _texto, DateTime _fecha, int _fkproducto, int _fkcliente)
        {
            return objCom.saveComentario(_texto, _fecha, _fkproducto, _fkcliente);
        }

        // Método para actualizar un comentario
        public bool updateComentario(int _id, string _texto, DateTime _fecha, int _fkproducto, int _fkcliente)
        {
            return objCom.updateComentario(_id, _texto, _fecha, _fkproducto, _fkcliente);
        }

        // Método para eliminar un comentario
        public bool deleteComentario(int _id)
        {
            return objCom.deleteComentario(_id);
        }
    }
}