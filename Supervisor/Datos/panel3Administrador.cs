using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel3Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void borrarIngreso(int id_ConsultaAdministrador)
        {
            db.borrarConsultaAdministrador(id_ConsultaAdministrador);
        }

        public List<mostrarIngresoAdministradorResult> mostarIngreso(int empresa)
        {
            return db.mostrarIngresoAdministrador(empresa).ToList();
        }

        public int? contarIngreso(int empresa)
        {
            db.paginadoIngresoAdministrador(empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarIndices()
        {
            db.actualizarSecuenciaConsultaAdministradores();
        }

    }
}
