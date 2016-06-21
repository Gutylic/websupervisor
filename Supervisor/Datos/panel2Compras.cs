using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel2Compras
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void borrarMisExplicaciones(int id_CompraVideos)
        {
            db.borrarMisEjercicios(id_CompraVideos);
        }

        public void actualizarMisExplicaciones(int id_CompraVideos, int vencimiento)
        {
            db.actualizarMisExplicaciones(id_CompraVideos, vencimiento);
        }

        public int? insertarMisExplicaciones(int id_Usuario, int id_Ejercicio, bool video,int id_Empresa)
        {
            db.ingresoMisExplicaciones(id_Usuario, id_Ejercicio, video, id_Empresa, ref cantidad);
            return cantidad;
        }

        public List<mostrarMisExplicacionesResult> mostrarMisExplicaciones(int id_Empresa)
        {
            return db.mostrarMisExplicaciones(id_Empresa).ToList();
        }

        public int? paginadoMisExplicaicones(int id_Empresa)
        {
            db.paginadoMisExplicaciones(id_Empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarIndice()
        {
            db.actualizarSecuenciaMisExplicaciones();
        }

    }
}
