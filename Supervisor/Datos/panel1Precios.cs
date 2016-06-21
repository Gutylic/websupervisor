using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1Precios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public int? paginadoEmpresas()
        { 
            db.paginadoEmpresa(ref cantidad);
            return cantidad;
        
        }

        public List<mostrarEmpresaResult> mostrarEmpresas()
        {
            return db.mostrarEmpresa().ToList();
        }

        public int? insertarEmpresas(string empresa)
        {
            db.insertarEmpresa(empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarEmpresa(int id_Empresa, string empresa)
        {
            db.actualizarEmpresa(id_Empresa, empresa);           
        }

        public int? verificaEmpresa(string Empresa)
        {
            db.verificarEmpresa(Empresa, ref cantidad);
            return cantidad;
        }

    }
}
