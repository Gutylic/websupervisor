using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ingresoSupervisores
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? id_Administrador;
        int? empresa;

        public int? administradorLogueado(string administrador, string contrasenaAdministrador,string ipAddress)
        { 
            db.ingresoAdministrador(administrador,contrasenaAdministrador,ipAddress, ref id_Administrador);
            return id_Administrador;
        }

        public void administradorBloqueado(string administrador)
        {
            db.administradorBloqueado(administrador);
        }

        public int? administradorEmpresa(string administrador)
        {
            db.ingresoAdministradorEmpresa(administrador, ref empresa);
            return empresa;
        }


    }
}
