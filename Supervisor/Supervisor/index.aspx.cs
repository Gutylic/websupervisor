using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Supervisor
{
    public partial class index : System.Web.UI.Page
    {

        ingresoSupervisores iS = new ingresoSupervisores();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                ViewState["i"] = 0;
            }
        }

        protected void BtnIngreso_Click(object sender, EventArgs e)
        {            

            int? id_Administrador = iS.administradorLogueado(TxtAdministrador.Text, TxtContrasena.Text, Request.UserHostAddress.ToString());
            
            if (id_Administrador == 0) // bloqueo del administrador
            {
                string auxiliar = TxtAdministrador.Text;

                if (TxtAdministrador.Text == auxiliar)
                {
                    ViewState["i"] = (int)ViewState["i"] + 1;
                    if ((int)ViewState["i"] == 3)
                    {
                        iS.administradorBloqueado(auxiliar);
                    }

                }
                else
                {
                    ViewState["i"] = 0;
                }
                return;                
            }
                        
            Session["ID_Administrador"] = id_Administrador; // para poder usarla en tosas las pantallas sin pedir el dato a cada rato
            Session["Administrador"] = TxtAdministrador.Text;
            Session["IPAddress"] = Request.UserHostAddress;
            Session["Empresa"] = iS.administradorEmpresa(TxtAdministrador.Text);

            Response.Redirect("paginaMaestra.aspx");
        }
    }
}