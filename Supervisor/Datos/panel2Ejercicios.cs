using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel2Ejercicios
    {

        DataClassesDataContext db = new DataClassesDataContext();

        public void actualizarEjercicio(string titulo, int id_TipoEjercicio,int id_TipoInstitucion, bool explicacionRealizada, string enunciadoMATH, string enunciadoLimpio, string ubicacionRespuestaImprimible, string ubicacionRespuestaVisible, string ubicacionVideos,string etiquetaAno, string etiquetaColegio, string etiquetaMateria, string etiquetaProfesor, string etiquetaTema, int id_Ejercicio)
        {
            db.actualizarEjercicio(titulo, id_TipoEjercicio, id_TipoInstitucion, explicacionRealizada, enunciadoMATH, enunciadoLimpio, ubicacionRespuestaImprimible, ubicacionRespuestaVisible, ubicacionVideos, etiquetaAno, etiquetaColegio, etiquetaMateria, etiquetaProfesor, etiquetaMateria, id_Ejercicio);   
        }

        public void actualizarTablaTema(int id_Tema, string tema, int etiquetaTema)
        {
            db.recargarTemaXML(id_Tema,tema,etiquetaTema);
        }

        public void actualizarTablaMateria(int id_Materia, string materia, int etiquetaMateria)
        {
            db.recargarMateriaXML(id_Materia, materia, etiquetaMateria);
        }

        public void actualizarTablaProfesor(int id_Profesor, string profesor, int etiquetaProfesor)
        {
            db.recargarProfesorXML(id_Profesor, profesor, etiquetaProfesor);
        }

        public void actualizarTablaColegio(int id_Colegio, string colegio, int etiquetaColegio)
        {
            db.recargarColegioXML(id_Colegio, colegio, etiquetaColegio);
        }

        public void actualizarTablaAno(int id_Ano, string Ano, int etiquetaAno)
        {
            db.recargarAnoXML(id_Ano, Ano, etiquetaAno);
        }

        public void borrarTablaColegio()
        {
            db.borrarColegio();
        }

        public void borrarTablaTema()
        {
            db.borrarTema();
        }

        public void borrarTablaMateria()
        {
            db.borrarMateria();
        }

        public void borrarTablaAno()
        {
            db.borrarAno();
        }

        public void borrarTablaProfesor()
        {
            db.borrarProfesor();
        }

    }
}
