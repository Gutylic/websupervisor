using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class datosPanelAdministradores
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void actualizarAdministradorPanel (int id_Administrador,string contrasenaAdministrador)
        {
            db.actualizarAdministrador(id_Administrador,contrasenaAdministrador);
        }

        public void borrarAdministradorPanel(int id_Administrador)
        {
            db.borrarAdministrador(id_Administrador);
        }

        public List<buscarAdministradorResult> buscarAdministrador(string administrador)
        {
            return db.buscarAdministrador(administrador).ToList();
        }

        public void insertarAdministradoresPanel (string administrador, int empresa)
        {
            db.insertarAdministrador(administrador,empresa);
        }

        public List<mostrarAdministradorResult> mostrarAdminitradoresPanel(int empresa)
        {
            return db.mostrarAdministrador(empresa).ToList();
        }

        public int? contarAdministradoresPanel(int empresa)
        {
            db.paginadoAdministrador(empresa, ref cantidad);
            return cantidad;
        }

    }
}
