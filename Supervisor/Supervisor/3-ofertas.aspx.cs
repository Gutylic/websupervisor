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
    public partial class _3_ofertas : System.Web.UI.Page
    {

        panel3Precios p3P = new panel3Precios();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                List<mostrarOfertasResult> Datos = p3P.mostrarOfertas(Convert.ToInt16(Session["Empresa"]));

                // Administrador

                bool Oferta_50 = true;

                // oferta unica a elegir
                if (Convert.ToBoolean(Datos[0].oferta_3ProximaCarga))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "1";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "1";

                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_4AumentoCarga))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "2";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "2";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_5RegaloCarga))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "3";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "3";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_6DosXUno))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "4";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "4";

                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_7DosXUnoIgualProducto))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "5";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "5";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_8Gratis))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "6";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "6";

                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_9DescuentoSegundo))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "7";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "7";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_11AumentoDiasCompras))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "8";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "8";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_12AumentoDiasTodasCompras))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "9";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "9";

                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_13DescuentoCompra))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "10";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "10";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_14ImpresionGratis))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "11";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "11";

                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_15VideosGratis))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "12";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "12";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_16EjerciciosGratis))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "13";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "13";
                    
                    Oferta_50 = false;
                }
                if (Convert.ToBoolean(Datos[0].oferta_17ExplicacionesGratis))
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "14";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "14";
                    
                    Oferta_50 = false;
                }

                // sin oferta
                if (Oferta_50)
                {
                    RadioButtonList_Ofertas_Administrador.SelectedValue = "50";

                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "50";

                }

                // ofertas que pueden convivir con otras
                if (Convert.ToBoolean(Datos[0].oferta_2Registro))
                {
                    Bonificacion_Registro_Administrador.Checked = true;

                    Bonificacion_Registro_Supervisor.Checked = true;

                }
                if (Convert.ToBoolean(Datos[0].oferta_10BonificaciónHabitue))
                {
                    Bonificacion_Por_Cantidad_Administrador.Checked = true;

                    Bonificacion_Por_Cantidad_Supervisor.Checked = true;

                }
                if (Convert.ToBoolean(Datos[0].oferta_1PrestamoSOS))
                {
                    Bonificacion_Por_PrestamoSOS_Administrador.Checked = true;

                    Bonificacion_Por_PrestamoSOS_Supervisor.Checked = true;                    
                }

                // Dios

                MostrarGridViewDios(0, 0);
                PaginadoGridViewDios();
            }
        }

        // supervisor
        protected void BtnActualizar_Supervisor_Click(object sender, EventArgs e)
        {
            string seleccionOferta = RadioButtonList_Ofertas_Supervisor.SelectedItem.Value;
            bool[] oferta = new bool[15];

            for (int i = 0; i < 14; i++)
            {

                oferta[i + 1] = false;

                if ((i + 1) == int.Parse(seleccionOferta))
                { 
                    oferta[i + 1] = true;                
                }

            }
                       
            p3P.actualizarOferta(Convert.ToInt16(Session["Empresa"]),Bonificacion_Por_PrestamoSOS_Supervisor.Checked,Bonificacion_Registro_Supervisor.Checked,oferta[1], oferta[2], oferta[3], oferta[4], oferta[5], oferta[6], oferta[7], Bonificacion_Por_Cantidad_Supervisor.Checked,oferta[8], oferta[9], oferta[10], oferta[11], oferta[12], oferta[13], oferta[14]);
        }


        // dios

        public void MostrarGridViewDios(int empresa, int pagina)
        {
            GridView_Dios.DataSource = p3P.mostrarOfertas(empresa).Skip(pagina * 10).Take(10);
            GridView_Dios.DataBind();
        }

        public void PaginadoGridViewDios() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = p3P.paginadoOfertas(); // cuenta la cantidad de datos
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
            GridView_Dios.DataSource = p3P.mostrarOfertas(0);
            GridView_Dios.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_Ofertas.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }


    }
}