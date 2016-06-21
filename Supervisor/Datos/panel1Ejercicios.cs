using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1Ejercicios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;
        
        public void insertarEjercicio(string titulo, int id_TipoEjercicio, int id_TipoInstitucion, bool explicacionRealizada,string enunciadoMATH, string enunciadoLimpio, string ubicacionRespuestaImprimible, string ubicacionRespuestaVisible, string ubicacionVideos, string etiquetaAno, string etiquetaColegio, string etiquetaMateria, string etiquetaProfesor, string etiquetaTema)
        {
            db.insertarEjercicios(titulo, id_TipoEjercicio, id_TipoInstitucion, explicacionRealizada, enunciadoMATH, enunciadoLimpio, ubicacionRespuestaImprimible, ubicacionRespuestaVisible, ubicacionVideos, etiquetaAno, etiquetaColegio, etiquetaMateria, etiquetaProfesor, etiquetaTema);
        }


    }
}
