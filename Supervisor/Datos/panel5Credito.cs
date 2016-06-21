using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel5Credito
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public List<mostrarMovimientosResult> mostrarMovimientos(int empresa)
        {
            return db.mostrarMovimientos(empresa).ToList();
        }

        public int? paginadoMovimientos(int empresa)
        {
            db.paginadoMovimientos(empresa, ref cantidad);
            return cantidad;
        }

        public void borrarMovimiento(int id_Movimiento)
        {
            db.borrarMovimientos(id_Movimiento);
        }

        public void actualizarIndice()
        {
            db.actualizarSecuenciaMovimientos();
        }


    }
}
