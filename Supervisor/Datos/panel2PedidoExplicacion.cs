using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel2PedidoExplicacion
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;
        string nombre;

        public string nombreAdministrador(int id_Administrador)
        { 
            db.buscarAdministradorPedidoEjercicioVideo(id_Administrador, ref nombre);
            return nombre;
        }

        public List<mostrarPedidoEjercicioVideoResult> mostrarEjerciciosVideo(int empresa)
        {
            return db.mostrarPedidoEjercicioVideo(empresa).ToList();
        }

        public int? paginadoEjercicioVideos(int empresa)
        {
            db.paginadoPedidoEjercicioVideo(empresa, ref cantidad);
            return cantidad;
        }

        public void borrarEjercicioVideo(int id_PedidoEjercicioVideo)
        {
            db.borrar_PedidoEjercicioVideo(id_PedidoEjercicioVideo);
        }

        public void actualizarIndice()
        {
            db.actualizarSecuenciaPedidoEjercicioVideo();
        }

        public void actualizarEjercicioVideo(int id_Administrador,bool realizadoOKPedidoEjercicioVideo, int id_PedidoEjercicioVideo, int empresa)
        {
            db.actualizar_PedidoEjercicioVideo(id_Administrador, realizadoOKPedidoEjercicioVideo, id_PedidoEjercicioVideo, empresa);
        }
    }
}
