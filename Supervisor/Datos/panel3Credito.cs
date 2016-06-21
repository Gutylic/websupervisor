using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel3Credito
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void insertarCargaManual(decimal creditoUsuario, int id_Usuario, int id_TipoMovimiento, int empresa)
        {
            db.cargaCreditoManual(creditoUsuario, id_Usuario, id_TipoMovimiento, empresa);
        }

        public List<mostrarUsuarioCreditoResult> mostrarUsuarioCredito (int empresa)
        {
            return db.mostrarUsuarioCredito(empresa).ToList();
        }

        public int? paginadoUsuarioCredito(int empresa)
        {
            db.paginadoUsuarioCredito(empresa, ref cantidad);
            return cantidad;
        }

    }
}
