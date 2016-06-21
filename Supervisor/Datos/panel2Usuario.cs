using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel2Usuario
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public List<mostrarPreguntaClientesResult> mostrarComentariosClientes(int empresa)
        {
            return db.mostrarPreguntaClientes(empresa).ToList();            
        }

        public int? paginadoComentarioClientes(int empresa)
        {
            db.paginadoPreguntaClientes(empresa, ref cantidad);
            return cantidad;
        }

        public void borrarPreguntaCliente(int id_PreguntaUsuario)
        {
            db.borrarPreguntaUsuario(id_PreguntaUsuario);
        }

        public void actualizarIndice()
        {
            db.actualizarSecuenciaPreguntaClientes();
        }


    }
}
