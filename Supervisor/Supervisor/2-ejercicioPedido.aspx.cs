using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace Supervisor
{
    public partial class _2_ejercicioPedido : System.Web.UI.Page
    {

        panel2PedidoExplicacion p2PE = new panel2PedidoExplicacion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                // Administrador
                //Boton_No_Resolver_Administrador.Visible = false;
                //Boton_Resolver_Administrador.Visible = false;
                //Boton_Resuelto_Administrador.Visible = false;                
                //Boton_Cerrar_Formulario_Administrador.Visible = false;
                //MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), 0);
                //PaginadoGridViewAdministrador(Convert.ToInt16(Session["Empresa"]));


                // Supervisor
                //Boton_No_Resolver_Supervisor.Visible = false;
                //Boton_Resolver_Supervisor.Visible = false;
                //Boton_Resuelto_Supervisor.Visible = false;
                //Boton_Borrar_Supervisor.Visible = false;
                //Boton_Cerrar_Formulario_Supervisor.Visible = false;
                //MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
                //PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));

                // Dios              

                Boton_No_Resolver_Dios.Visible = false;
                Boton_Resolver_Dios.Visible = false;
                Boton_Resuelto_Dios.Visible = false;
                Boton_Borrar_Dios.Visible = false;
                Boton_Cerrar_Formulario_Dios.Visible = false;
                MostrarGridViewDios(0, 0);
                PaginadoGridViewDios(0);
            }

        }

        // Administrador

        public void MostrarGridViewAdministrador(int empresa, int pagina)
        {
            Formulario_Administrador.Visible = false;            
            GridView_Administrador.DataSource = p2PE.mostrarEjerciciosVideo(empresa).Skip(pagina * 10).Take(10);
            GridView_Administrador.DataBind();
        }

        public void PaginadoGridViewAdministrador(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Administrador.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Administrador_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Administrador_Ultimo.Visible = false; // anterior de la ultima pagina           
            ViewState["Cantidad_De_Datos"] = p2PE.paginadoEjercicioVideos(empresa); // cuenta la cantidad de datos
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 10; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 10; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 10) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Administrador_Primero.Visible = false;
            }
        }

        protected void Siguiente_Administrador_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina            
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Administrador.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Administrador.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Administrador_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Administrador_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Administrador.Visible = true; // estoy en las paginas del centro
                Extremo_Administrador.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Administrador_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Administrador.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Administrador.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Administrador_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Administrador_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Administrador.Visible = true; // estoy en las paginas del centro
                Extremo_Administrador.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Identificador_Administrador(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Administrador.Visible = true;
            GridView_Administrador.Visible = false;
            Centro_Administrador.Visible = false;
            Siguiente_Administrador_Primero.Visible = false;
            Anterior_Administrador_Ultimo.Visible = false;
            Boton_No_Resolver_Administrador.Visible = true;
            Boton_Resolver_Administrador.Visible = true;
            Boton_Resuelto_Administrador.Visible = true;
            
            Boton_Cerrar_Formulario_Administrador.Visible = true;

            List<mostrarPedidoEjercicioVideoResult> Datos = p2PE.mostrarEjerciciosVideo(0); // carga los datos del administrador elegido por el Administrador            
            GridViewRow row = GridView_Administrador.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_PedidoEjercicioVideo"] = GridView_Administrador.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            Usuario_Administrador.Text = (Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].id_Usuario).ToString(); // carga el administrador de la base
            FechaPedido_Administrador.Text = (Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].fechaPedidoEjercicioVideo).ToString();            
            string Profesor = p2PE.nombreAdministrador(Convert.ToInt16(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].id_Administrador));
            Profesor_Administrador.Text = Profesor;
            CheckBoxEjercicio_Administrador.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].pedidoEjercicio); // carga el password de la base                       
            CheckBoxExplicacion_Administrador.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].pedidoExplicacion);
            CheckBoxRealizadoOK_Administrador.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].realizadoOKPedidoEjercicioVideo);
            Session["Adjunto"] = Datos[0].adjuntoEjercicioVideo;
            Session["Ficha"] = Datos[0].fichaEjercicioVideo;
            Session["Enunciado"] = Datos[0].enunciadoEjercicioVideoMATH;
            
            Boton_No_Resolver_Administrador.Enabled = true;
            Boton_Resolver_Administrador.Enabled = true;
            Boton_Resuelto_Administrador.Enabled = true;
            
            if (Profesor_Administrador.Text == string.Empty)
            {
                Boton_No_Resolver_Administrador.Enabled = false;
                Boton_Resuelto_Administrador.Enabled = false;
            }

            if (Profesor_Administrador.Text != string.Empty)
            {
                Boton_Resolver_Administrador.Enabled = false;
            }

            if (CheckBoxRealizadoOK_Administrador.Checked == true)
            {
                Boton_Resolver_Administrador.Enabled = false;
                Boton_No_Resolver_Administrador.Enabled = false;
                Boton_Resuelto_Administrador.Enabled = false;
            }

            if (Profesor_Administrador.Text != Session["Administrador"].ToString())
            {
                Boton_No_Resolver_Administrador.Enabled = false;
                Boton_Resuelto_Administrador.Enabled = false;
            }

        }
        
        protected void Boton_No_Resolver_Administrador_Click(object sender, EventArgs e)
        {
            Profesor_Administrador.Text = string.Empty;
          
            p2PE.actualizarEjercicioVideo(0, CheckBoxRealizadoOK_Administrador.Checked, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));
                        
            Boton_No_Resolver_Administrador.Visible = false;
            Boton_Resuelto_Administrador.Visible = false;
            Boton_Resolver_Administrador.Visible = false;
            
            Formulario_Administrador.Visible = false;
            Extremo_Administrador.Visible = true;
            Siguiente_Administrador_Primero.Visible = true;
            Boton_Cerrar_Formulario_Administrador.Visible = false;
            GridView_Administrador.Visible = true;
            MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewAdministrador(Convert.ToInt16(Session["Empresa"]));

        }

        protected void Boton_Borrar_Administrador_Click(object sender, EventArgs e)
        {
            p2PE.borrarEjercicioVideo((int)Session["ID_PedidoEjercicioVideo"]);
            p2PE.actualizarIndice();

            Boton_No_Resolver_Administrador.Visible = false;
            Boton_Resuelto_Administrador.Visible = false;
            Boton_Resolver_Administrador.Visible = false;
          
            Formulario_Administrador.Visible = false;
            Extremo_Administrador.Visible = true;
            Siguiente_Administrador_Primero.Visible = true;
            Boton_Cerrar_Formulario_Administrador.Visible = false;
            GridView_Administrador.Visible = true;
            MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewAdministrador(Convert.ToInt16(Session["Empresa"]));
            // cartelito de administrador borrado
        }
        
        protected void Boton_Resolver_Administrador_Click(object sender, EventArgs e)
        {
            p2PE.actualizarEjercicioVideo((int)Session["ID_Administrador"], false, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));
            // cartelito de usted pidio resolver este ejercicio

            Boton_No_Resolver_Administrador.Visible = false;
            Boton_Resolver_Administrador.Visible = false;
            Boton_Resuelto_Administrador.Visible = false;
          
            Boton_Cerrar_Formulario_Administrador.Visible = false;

            Extremo_Administrador.Visible = true;
            Siguiente_Administrador_Primero.Visible = true;
            Formulario_Administrador.Visible = false;
            GridView_Administrador.Visible = true;
            MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewAdministrador(Convert.ToInt16(Session["Empresa"]));

        }
       
        protected void Boton_Resuelto_Administrador_Click(object sender, EventArgs e)
        {
            p2PE.actualizarEjercicioVideo((int)Session["ID_Administrador"], true, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));
            
            Boton_No_Resolver_Administrador.Visible = false;
            Boton_Resuelto_Administrador.Visible = false;
            Boton_Resolver_Administrador.Visible = false;
            
            Formulario_Administrador.Visible = false;
            Extremo_Administrador.Visible = true;
            Siguiente_Administrador_Primero.Visible = true;
            Boton_Cerrar_Formulario_Administrador.Visible = false;
            GridView_Administrador.Visible = true;
            MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewAdministrador(Convert.ToInt16(Session["Empresa"]));
                        
            // cartelito de usted ya resolvio el ejercicio
        }
      
        protected void BtnAdjunto_Administrador_Click(object sender, EventArgs e)
        {        
            if (Session["Adjunto"] == null)
            {
                // cartelito que no hay adjunto
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Adjunto"]);
            Response.TransmitFile("C:\\archivo/" + (string)Session["Adjunto"]);
            Response.End();        
        }

        protected void BtnFicha_Administrador_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Ficha"] + "_ficha.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Ficha"] + "_ficha.txt");
            Response.End();
        }

        protected void BtnMath_Administrador_Click(object sender, EventArgs e)
        {
            if (Session["Enunciado"] == null)
            {
                // cartelito que no tiene enunciado
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Enunciado"] + "_math.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Enunciado"] + "_math.txt");
            Response.End();
        }

        protected void BtnLimpio_Administrador_Click(object sender, EventArgs e)
        {
            if (Session["Enunciado"] == null)
            {
                // cartelito que no tiene enunciado
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Enunciado"] + "_clean.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Enunciado"] + "_clean.txt");
            Response.End();
        }

        protected void Boton_Cerrar_Formulario_Administrador_Click(object sender, EventArgs e)
        {
            Boton_No_Resolver_Administrador.Visible = false;
            Boton_Resolver_Administrador.Visible = false;
            Boton_Resuelto_Administrador.Visible = false;


            Boton_Cerrar_Formulario_Administrador.Visible = false;
            Extremo_Administrador.Visible = true;
            Siguiente_Administrador_Primero.Visible = true;
            Formulario_Administrador.Visible = false;
            GridView_Administrador.Visible = true;
            MostrarGridViewAdministrador(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewAdministrador(Convert.ToInt16(Session["Empresa"]));
        }
              
        
        // supervisores

        public void MostrarGridViewSupervisor(int empresa, int pagina)
        {
            Formulario_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            GridView_Supervisor.DataSource = p2PE.mostrarEjerciciosVideo(empresa).Skip(pagina * 10).Take(10);
            GridView_Supervisor.DataBind();
        }

        public void PaginadoGridViewSupervisor(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina           
            ViewState["Cantidad_De_Datos"] = p2PE.paginadoEjercicioVideos(empresa); // cuenta la cantidad de datos
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 10; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 10; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 10) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Supervisor_Primero.Visible = false;
            }
        }

        protected void Siguiente_Supervisor_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina            
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Supervisor.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Supervisor.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Supervisor_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Supervisor.Visible = true; // estoy en las paginas del centro
                Extremo_Supervisor.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Supervisor_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Supervisor.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Supervisor.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Supervisor_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Supervisor.Visible = true; // estoy en las paginas del centro
                Extremo_Supervisor.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Identificador_Supervisor(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Supervisor.Visible = true;
            GridView_Supervisor.Visible = false;
            Centro_Supervisor.Visible = false;
            Siguiente_Supervisor_Primero.Visible = false;
            Anterior_Supervisor_Ultimo.Visible = false;
            Boton_No_Resolver_Supervisor.Visible = true;
            Boton_Resolver_Supervisor.Visible = true;
            Boton_Resuelto_Supervisor.Visible = true;
            Boton_Borrar_Supervisor.Visible = true;
            Boton_Excel_Supervisor.Visible = false;
            Boton_Cerrar_Formulario_Supervisor.Visible = true;

            List<mostrarPedidoEjercicioVideoResult> Datos = p2PE.mostrarEjerciciosVideo(0); // carga los datos del administrador elegido por el supervisor            
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_PedidoEjercicioVideo"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            Usuario_Supervisor.Text = (Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].id_Usuario).ToString(); // carga el administrador de la base
            FechaPedido_Supervisor.Text = (Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].fechaPedidoEjercicioVideo).ToString();            
            string Profesor = p2PE.nombreAdministrador(Convert.ToInt16(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].id_Administrador));
            Profesor_Supervisor.Text = Profesor;
            CheckBoxEjercicio_Supervisor.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].pedidoEjercicio); // carga el password de la base                       
            CheckBoxExplicacion_Supervisor.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].pedidoExplicacion);
            CheckBoxRealizadoOK_Supervisor.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].realizadoOKPedidoEjercicioVideo);
            Session["Adjunto"] = Datos[0].adjuntoEjercicioVideo;
            Session["Ficha"] = Datos[0].fichaEjercicioVideo;
            Session["Enunciado"] = Datos[0].enunciadoEjercicioVideoMATH;
            
            Boton_No_Resolver_Supervisor.Enabled = true;
            Boton_Resolver_Supervisor.Enabled = true;
            Boton_Resuelto_Supervisor.Enabled = true;

            if (Profesor_Supervisor.Text == string.Empty)
            {
                Boton_No_Resolver_Supervisor.Enabled = false;
                Boton_Resuelto_Supervisor.Enabled = false;
            }

            if (Profesor_Supervisor.Text != string.Empty)
            {
                Boton_Resolver_Supervisor.Enabled = false;
            }

            if (CheckBoxRealizadoOK_Supervisor.Checked == true)
            {
                Boton_Resolver_Supervisor.Enabled = false;
                Boton_No_Resolver_Supervisor.Enabled = false;
                Boton_Resuelto_Supervisor.Enabled = false;
            }



        }
        
        protected void Boton_No_Resolver_Supervisor_Click(object sender, EventArgs e)
        {
            Profesor_Supervisor.Text = string.Empty;
          
            p2PE.actualizarEjercicioVideo(0, CheckBoxRealizadoOK_Supervisor.Checked, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));
                        
            Boton_No_Resolver_Supervisor.Visible = false;
            Boton_Resuelto_Supervisor.Visible = false;
            Boton_Resolver_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;

            Boton_Excel_Supervisor.Visible = true;
            Formulario_Supervisor.Visible = false;
            Extremo_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));

        }

        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {
            p2PE.borrarEjercicioVideo((int)Session["ID_PedidoEjercicioVideo"]);
            p2PE.actualizarIndice();

            Boton_No_Resolver_Supervisor.Visible = false;
            Boton_Resuelto_Supervisor.Visible = false;
            Boton_Resolver_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;
            
            Boton_Excel_Supervisor.Visible = true;
            Formulario_Supervisor.Visible = false;
            Extremo_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
            // cartelito de administrador borrado
        }
        
        protected void Boton_Resolver_Supervisor_Click(object sender, EventArgs e)
        {
            p2PE.actualizarEjercicioVideo((int)Session["ID_Administrador"], false, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));
            // cartelito de usted pidio resolver este ejercicio

            Boton_No_Resolver_Supervisor.Visible = false;
            Boton_Resolver_Supervisor.Visible = false;
            Boton_Resuelto_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;

            Extremo_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));

        }
       
        protected void Boton_Resuelto_Supervisor_Click(object sender, EventArgs e)
        {
            p2PE.actualizarEjercicioVideo((int)Session["ID_Administrador"], true, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));
            
            Boton_No_Resolver_Supervisor.Visible = false;
            Boton_Resuelto_Supervisor.Visible = false;
            Boton_Resolver_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;

            Formulario_Supervisor.Visible = false;
            Extremo_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
            
            
            // cartelito de usted ya resolvio el ejercicio
        }
      
        protected void BtnAdjunto_Supervisor_Click(object sender, EventArgs e)
        {        
            if (Session["Adjunto"] == null)
            {
                // cartelito que no hay adjunto
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Adjunto"]);
            Response.TransmitFile("C:\\archivo/" + (string)Session["Adjunto"]);
            Response.End();        
        }

        protected void BtnFicha_Supervisor_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Ficha"] + "_ficha.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Ficha"] + "_ficha.txt");
            Response.End();
        }

        protected void BtnMath_Supervisor_Click(object sender, EventArgs e)
        {
            if (Session["Enunciado"] == null)
            {
                // cartelito que no tiene enunciado
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Enunciado"] + "_math.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Enunciado"] + "_math.txt");
            Response.End();
        }

        protected void BtnLimpio_Supervisor_Click(object sender, EventArgs e)
        {
            if (Session["Enunciado"] == null)
            {
                // cartelito que no tiene enunciado
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Enunciado"] + "_clean.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Enunciado"] + "_clean.txt");
            Response.End();
        }
        

        protected void Boton_Excel_Supervisor_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Supervisor.DataSourceID = string.Empty;
            GridView_Supervisor.EnableViewState = false;
            GridView_Supervisor.AllowPaging = false;
            GridView_Supervisor.DataSource = p2PE.mostrarEjerciciosVideo(Convert.ToInt16(Session["Empresa"]));
            GridView_Supervisor.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Supervisor);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_EjerciciosPedidos.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void Boton_Cerrar_Formulario_Supervisor_Click(object sender, EventArgs e)
        {
            Boton_No_Resolver_Supervisor.Visible = false;
            Boton_Resolver_Supervisor.Visible = false;
            Boton_Resuelto_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            Extremo_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
        }


        // Dios

        public void MostrarGridViewDios(int empresa, int pagina)
        {
            Formulario_Dios.Visible = false;
            Boton_Excel_Dios.Visible = true;
            GridView_Dios.DataSource = p2PE.mostrarEjerciciosVideo(empresa).Skip(pagina * 10).Take(10);
            GridView_Dios.DataBind();
        }

        public void PaginadoGridViewDios(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina           
            ViewState["Cantidad_De_Datos"] = p2PE.paginadoEjercicioVideos(empresa); // cuenta la cantidad de datos
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 10; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 10; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 10) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Dios_Primero.Visible = false;
            }
        }

        protected void Siguiente_Dios_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina            
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                MostrarGridViewDios(0, (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Dios.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Dios.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Dios_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                MostrarGridViewDios(0, (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Dios_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                MostrarGridViewDios(0, (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Dios.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Dios.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Dios_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                MostrarGridViewDios(0, (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Identificador_Dios(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Dios.Visible = true;
            GridView_Dios.Visible = false;
            Centro_Dios.Visible = false;
            Siguiente_Dios_Primero.Visible = false;
            Anterior_Dios_Ultimo.Visible = false;
            Boton_No_Resolver_Dios.Visible = true;
            Boton_Resolver_Dios.Visible = true;
            Boton_Resuelto_Dios.Visible = true;
            Boton_Borrar_Dios.Visible = true;
            Boton_Excel_Dios.Visible = false;
            Boton_Cerrar_Formulario_Dios.Visible = true;

            List<mostrarPedidoEjercicioVideoResult> Datos = p2PE.mostrarEjerciciosVideo(0); // carga los datos del administrador elegido por el Dios            
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_PedidoEjercicioVideo"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            Usuario_Dios.Text = (Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].id_Usuario).ToString(); // carga el administrador de la base
            FechaPedido_Dios.Text = (Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].fechaPedidoEjercicioVideo).ToString();
            string Profesor = p2PE.nombreAdministrador(Convert.ToInt16(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].id_Administrador));
            Profesor_Dios.Text = Profesor;
            CheckBoxEjercicio_Dios.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].pedidoEjercicio); // carga el password de la base                       
            CheckBoxExplicacion_Dios.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].pedidoExplicacion);
            CheckBoxRealizadoOK_Dios.Checked = Convert.ToBoolean(Datos[(int)Session["ID_PedidoEjercicioVideo"] - 1].realizadoOKPedidoEjercicioVideo);
            Session["Adjunto"] = Datos[0].adjuntoEjercicioVideo;
            Session["Ficha"] = Datos[0].fichaEjercicioVideo;
            Session["Enunciado"] = Datos[0].enunciadoEjercicioVideoMATH;

            Boton_No_Resolver_Dios.Enabled = true;
            Boton_Resolver_Dios.Enabled = true;
            Boton_Resuelto_Dios.Enabled = true;

            if (Profesor_Dios.Text == string.Empty)
            {
                Boton_No_Resolver_Dios.Enabled = false;
                Boton_Resuelto_Dios.Enabled = false;
            }

            if (Profesor_Dios.Text != string.Empty)
            {
                Boton_Resolver_Dios.Enabled = false;
            }

            if (CheckBoxRealizadoOK_Dios.Checked == true)
            {
                Boton_Resolver_Dios.Enabled = false;
                Boton_No_Resolver_Dios.Enabled = false;
                Boton_Resuelto_Dios.Enabled = false;
            }



        }

        protected void Boton_No_Resolver_Dios_Click(object sender, EventArgs e)
        {
            Profesor_Dios.Text = string.Empty;

            p2PE.actualizarEjercicioVideo(0, CheckBoxRealizadoOK_Dios.Checked, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));

            Boton_No_Resolver_Dios.Visible = false;
            Boton_Resuelto_Dios.Visible = false;
            Boton_Resolver_Dios.Visible = false;
            Boton_Borrar_Dios.Visible = false;

            Boton_Excel_Dios.Visible = true;
            Formulario_Dios.Visible = false;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);

        }

        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            p2PE.borrarEjercicioVideo((int)Session["ID_PedidoEjercicioVideo"]);
            p2PE.actualizarIndice();

            Boton_No_Resolver_Dios.Visible = false;
            Boton_Resuelto_Dios.Visible = false;
            Boton_Resolver_Dios.Visible = false;
            Boton_Borrar_Dios.Visible = false;

            Boton_Excel_Dios.Visible = true;
            Formulario_Dios.Visible = false;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);
            // cartelito de administrador borrado
        }

        protected void Boton_Resolver_Dios_Click(object sender, EventArgs e)
        {
            p2PE.actualizarEjercicioVideo((int)Session["ID_Administrador"], false, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));
            // cartelito de usted pidio resolver este ejercicio

            Boton_No_Resolver_Dios.Visible = false;
            Boton_Resolver_Dios.Visible = false;
            Boton_Resuelto_Dios.Visible = false;
            Boton_Borrar_Dios.Visible = false;
            Boton_Excel_Dios.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;

            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);

        }

        protected void Boton_Resuelto_Dios_Click(object sender, EventArgs e)
        {
            p2PE.actualizarEjercicioVideo((int)Session["ID_Administrador"], true, (int)Session["ID_PedidoEjercicioVideo"], Convert.ToInt16(Session["Empresa"]));

            Boton_No_Resolver_Dios.Visible = false;
            Boton_Resuelto_Dios.Visible = false;
            Boton_Resolver_Dios.Visible = false;
            Boton_Borrar_Dios.Visible = false;
            Boton_Excel_Dios.Visible = true;

            Formulario_Dios.Visible = false;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);


            // cartelito de usted ya resolvio el ejercicio
        }

        protected void BtnAdjunto_Dios_Click(object sender, EventArgs e)
        {
            if (Session["Adjunto"] == null)
            {
                // cartelito que no hay adjunto
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Adjunto"]);
            Response.TransmitFile("C:\\archivo/" + (string)Session["Adjunto"]);
            Response.End();
        }

        protected void BtnFicha_Dios_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Ficha"] + "_ficha.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Ficha"] + "_ficha.txt");
            Response.End();
        }

        protected void BtnMath_Dios_Click(object sender, EventArgs e)
        {
            if (Session["Enunciado"] == null)
            {
                // cartelito que no tiene enunciado
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Enunciado"] + "_math.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Enunciado"] + "_math.txt");
            Response.End();
        }

        protected void BtnLimpio_Dios_Click(object sender, EventArgs e)
        {
            if (Session["Enunciado"] == null)
            {
                // cartelito que no tiene enunciado
                return;
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Enunciado"] + "_clean.txt");
            Response.TransmitFile("C:\\archivo/" + (string)Session["Enunciado"] + "_clean.txt");
            Response.End();
        }


        protected void Boton_Excel_Dios_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Dios.DataSourceID = string.Empty;
            GridView_Dios.EnableViewState = false;
            GridView_Dios.AllowPaging = false;
            GridView_Dios.DataSource = p2PE.mostrarEjerciciosVideo(0);
            GridView_Dios.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_EjerciciosPedidos.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void Boton_Cerrar_Formulario_Dios_Click(object sender, EventArgs e)
        {
            Boton_No_Resolver_Dios.Visible = false;
            Boton_Resolver_Dios.Visible = false;
            Boton_Resuelto_Dios.Visible = false;
            Boton_Borrar_Dios.Visible = false;
            Boton_Excel_Dios.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);
        }
    }
}