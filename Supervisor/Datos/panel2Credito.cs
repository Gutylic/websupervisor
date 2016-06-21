using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel2Credito
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public void insertaCargaAutomatica(decimal creditoUsuario, int id_Usuario, int empresa)
        {
            db.cargaCreditoAutomatico(creditoUsuario, id_Usuario, empresa);
        }



    }
}
