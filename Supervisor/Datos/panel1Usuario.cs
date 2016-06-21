using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1Usuario
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public List<buscarUsuarioResult> mostrarUsuarioAdministrador(string usuarioCorreo, string usuarioTelefono, string usuarioFacebook, int empresa)
        {
            return db.buscarUsuario(usuarioCorreo, usuarioTelefono, usuarioFacebook, empresa).ToList();
        }

        public void borrarUsuario(int id_Usuario)
        { 
            db.borrarUsuario(id_Usuario);
        }

        public void actualizarIndice()
        {
            db.actualizarSecuenciaUsuario();
        }

        public void actualizarIndiceMovimientos()
        {
            db.actualizarSecuenciaMovimientos();
        }

        public int? insertarUsuario(string usuarioCorreo, string usuarioTelefono, string password, int empresa)
        { 
            db.insertarUsuario(usuarioCorreo, usuarioTelefono, password, empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarUsuario(int id_Usuario, bool bloqueoUsuario, string telefono, int pais)
        {
            db.actualizarUsuario(id_Usuario, bloqueoUsuario, telefono, pais);
        }

        public List<mostrarUsuarioResult> mostrarUsuario(int empresa)
        {
            return db.mostrarUsuario(empresa).ToList();
        }

        public int? paginadoUsuario(int empresa)
        {
            db.paginadoUsuario(empresa, ref cantidad);
            return cantidad;
        }
    }
}
