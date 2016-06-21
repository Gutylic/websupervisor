using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel2Precios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public int? paginadoPrecios()
        {
            db.paginadoPrecios(ref cantidad);
            return cantidad;
        }

        public List<mostrarPreciosResult> mostrarPrecios(int empresa)
        {
            return db.mostrarPrecios(empresa).ToList();
        }

        public void actualizarPrecios(int empresas,int duracionVideos,int duracionEjercicios,decimal precioVideo, decimal precioEjercicio,decimal precioExplicacion,decimal precioImpresion, decimal recargaHabitue, int ejerciciosCompradosHabitue)
        {
            db.actualizarPrecios(empresas, duracionVideos, duracionEjercicios, precioVideo, precioEjercicio, precioExplicacion, precioImpresion, recargaHabitue, ejerciciosCompradosHabitue);
        }


    }
}
