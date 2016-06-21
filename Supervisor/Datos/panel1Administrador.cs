using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void actualizarAdministrador(int id_Administrador, string contrasenaAdministrador) 
        {
            db.actualizarAdministrador(id_Administrador, contrasenaAdministrador);
        }

        public List<mostrarAdministradorResult> mostrarAdministradores(int empresa)
        {
            return db.mostrarAdministrador(empresa).ToList();
        }

        public int? contarAdministradores(int empresa)
        {
            db.paginadoAdministrador(empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarSupervisorDios(int id_Administrador, string contrasenaAdministrador, bool bloqueo)
        {
            db.actualizarSupervisoresDios(id_Administrador, contrasenaAdministrador,bloqueo);
        }

        public int? insertarAdministradorComun(string administrador, int empresa)
        {
            db.insertarAdministradorComun(administrador, empresa, ref cantidad);
            return cantidad;
        }

        public void borrarAdministrador(int id_Administrador)
        {
            db.borrarAdministrador(id_Administrador);
        }

        public void actualizarIndices()
        {
            db.actualizarSecuenciaAdministrador();
        }

        public int? verificarEmpresa(string empresa)
        {
            db.buscarEmpresa(empresa, ref cantidad);
            return cantidad;
        }
    }
}
