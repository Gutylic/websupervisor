using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1Compras
    {
        
        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void borrarMisEjercicios(int id_CompraEjerciciosExplicaciones)
        {
            db.borrarMisEjercicios(id_CompraEjerciciosExplicaciones);
        }

        public void actualizarMisEjercicios(int id_CompraEjercicioExplicaciones, bool ejercicio, bool explicacion , int vencimiento)
        {
            db.actualizarMisEjercicios(id_CompraEjercicioExplicaciones, ejercicio, explicacion, vencimiento);
        }

        public int? insertarMisEjercicios(int id_Usuario, int id_Ejercicio, bool ejercicio, bool explicacion, int id_Empresa)
        {
            db.ingresoMisEjercicios(id_Usuario, id_Ejercicio, ejercicio, explicacion, id_Empresa, ref cantidad);
            return cantidad;
        }

        public List<mostrarMisEjerciciosResult> mostrarMisEjercicios(int id_Empresa)
        {
            return db.mostrarMisEjercicios(id_Empresa).ToList();
        }

        public int? paginadoMisEjercicios(int id_Empresa)
        {
            db.paginadoMisEjercicios(id_Empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarIndice()
        {
            db.actualizarSecuenciaMisEjercicios();
        }

    }
}
