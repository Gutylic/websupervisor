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
    public partial class _4_valorOfertas : System.Web.UI.Page
    {
        panel4Precios p4P = new panel4Precios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {

                List<mostrarValorOfertasResult> Datos = p4P.mostrarValorOfertas(Convert.ToInt16(Session["Empresa"]));

                // Administrador

                LblPrestamoSOS_Administrador.Text = (Datos[0].oferta_1ValorPrestamoSOS).ToString();
                LblRegistro_Administrador.Text = (Datos[0].oferta_2ValorRegistro).ToString();
                LblProximaCarga_Administrador.Text = (Datos[0].oferta_3ValorProximaCarga).ToString();
                LblAumentoCarga_Administrador.Text = (Datos[0].oferta_4ValorAumentoCarga).ToString();
                LblRegaloCarga_Administrador.Text = (Datos[0].oferta_5ValorRegaloCarga).ToString();
                LblDescuentoSegundo_Administrador.Text = (Datos[0].oferta_9ValorDescuentoSegundo).ToString();
                LblDescuentoCompra_Administrador.Text = (Datos[0].oferta_13ValorDescuentoCompra).ToString();
                LblAumentoCompraDias_Administrador.Text = (Datos[0].oferta_11ValorAumentoDiasCompras).ToString();
                LblAumentoTodoComprasDias_Administrador.Text = (Datos[0].oferta_12ValorAumentoDiasTodasCompras).ToString();

                // Supervisor

                TxtPrestamoSOS_Supervisor.Text = (Datos[0].oferta_1ValorPrestamoSOS).ToString();
                TxtRegistro_Supervisor.Text = (Datos[0].oferta_2ValorRegistro).ToString();
                TxtProximaCarga_Supervisor.Text = (Datos[0].oferta_3ValorProximaCarga).ToString();
                TxtAumentoCarga_Supervisor.Text = (Datos[0].oferta_4ValorAumentoCarga).ToString();
                TxtRegaloCarga_Supervisor.Text = (Datos[0].oferta_5ValorRegaloCarga).ToString();
                TxtDescuentoSegundo_Supervisor.Text = (Datos[0].oferta_9ValorDescuentoSegundo).ToString();
                TxtDescuentoCompra_Supervisor.Text = (Datos[0].oferta_13ValorDescuentoCompra).ToString();
                TxtAumentoCompraDias_Supervisor.Text = (Datos[0].oferta_11ValorAumentoDiasCompras).ToString();
                TxtAumentoTodoComprasDias_Supervisor.Text = (Datos[0].oferta_12ValorAumentoDiasTodasCompras).ToString();

                // Dios

                MostrarGridViewDios(0, 0);
                PaginadoGridViewDios();

            }
            
        }


        // supervisor

        protected void BtnActualizar_Supervisor_Click(object sender, EventArgs e)
        {
            p4P.actualizarValorOferta(Convert.ToInt16(Session["Empresa"]),Convert.ToDecimal(TxtPrestamoSOS_Supervisor.Text),Convert.ToDecimal(TxtRegistro_Supervisor.Text),int.Parse(TxtProximaCarga_Supervisor.Text),int.Parse(TxtAumentoCarga_Supervisor.Text),Convert.ToDecimal(TxtRegaloCarga_Supervisor.Text),Convert.ToDecimal(TxtDescuentoSegundo_Supervisor.Text), int.Parse(TxtAumentoCompraDias_Supervisor.Text),int.Parse(TxtAumentoTodoComprasDias_Supervisor.Text),Convert.ToDecimal(TxtDescuentoCompra_Supervisor.Text));
            // cartelito de supervision
        }

        // Dios

        public void MostrarGridViewDios(int empresa, int pagina)
        {
            GridView_Dios.DataSource = p4P.mostrarValorOfertas(empresa).Skip(pagina * 10).Take(10);
            GridView_Dios.DataBind();
        }

        public void PaginadoGridViewDios() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Centro_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = p4P.paginadoValorOfertas(); // cuenta la cantidad de datos
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
            GridView_Dios.DataSource = p4P.mostrarValorOfertas(0);
            GridView_Dios.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Panel_ValorOfertas.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

    }
}