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
using Logica;

namespace Supervisor
{
    public partial class _1_usuario : System.Web.UI.Page
    {

        panel1Usuario p1U = new panel1Usuario();
        LogicaIngreso LI = new LogicaIngreso();

        protected void Page_Load(object sender, EventArgs e)
        {
            BtnCerrar.Visible = false;

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                // Supervisor
                Boton_Actualizar_Supervisor.Visible = false;
                Boton_Nuevo_Supervisor.Visible = false;
                Boton_Borrar_Supervisor.Visible = false;
                Boton_Cerrar_Formulario_Supervisor.Visible = false;
                MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
                PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));

                // Dios              
                Boton_Borrar_Dios.Visible = false;
                Boton_Cerrar_Formulario_Dios.Visible = false;
                MostrarGridViewDios(0, 0);
                PaginadoGridViewDios(0);
            }

        }

        protected void BtnUsuario_Click(object sender, EventArgs e)
        {
            Formulario_Administrador.Visible = true;
            BtnCerrar.Visible = true;
            List<buscarUsuarioResult> Datos;
            switch (int.Parse(DropDownList_TipoUsuario.SelectedValue))
            {

                case 1:

                    Datos = p1U.mostrarUsuarioAdministrador(TxtUsuario.Text, null, null, 2); //Convert.ToInt16(Session["Empresa"]) carga los datos del administrador elegido por Dios            
                    LblCorreo.Text = Datos[0].correo;
                    LblTelefono.Text = Datos[0].telefono;
                    LblCredito.Text = Datos[0].creditoUsuario.ToString();
                    LblFacebook.Text = Datos[0].nameFacebook;
                    CheckBoxBloqueo.Checked = Datos[0].bloqueoUsuario;
                    break;

                case 2:
                    Datos = p1U.mostrarUsuarioAdministrador(null, TxtUsuario.Text, null, Convert.ToInt16(Session["Empresa"]));
                    LblCorreo.Text = Datos[0].correo;
                    LblTelefono.Text = Datos[0].telefono;
                    LblCredito.Text = Datos[0].creditoUsuario.ToString();
                    LblFacebook.Text = Datos[0].nameFacebook;
                    CheckBoxBloqueo.Checked = Datos[0].bloqueoUsuario;
                    break;
                case 3:
                    Datos = p1U.mostrarUsuarioAdministrador(null, null, TxtUsuario.Text, Convert.ToInt16(Session["Empresa"]));
                    LblCorreo.Text = Datos[0].correo;
                    LblTelefono.Text = Datos[0].telefono;
                    LblCredito.Text = Datos[0].creditoUsuario.ToString();
                    LblFacebook.Text = Datos[0].nameFacebook;
                    CheckBoxBloqueo.Checked = Datos[0].bloqueoUsuario;
                    break;

            }

        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Formulario_Administrador.Visible = false;
            BtnCerrar.Visible = false;
        }


        // supervisores

        public void MostrarGridViewSupervisor(int empresa, int pagina)
        {
            Formulario_Supervisor.Visible = false;
            Boton_Excel_Supervisor.Visible = true;
            GridView_Supervisor.DataSource = p1U.mostrarUsuario(empresa).Skip(pagina * 10).Take(10);
            GridView_Supervisor.DataBind();
        }

        public void PaginadoGridViewSupervisor(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina           
            ViewState["Cantidad_De_Datos"] = p1U.paginadoUsuario(empresa); // cuenta la cantidad de datos
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
            Boton_Actualizar_Supervisor.Visible = true;
            Boton_Nuevo_Supervisor.Visible = true;
            Boton_Borrar_Supervisor.Visible = true;
            Boton_Excel_Supervisor.Visible = false;
            Boton_Cerrar_Formulario_Supervisor.Visible = true;
          
            List<mostrarUsuarioResult> Datos = p1U.mostrarUsuario(0); // carga los datos del administrador elegido por el supervisor            
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Usuario"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            Correo_Supervisor.Text = Datos[(int)Session["ID_Usuario"] - 1].correo; // carga el administrador de la base
            Telefono_Supervisor.Text = Datos[(int)Session["ID_Usuario"] - 1].telefono;            
            CheckBox_Bloqueo_Supervisor.Checked = Datos[(int)Session["ID_Usuario"] - 1].bloqueoUsuario; // carga el password de la base                       
            CheckBox_SOS_Supervisor.Checked = bool.Parse(Datos[(int)Session["ID_Usuario"] - 1].prestamoSOS.ToString());
            DropDownListPais_Supervisor.SelectedValue = Datos[(int)Session["ID_Usuario"] - 1].pais.ToString(); 

        }

        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {

            p1U.actualizarUsuario(Convert.ToInt16(Session["ID_Usuario"]), CheckBox_Bloqueo_Supervisor.Checked, Telefono_Supervisor.Text, int.Parse(DropDownListPais_Supervisor.SelectedValue));
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
                GridView_Supervisor.Visible = false;
                Boton_Nuevo_Supervisor.Text = "Insertar";
                Correo_Supervisor.Text = string.Empty; // carga el administrador de la base
                Telefono_Supervisor.Text = string.Empty;
                CheckBox_Bloqueo_Supervisor.Checked = false; // carga el password de la base                       
                CheckBox_SOS_Supervisor.Checked = false;
                
                DropDownListPais_Supervisor.SelectedValue = "0";
                
                return;
            }


            if (Boton_Nuevo_Supervisor.Text == "Insertar")
            {
                // bloquear que el usuario no exista
                int? respuesta = p1U.insertarUsuario(Correo_Supervisor.Text,Telefono_Supervisor.Text,"contra123", Convert.ToInt16(Session["Empresa"]));

                switch (respuesta)
                {
                    case -1:
                        // cartelito de existencia de administrador
                        return;
                    case 1:
                        // cartelito de actualizacion exitoso
                        Boton_Nuevo_Supervisor.Text = "Nuevo";
                        Boton_Actualizar_Supervisor.Visible = false;
                        Boton_Nuevo_Supervisor.Visible = false;
                        Boton_Borrar_Supervisor.Visible = false;
                        Boton_Excel_Supervisor.Visible = true;
                        Formulario_Supervisor.Visible = false;
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
            p1U.borrarUsuario((int)Session["ID_Usuario"]);
            p1U.actualizarIndice();
            p1U.actualizarIndiceMovimientos();
            Boton_Actualizar_Supervisor.Visible = false;
            Boton_Nuevo_Supervisor.Visible = false;
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
            GridView_Supervisor.DataSource = p1U.mostrarUsuario((int)Session["Empresa"]);
            GridView_Supervisor.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Supervisor);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_Usuarios.xls");
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
            GridView_Supervisor.Visible = true;
            MostrarGridViewSupervisor(Convert.ToInt16(Session["Empresa"]), 0);
            PaginadoGridViewSupervisor(Convert.ToInt16(Session["Empresa"]));
        }


        // dios

        public void MostrarGridViewDios(int empresa, int pagina)
        {
            Formulario_Dios.Visible = false;
            Boton_Excel_Dios.Visible = true;
            GridView_Dios.DataSource = p1U.mostrarUsuario(empresa).Skip(pagina * 10).Take(10);
            GridView_Dios.DataBind();
        }

        public void PaginadoGridViewDios(int empresa) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = p1U.paginadoUsuario(empresa); // cuenta la cantidad de datos
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
            Boton_Borrar_Dios.Visible = true;            
            Boton_Excel_Dios.Visible = false;
            Boton_Cerrar_Formulario_Dios.Visible = true;           

            List<mostrarUsuarioResult> Datos = p1U.mostrarUsuario(0); // carga los datos del administrador elegido por Dios            
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Usuario"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            Correo_Dios.Text = Datos[(int)Session["ID_Usuario"] - 1].correo; // carga el administrador de la base
            Telefono_Dios.Text = Datos[(int)Session["ID_Usuario"] - 1].telefono;
            Password_Dios.Text = Datos[(int)Session["ID_Usuario"] - 1].password;
            CheckBox_Bloqueo_Dios.Checked = Datos[(int)Session["ID_Usuario"] - 1].bloqueoUsuario; // carga el password de la base                       
            CheckBox_SOS_Dios.Checked = bool.Parse(Datos[(int)Session["ID_Usuario"] - 1].prestamoSOS.ToString());
            DropDownListPais_Dios.SelectedValue = Datos[(int)Session["ID_Usuario"] - 1].pais.ToString(); 

        }
   
        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            p1U.borrarUsuario((int)Session["ID_Usuario"]);
            p1U.actualizarIndice();
            p1U.actualizarIndiceMovimientos();  
            Boton_Borrar_Dios.Visible = false;
            Password_Dios.Enabled = true;
            Boton_Excel_Dios.Visible = true;
            Formulario_Dios.Visible = false;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewSupervisor(0);
            // cartelito de administrador borrado
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
            GridView_Dios.DataSource = p1U.mostrarUsuario(0);
            GridView_Dios.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_Usuarios.xls");
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
            Password_Dios.Enabled = true;
            Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0, 0);
            PaginadoGridViewDios(0);
        }
        
    }

}