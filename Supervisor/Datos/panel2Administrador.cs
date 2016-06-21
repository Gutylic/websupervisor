using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel2Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void insertarComentario(int id_Administrador, string comentario)
        {
            db.insertarComentarioAdministrador(id_Administrador, comentario);
        }

        public void borrarComentario(int id_mensajeAdministrador)
        {
            db.borrarComentarioAdministrador(id_mensajeAdministrador);
        }

        public List<mostrarComentarioAdministradorResult> mostarComentario(int empresa)
        {
            return db.mostrarComentarioAdministrador(empresa).ToList();
        }

        public int? contarMensajes(int empresa)
        {
            db.paginadoComentarioAdministrador(empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarIndices()
        {
            db.actualizarSecuenciaMensajeAdministrador();
        }
    }
}
