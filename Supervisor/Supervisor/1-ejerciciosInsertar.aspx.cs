using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.IO;

namespace Supervisor
{
    public partial class _1_ejerciciosInsertar : System.Web.UI.Page
    {

        panel1Ejercicios p1E = new panel1Ejercicios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubirEjerciciio_Click(object sender, EventArgs e)
        {

            if (FileUpload_Ejercicio.HasFile)
            {

                string fileName = Path.GetFileNameWithoutExtension(FileUpload_Ejercicio.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/ejercicios"), FileUpload_Ejercicio.FileName);
                FileUpload_Ejercicio.SaveAs(saveXML);
                                
                string TextXML;
                StreamReader sr = new StreamReader(saveXML);
                TextXML = sr.ReadToEnd();
                sr.Close();


                string[] Contenido_Del_Archivo = TextXML.Split('╝');

                string enunciadoMATH = Contenido_Del_Archivo[0];
                string enunciadoLimpio = Contenido_Del_Archivo[1];
                string titulo = Contenido_Del_Archivo[2];
                string id_TipoInstitucion = Contenido_Del_Archivo[3];
                string id_TipoEjercicio = Contenido_Del_Archivo[4];
                string ubicacionRespuestaImprimible = Contenido_Del_Archivo[5];
                string ubicacionRespuestaVisible = Contenido_Del_Archivo[6];
                string ubicacionVideo = Contenido_Del_Archivo[7];
                string explicacionRealizada = Contenido_Del_Archivo[8];
                
                string etiquetaAno = Contenido_Del_Archivo[27];
                string etiquetaColegio = Contenido_Del_Archivo[28];
                string etiquetaMateria = Contenido_Del_Archivo[29];
                string etiquetaProfesor = Contenido_Del_Archivo[30];
                string etiquetaTema = Contenido_Del_Archivo[31];
               
                p1E.insertarEjercicio(titulo, int.Parse(id_TipoEjercicio),int.Parse(id_TipoInstitucion), bool.Parse(explicacionRealizada), enunciadoMATH,  enunciadoLimpio, ubicacionRespuestaImprimible, ubicacionRespuestaVisible, ubicacionVideo, etiquetaAno, etiquetaColegio, etiquetaMateria, etiquetaProfesor, etiquetaTema);
                
                // cartelito que dice que el ejercicio insertado
                
            }
            else
            {
               // cartelito de ejericicio no insertado
            }
                        
        }
    }
}