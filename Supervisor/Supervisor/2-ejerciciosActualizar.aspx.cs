using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.IO;
using System.Data;
using System.Data.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Supervisor
{
    public partial class _2_ejerciciosActualizar : System.Web.UI.Page
    {
        panel2Ejercicios p2E = new panel2Ejercicios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnActualizarEjercicio_Click(object sender, EventArgs e)
        {
            if (FileUpload_Ejercicio.HasFile)
            {
                string Valor_A_Analizar = FileUpload_Ejercicio.FileName.Substring(9, FileUpload_Ejercicio.FileName.Length - 13);
                
                try
                {
                    int id_Ejercicio = int.Parse(Valor_A_Analizar);
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

                    p2E.actualizarEjercicio(titulo, int.Parse(id_TipoEjercicio),int.Parse(id_TipoInstitucion),bool.Parse(explicacionRealizada), enunciadoMATH, enunciadoLimpio, ubicacionRespuestaImprimible, ubicacionRespuestaVisible, ubicacionVideo, etiquetaAno, etiquetaColegio, etiquetaMateria, etiquetaProfesor, etiquetaTema, id_Ejercicio);
                 
                    // cartelito de actualizacion realizada

                }
                catch (FormatException)
                {
                    // cartelito de actualizacion no realizada
                    return;
                }
                
            }
            else
            {
                return;
            }
        }

        public class Tabla
        {
            public string ID;
            public string Dato;
            public string Etiqueta;
        }

        protected void BtnRecargarTablaAno_Click(object sender, EventArgs e)
        {
            if (FileUpload_Ejercicio.HasFile)
            {
                if (FileUpload_Ejercicio.FileName != "Ano.xml")
                {
                    // cartelito error la tabla no esta
                }



                string fileName = Path.GetFileNameWithoutExtension(FileUpload_Ejercicio.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), FileUpload_Ejercicio.FileName);
                FileUpload_Ejercicio.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Ano.xml"));

                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Ano").Value,
                                         Dato = item.Element("Ano").Value,
                                         Etiqueta = item.Element("Etiqueta_Ano").Value,

                                     }).ToList();

                p2E.borrarTablaAno();

                foreach (Tabla item in Lista)
                {
                    Tabla_Ano Etiqueta_Final = new Tabla_Ano();

                    p2E.actualizarTablaAno(int.Parse(item.ID), item.Dato, int.Parse(item.Etiqueta));
                    
                }

                // cartelito de actualizacion
                return;
            }
            else
            {
                // cartelito de no actualizacion
                return;
            }
        }

        protected void BtnRecargarTablaMateria_Click(object sender, EventArgs e)
        {
            if (FileUpload_Ejercicio.HasFile)
            {
                if (FileUpload_Ejercicio.FileName != "Materia.xml")
                {
                    // cartelito error la tabla no esta
                }

                string fileName = Path.GetFileNameWithoutExtension(FileUpload_Ejercicio.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), FileUpload_Ejercicio.FileName);
                FileUpload_Ejercicio.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Materia.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Materia").Value,
                                         Dato = item.Element("Materia").Value,
                                         Etiqueta = item.Element("Etiqueta_Materia").Value,

                                     }).ToList();

                p2E.borrarTablaMateria();

                foreach (Tabla item in Lista)
                {
                    Tabla_Materia Etiqueta_Final = new Tabla_Materia();
                    p2E.actualizarTablaMateria(int.Parse(item.ID), item.Dato, int.Parse(item.Etiqueta));
                }

                // cartelito de carga correcta
                return;
            }
            else
            {
                // cartelito carga erronea
                return;
            }
        }

        protected void BtnRecargarTablaColegio_Click(object sender, EventArgs e)
        {
            if (FileUpload_Ejercicio.HasFile)
            {
                if (FileUpload_Ejercicio.FileName != "Colegio.xml")
                {
                    // cartelito error la tabla no esta
                }

                string fileName = Path.GetFileNameWithoutExtension(FileUpload_Ejercicio.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), FileUpload_Ejercicio.FileName);
                FileUpload_Ejercicio.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Colegio.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Colegio").Value,
                                         Dato = item.Element("Colegio").Value,
                                         Etiqueta = item.Element("Etiqueta_Colegio").Value,

                                     }).ToList();

                p2E.borrarTablaColegio();

                foreach (Tabla item in Lista)
                {
                    Tabla_Colegio Etiqueta_Final = new Tabla_Colegio();

                    p2E.actualizarTablaColegio(int.Parse(item.ID), item.Dato, int.Parse(item.Etiqueta));
                }

                // cartelito de actualizacion correcta
                return;
            }
             else
             {
                 // cartelito actualizacion erronea
                 return;
             }

        }

        protected void BtnRecargarTablaTema_Click(object sender, EventArgs e)
        {
            if (FileUpload_Ejercicio.HasFile)
            {
                if (FileUpload_Ejercicio.FileName != "Tema.xml")
                {
                    // cartelito error la tabla no esta
                }

                string fileName = Path.GetFileNameWithoutExtension(FileUpload_Ejercicio.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), FileUpload_Ejercicio.FileName);
                FileUpload_Ejercicio.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Tema.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Tema").Value,
                                         Dato = item.Element("Tema").Value,
                                         Etiqueta = item.Element("Etiqueta_Tema").Value,

                                     }).ToList();

                p2E.borrarTablaTema();

                foreach (Tabla item in Lista)
                {
                    Tabla_Tema Etiqueta_Final = new Tabla_Tema();

                    p2E.actualizarTablaTema(int.Parse(item.ID), item.Dato, int.Parse(item.Etiqueta));
                }


                // cartelito de actualizacion exitosa
                return;
            }
            else
            {
                // cartelito de actualizacion erronea
                return;
            }
        }

        protected void BtnRecargarTablaProfesor_Click(object sender, EventArgs e)
        {
            if (FileUpload_Ejercicio.HasFile)
            {
                if (FileUpload_Ejercicio.FileName != "Profesor.xml")
                {
                    // cartelito error la tabla no esta
                }

                string fileName = Path.GetFileNameWithoutExtension(FileUpload_Ejercicio.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), FileUpload_Ejercicio.FileName);
                FileUpload_Ejercicio.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Profesor.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Profesor").Value,
                                         Dato = item.Element("Profesor").Value,
                                         Etiqueta = item.Element("Etiqueta_Profesor").Value,

                                     }).ToList();

                p2E.borrarTablaProfesor();

                foreach (Tabla item in Lista)
                {
                    Tabla_Profesor Etiqueta_Final = new Tabla_Profesor();

                    p2E.actualizarTablaProfesor(int.Parse(item.ID), item.Dato, int.Parse(item.Etiqueta));
                }

                // cartelito actualizacion exitosa
                return;
            }
            else
            {
                // cartelito error en la actualizacion
                return;
            }
        }
    }
}