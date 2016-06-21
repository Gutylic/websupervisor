using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using Datos;

namespace Supervisor
{
    public partial class _2_consultaAdministrador : System.Web.UI.Page
    {
        panel2Administrador p2A = new panel2Administrador();

        protected void Page_Load(object sender, EventArgs e)
        {            
            // usado para el panel 2
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                // Supervisor                             
                Boton_Borrar_Supervisor.Visible = false;
                Boton_Cerrar_Formulario_Supervisor.Visible = false;
                MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
                PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));

                // Dios     
                Boton_Borrar_Dios.Visible = false;
                Boton_Cerrar_Formulario_Dios.Visible = false;
                //MostrarGridViewDios(0, 0);
                //PaginadoGridViewDios(0);
            }
        }

        // administrador

        protected void BtnEnvio_Click(object sender, EventArgs e)
        {
            p2A.insertarComentario(Convert.ToInt16(Session["ID_Administrador"]), TxtBoxComentario.Text);
            // cartelito de mensaje enviado
        }
        
        // supervisor

        public void MostrarGridViewSupervisor(int empresa, int pagina)
        {
            Formulario_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            GridView_Supervisor.DataSource = p2A.mostarComentario(empresa).Skip(pagina * 10).Take(10);
            GridView_Supervisor.DataBind();
        }

        public void PaginadoGridViewSupervisor(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina           
            ViewState["Cantidad_De_Datos"] = p2A.contarMensajes(empresa); // cuenta la cantidad de datos
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
            Boton_Borrar_Supervisor.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = true;
            Boton_Excel_Supervisor.Visible = false;
            List<mostrarComentarioAdministradorResult> Datos = p2A.mostarComentario(0); // carga los datos del administrador elegido por el supervisor            
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_MensajeAdministrador"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado 
            
            Administrador_Supervisor.Text = Datos[(int)Session["ID_MensajeAdministrador"] - 1].administrador; // carga el administrador de la base
            Comentario_Supervisor.Text = Datos[(int)Session["ID_MensajeAdministrador"] - 1].mensajeAdministrador; // carga el password de la base
            Fecha_Supervisor.Text = Datos[(int)Session["ID_MensajeAdministrador"] - 1].fechaComentario.ToString(); // carga la categoria de la base

        }
        
        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {
            p2A.borrarComentario((int)Session["ID_MensajeAdministrador"]);
            p2A.actualizarIndices();
            Boton_Borrar_Supervisor.Visible = false;           
            Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            Extremo_Supervisor.Visible = true;
            Boton_Excel_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
            
            // cartelito de administrador borrado
        }

        protected void Boton_Cerrar_Formulario_Supervisor_Click(object sender, EventArgs e)
        {            
            Boton_Borrar_Supervisor.Visible = false;            
            Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            Extremo_Supervisor.Visible = true;
            Boton_Excel_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
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
            GridView_Supervisor.DataSource = p2A.mostarComentario((int)Session["Empresa"]);
            GridView_Supervisor.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Supervisor);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_Comentarios.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        // dios

        public void MostrarGridViewDios(int empresa, int pagina)
        {
            Boton_Excel_Dios.Visible = true;
            Formulario_Dios.Visible = false;        
            GridView_Dios.DataSource = p2A.mostarComentario(empresa).Skip(pagina * 10).Take(10);
            GridView_Dios.DataBind();
        }

        public void PaginadoGridViewDios(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = p2A.contarMensajes(empresa); // cuenta la cantidad de datos
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
            Boton_Excel_Dios.Visible = false;
            Anterior_Dios_Ultimo.Visible = false;
            Boton_Cerrar_Formulario_Dios.Visible = true;
            Boton_Borrar_Dios.Visible = true;     
            Administrador_Dios.Enabled = false;

            List<mostrarComentarioAdministradorResult> Datos = p2A.mostarComentario(0); // carga los datos del administrador elegido por Dios            
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_MensajeAdministrador"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           
            
            Administrador_Dios.Text = Datos[(int)Session["ID_MensajeAdministrador"] - 1].administrador; // carga el administrador de la base
            Comentario_Dios.Text = Datos[(int)Session["ID_MensajeAdministrador"] - 1].mensajeAdministrador; // carga el password de la base
            Fecha_Dios.Text = Datos[(int)Session["ID_MensajeAdministrador"] - 1].fechaComentario.ToString(); // carga la categoria de la base

        }

        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            p2A.borrarComentario((int)Session["ID_MensajeAdministrador"]);
            p2A.actualizarIndices();
            Boton_Excel_Dios.Visible = true;
            Boton_Borrar_Dios.Visible = false;
            Boton_Cerrar_Formulario_Dios.Visible = true;
            Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);           
            // cartelito de administrador borrado
        }

        protected void Boton_Cerrar_Formulario_Dios_Click(object sender, EventArgs e)
        {
            Boton_Excel_Dios.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;
            Boton_Borrar_Dios.Visible = false;            
            Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);
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
            GridView_Dios.DataSource = p2A.mostarComentario(0);
            GridView_Dios.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_Comentarios.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }
                
    }
}


    