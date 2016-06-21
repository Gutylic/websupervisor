using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace Supervisor
{
    public partial class _1_empresas : System.Web.UI.Page
    {
        panel1Precios p1P = new panel1Precios();
        LogicaIngreso LI = new LogicaIngreso();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {               
                // Dios                
                Boton_Actualizar_Dios.Visible = false;
                Boton_Nuevo_Dios.Visible = false;
                
                Boton_Cerrar_Formulario_Dios.Visible = false;
                MostrarGridViewDios(0);
                PaginadoGridViewDios();
            }
        }

        // administradores
               

        // supervisores
               

        // dios

        public void MostrarGridViewDios(int pagina)
        {
            Formulario_Dios.Visible = false;
            Boton_Excel_Dios.Visible = true;
            GridView_Dios.DataSource = p1P.mostrarEmpresas().Skip(pagina * 10).Take(10);
            GridView_Dios.DataBind();
        }

        public void PaginadoGridViewDios() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = p1P.paginadoEmpresas(); // cuenta la cantidad de datos
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
                MostrarGridViewDios(0);// carga cada presion el gridview
                Centro_Dios.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Dios.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Dios_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                MostrarGridViewDios(0);// carga cada presion el gridview
                Centro_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Dios_Click(object sender, EventArgs e)
        {
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                MostrarGridViewDios(0); // carga cada presion el gridview
                Centro_Dios.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Dios.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Dios_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                MostrarGridViewDios(0); // carga cada presion el gridview
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
            Boton_Nuevo_Dios.Visible = true;         
            Boton_Actualizar_Dios.Visible = true;
            Boton_Excel_Dios.Visible = false;
            Boton_Cerrar_Formulario_Dios.Visible = true;
        
            List<mostrarEmpresaResult> Datos = p1P.mostrarEmpresas(); // carga los datos del administrador elegido por Dios            
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Empresa"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado           

            TxtEmpresa_Dios.Text = Datos[(int)Session["ID_Empresa"] - 1].empresa; // carga el administrador de la base
           
        }

        protected void Boton_Actualizar_Dios_Click(object sender, EventArgs e)
        {
            int? Empresa = p1P.verificaEmpresa(TxtEmpresa_Dios.Text);

            if (Empresa == -1)
            {
                // cartelito de que la empresa no existe
                return;
            }

            int error = LI.errorContrasena(TxtEmpresa_Dios.Text);

            switch (error)
            {
                case 1:
                    p1P.actualizarEmpresa(Convert.ToInt16(Session["ID_Empresa"]),TxtEmpresa_Dios.Text);                    
                    Formulario_Dios.Visible = false;
                    GridView_Dios.Visible = true;
                    Boton_Actualizar_Dios.Visible = false;
                    Boton_Nuevo_Dios.Visible = false;                   
                    Boton_Excel_Dios.Visible = true;
                    Boton_Cerrar_Formulario_Dios.Visible = false;
                    Extremo_Dios.Visible = true;
                    Siguiente_Dios_Primero.Visible = true;
                    MostrarGridViewDios(0);
                    PaginadoGridViewDios();
                    // cartelito de actualizacion exitoso
                    return;
                case -1:
                    // cartelito de contraseña no aceptada
                    return;
            }


        }

        protected void Boton_Nuevo_Dios_Click(object sender, EventArgs e)
        {
            if (Boton_Nuevo_Dios.Text == "Nuevo")
            {
                TxtEmpresa_Dios.Text = string.Empty;
                GridView_Dios.Visible = false;
                Boton_Nuevo_Dios.Text = "Insertar";                
                return;
            }


            if (Boton_Nuevo_Dios.Text == "Insertar")
            {
                
                int? Empresa = p1P.verificaEmpresa(TxtEmpresa_Dios.Text);

                if (Empresa == -1)
                {
                    // cartelito de que la empresa no existe
                    return;
                }

                // bloquear que el usuario no exista
                int? respuesta = p1P.insertarEmpresas(TxtEmpresa_Dios.Text);

                switch (respuesta)
                {
                    case -1:
                        // cartelito de existencia de empresa
                        return;
                    case 1:
                        // cartelito de actualizacion exitoso
                        Boton_Nuevo_Dios.Text = "Nuevo";
                        Boton_Nuevo_Dios.Visible = false;
                        Boton_Actualizar_Dios.Visible = false;
                        Boton_Excel_Dios.Visible = true;
                        Extremo_Dios.Visible = true;
                        Siguiente_Dios_Primero.Visible = true;
                        Formulario_Dios.Visible = false;
                        GridView_Dios.Visible = true;
                        Boton_Cerrar_Formulario_Dios.Visible = false;                       
                        PaginadoGridViewDios();
                        MostrarGridViewDios(0);
                        return;
                }

            }

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
            GridView_Dios.DataSource = p1P.mostrarEmpresas();
            GridView_Dios.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_Empresas.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void Boton_Cerrar_Formulario_Dios_Click(object sender, EventArgs e)
        {
            Boton_Actualizar_Dios.Visible = false;
            Boton_Nuevo_Dios.Visible = false;            
            Boton_Excel_Dios.Visible = true;
            Extremo_Dios.Visible = true;
            Siguiente_Dios_Primero.Visible = true;
            Boton_Cerrar_Formulario_Dios.Visible = false;
            Formulario_Dios.Visible = false;
            GridView_Dios.Visible = true;
            MostrarGridViewDios(0);
            PaginadoGridViewDios();
        }

    }
}