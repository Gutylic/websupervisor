using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Web.UI.WebControls.WebParts;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace Supervisor
{
    public partial class _1_tarjetaPrepaga : System.Web.UI.Page
    {

        panel1Credito p1C = new panel1Credito();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {

                // administrador
                Formulario_Administrador.Visible = false;
                BtnCerrarFormulario.Visible = false;

                codigoTarjeta_Administrador.Text = string.Empty;
                valorTarjeta_Administrador.Text = string.Empty;
                vencimientoTarjeta_Administrador.Text = string.Empty; ;
                CheckBox_Bloqueo_Administrador.Checked = false;

                // Supervisor
                //Boton_Actualizar_Supervisor.Visible = false;               ;
                //Boton_Borrar_Supervisor.Visible = false;
                //Boton_Cerrar_Formulario_Supervisor.Visible = false;
                //MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
                //PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));

                // Dios                
                Boton_Borrar_Dios.Visible = false;
                Boton_Cerrar_Formulario_Dios.Visible = false;
                MostrarGridViewDios(0, 0);
                PaginadoGridViewDios(0);

            }
        }


        // Administrador
        protected void BtnBuscarTarjeta_Administrador_Click(object sender, EventArgs e)
        {            
            List<buscarTarjetaPrepagaResult> Datos = p1C.buscarTarjeta(TxtTarjetaPrepaga_Administrador.Text, Convert.ToInt16(Session["Empresa"]));
            try
            {
                Formulario_Administrador.Visible = true;
                BtnCerrarFormulario.Visible = true;

                codigoTarjeta_Administrador.Text = Datos[0].codigoTarjeta;
                valorTarjeta_Administrador.Text = (Datos[0].valorTarjeta).ToString();
                vencimientoTarjeta_Administrador.Text = (Datos[0].vencimientoTarjeta).ToString();
                CheckBox_Bloqueo_Administrador.Checked = Convert.ToBoolean(Datos[0].bloqueoTarjeta);
                return;
            }
            catch 
            {
                Formulario_Administrador.Visible = false;
                BtnCerrarFormulario.Visible = false;
                // cartelito que avisa que no existe
                return;
            }

        }

        protected void BtnCerrarFormulario_Click(object sender, EventArgs e)
        {

            codigoTarjeta_Administrador.Text = string.Empty;
            valorTarjeta_Administrador.Text = string.Empty;
            vencimientoTarjeta_Administrador.Text = string.Empty; ;
            CheckBox_Bloqueo_Administrador.Checked = false;

            Formulario_Administrador.Visible = false;
            BtnCerrarFormulario.Visible = false;

            
        }


        // supervisores

        public void MostrarGridViewSupervisor(int empresa, int pagina)
        {
            Formulario_Supervisor.Visible = false;
            Formulario_Tarjeta.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            Boton_Nuevo_Supervisor.Visible = true;
            GridView_Supervisor.DataSource = p1C.MostrarTarjeta(empresa).Skip(pagina * 10).Take(10);
            GridView_Supervisor.DataBind();
        }

        public void PaginadoGridViewSupervisor(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina           
            ViewState["Cantidad_De_Datos"] = p1C.paginadoTarjeta(empresa); // cuenta la cantidad de datos
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
            //if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; }
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
            Formulario_Tarjeta.Visible = false;
            GridView_Supervisor.Visible = false;
            Centro_Supervisor.Visible = false;
            Siguiente_Supervisor_Primero.Visible = false;
            Anterior_Supervisor_Ultimo.Visible = false;
            Boton_Actualizar_Supervisor.Visible = true;
            Boton_Nuevo_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = true;
            Boton_Excel_Supervisor.Visible = false;
            Boton_Cerrar_Formulario_Supervisor.Visible = true;
            
            List<mostrarTarjetaPrepagaResult> Datos = p1C.MostrarTarjeta(Convert.ToInt16(Session["Empresa"])); // carga los datos del administrador elegido por el supervisor            
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Tarjeta"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            codigoTarjeta_Supervisor.Text = Datos[(int)Session["ID_Tarjeta"] - 1].codigoTarjeta;
            valorTarjeta_Supervisor.Text = (Datos[(int)Session["ID_Tarjeta"] - 1].valorTarjeta).ToString();
            vencimientoTarjeta_Supervisor.Text = (Datos[(int)Session["ID_Tarjeta"] - 1].vencimientoTarjeta).ToString();
            CheckBox_Bloqueo_Supervisor.Checked = Convert.ToBoolean(Datos[(int)Session["ID_Tarjeta"] - 1].bloqueoTarjeta);
                                  
        }

        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Tarjeta.Visible = false;
            p1C.actualizarTarjeta(Convert.ToInt16(Session["ID_Tarjeta"]),CheckBox_Bloqueo_Supervisor.Checked,Convert.ToDateTime(vencimientoTarjeta_Supervisor.Text));
            Formulario_Supervisor.Visible = false;
            GridView_Supervisor.Visible = true;
            Boton_Actualizar_Supervisor.Visible = false;
            Boton_Nuevo_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            Extremo_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
            // cartelito de actualizacion exitoso
            return;
            
        }

        protected void Boton_Nuevo_Supervisor_Click(object sender, EventArgs e)
        {
            
            if (Boton_Nuevo_Supervisor.Text == "Nuevo")
            {
                Formulario_Tarjeta.Visible = true;
                Cantidad_Tarjetas.Text = string.Empty;
                Boton_Cerrar_Formulario_Supervisor.Visible = true;
                Vencimiento_Tarjetas.Text = string.Empty;
                Valor_Tarjetas.Text = string.Empty;
                Boton_Nuevo_Supervisor.Text = "Insertar";
                return;
            }

            if (Boton_Nuevo_Supervisor.Text == "Insertar")
            {
                // bloquear que el usuario no exista
                int? respuesta = p1C.insertarTarjeta(int.Parse(Cantidad_Tarjetas.Text), Convert.ToDateTime(Vencimiento_Tarjetas.Text), Convert.ToDecimal(Valor_Tarjetas.Text), Convert.ToInt16(Session["Empresa"]));
                switch (respuesta)
                {
                    case -1:
                        // cartelito de existencia no se crearon las tarjetas
                        return;
                    case 1:
                        // cartelito de actualizacion exitoso
                        Boton_Nuevo_Supervisor.Text = "Nuevo";
                        Boton_Actualizar_Supervisor.Visible = false;
                        Boton_Nuevo_Supervisor.Visible = false;
                        Boton_Borrar_Supervisor.Visible = false;
                        Boton_Excel_Supervisor.Visible = true;
                        Formulario_Supervisor.Visible = false;
                        Formulario_Tarjeta.Visible = false;
                        Extremo_Supervisor.Visible = true;
                        Siguiente_Supervisor_Primero.Visible = true;
                        GridView_Supervisor.Visible = true;
                        Boton_Cerrar_Formulario_Supervisor.Visible = false;
                        PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
                        MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);

                        return;
                }
                
            }
            
        }

        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {  
            p1C.borrarTarjeta((int)Session["ID_Tarjeta"]);
            p1C.actualizarIndice();
            Boton_Actualizar_Supervisor.Visible = false;
            Boton_Nuevo_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;
            Formulario_Tarjeta.Visible = false;
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
            GridView_Supervisor.DataSource = p1C.MostrarTarjeta((int)Session["Empresa"]);
            GridView_Supervisor.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Supervisor);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_TarjetasPrepagas.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void Boton_Cerrar_Formulario_Supervisor_Click(object sender, EventArgs e)
        {
            Boton_Actualizar_Supervisor.Visible = false;
            Boton_Nuevo_Supervisor.Visible = false;
            Boton_Borrar_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            Boton_Cerrar_Formulario_Supervisor.Visible = false;
            Extremo_Supervisor.Visible = true;
            Siguiente_Supervisor_Primero.Visible = true;
            Formulario_Supervisor.Visible = false;
            Formulario_Tarjeta.Visible = false;
            GridView_Supervisor.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
        }


        // Dios

        public void MostrarGridViewDios(int empresa, int pagina)
        {
            Formulario_Dios.Visible = false;
            Formulario_Tarjeta.Visible = false;
            Boton_Excel_Dios.Visible = true;            
            GridView_Dios.DataSource = p1C.MostrarTarjeta(empresa).Skip(pagina * 10).Take(10);
            GridView_Dios.DataBind();
        }

        public void PaginadoGridViewDios(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina           
            ViewState["Cantidad_De_Datos"] = p1C.paginadoTarjeta(empresa); // cuenta la cantidad de datos
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
            //if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; }
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina            
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                MostrarGridViewDios(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Dios.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Dios.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Dios_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                MostrarGridViewDios(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]);// carga cada presion el gridview
                Centro_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Dios_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                MostrarGridViewDios(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Dios.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Dios.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Dios_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                MostrarGridViewDios(Convert.ToInt16(Session["Empresa"]), (int)ViewState["Pagina"]); // carga cada presion el gridview
                Centro_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Identificador_Dios(object sender, EventArgs e) // convierto al datalist en editable 
        {
            //Formulario_Dios.Visible = true;
            
            GridView_Dios.Visible = false;
            Centro_Dios.Visible = false;
            Siguiente_Dios_Primero.Visible = false;
            Anterior_Dios_Ultimo.Visible = false;
            Formulario_Dios.Visible = true;
            Boton_Borrar_Dios.Visible = true;
            Boton_Excel_Dios.Visible = false;
            Boton_Cerrar_Formulario_Dios.Visible = true;

            List<mostrarTarjetaPrepagaResult> Datos = p1C.MostrarTarjeta(0); // carga los datos del administrador elegido por el supervisor            
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Tarjeta"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            codigoTarjeta_Dios.Text = Datos[(int)Session["ID_Tarjeta"] - 1].codigoTarjeta;
            valorTarjeta_Dios.Text = (Datos[(int)Session["ID_Tarjeta"] - 1].valorTarjeta).ToString();
            vencimientoTarjeta_Dios.Text = (Datos[(int)Session["ID_Tarjeta"] - 1].vencimientoTarjeta).ToString();
            CheckBox_Bloqueo_Dios.Checked = Convert.ToBoolean(Datos[(int)Session["ID_Tarjeta"] - 1].bloqueoTarjeta);

        }

        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            p1C.borrarTarjeta((int)Session["ID_Tarjeta"]);
            p1C.actualizarIndice();           
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

        protected void Boton_Excel_Dios_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Supervisor.DataSourceID = string.Empty;
            GridView_Supervisor.EnableViewState = false;
            GridView_Supervisor.AllowPaging = false;
            GridView_Supervisor.DataSource = p1C.MostrarTarjeta(0);
            GridView_Supervisor.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_TarjetasPrepagas.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void Boton_Cerrar_Formulario_Dios_Click(object sender, EventArgs e)
        {
           
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