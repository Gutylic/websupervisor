using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1Categoria
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? resultado;

        public int? insertarAdministradorDios(string Administrador, string Empresa)
        {
            if (Empresa.ToLower() == "dios")
            {
                db.insertarAdministrador(Administrador, 0, 1, ref resultado);
                return resultado;
            }
            
            db.buscarEmpresa(Empresa,ref resultado);

            if (resultado == -1)
            {
                return resultado;
            }

            db.insertarAdministrador(Administrador, resultado, 1, ref resultado);
            return resultado;
        }

        public List<buscarAdministradorResult> buscarAdministrador(string Administrador)
        {
            return db.buscarAdministrador(Administrador).ToList();
        }


        public List<mostrarCategoriaAdministradorResult> cargarCategoriaAdministrador(int id_Administrador)
        {
            return db.mostrarCategoriaAdministrador(id_Administrador).ToList();
        }

        public void actualizarCategoriaAdministrador(int id_Administrador, int a1, int a2, int a3, int u1, int u2, int p1, int p2, int p3, int p4, int ce1, int ce2, int c1, int c2, int c3, int c5, int ep1, int ep2)
        {
            db.actualizarAdministradorCategoria(id_Administrador, a1, a2, a3, u1, u2, p1, p2, p3, p4, ce1, ce2, 0, 0, c1, c2, c3, 0, c5, ep1, ep2);
        }


    }
}
