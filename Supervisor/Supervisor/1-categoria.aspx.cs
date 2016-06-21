using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Supervisor
{
    public partial class _1_categoria : System.Web.UI.Page
    {

        panel1Categoria p1C = new panel1Categoria();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPermisos_Dios_Click(object sender, EventArgs e)
        {
            int? valor = p1C.insertarAdministradorDios(Administrador_Dios.Text,Empresa_Dios.Text);

            switch (valor) 
            {
                case -1:
                    // cartelito de que el usuario ya existe
                    Administrador_Dios.Text = string.Empty;
                    return;
                case 1:
                    // cartelito de usuario ya cargado correctamente
                    return;
            }
            
        }

        protected void BtnAdministrador_Click(object sender, EventArgs e)
        {
            Session["boton_Presionado"] = 1;
            
            List<buscarAdministradorResult> Nombre = p1C.buscarAdministrador(Administrador_Supervisor.Text);
            int id_Administrador = Nombre[0].id_Administrador;

            if (id_Administrador > 1)
            {
                List<mostrarCategoriaAdministradorResult> Datos = p1C.cargarCategoriaAdministrador(id_Administrador);// carga los datos del administrador elegido por el supervisor  
                
                DropAdministrador_Supervisor.SelectedValue = (Datos[0].a1).ToString();
                DropComentarioAdministrador_Supervisor.SelectedValue = (Datos[0].a2).ToString();
                DropControlAdministrador_Supervisor.SelectedValue = (Datos[0].a3).ToString();

                DropUsuario_Supervisor.SelectedValue = (Datos[0].u1).ToString();
                DropComentarioUsuario_Supervisor.SelectedValue = (Datos[0].u2).ToString();

                DropEmpresa_Supervisor.SelectedValue = (Datos[0].p1).ToString();
                DropPrecios_Supervisor.SelectedValue = (Datos[0].p2).ToString();
                DropOfertas_Supervisor.SelectedValue = (Datos[0].p3).ToString();
                DropValorOfertas_Supervisor.SelectedValue = (Datos[0].p4).ToString();

                DropEjercicios_Supervisor.SelectedValue = (Datos[0].ce1).ToString();
                DropExplicacion_Supervisor.SelectedValue = (Datos[0].ce2).ToString();

                DropInsertarEjercicios_Supervisor.SelectedValue = "0";
                DropActualizarEjercicios_Supervisor.SelectedValue = "0";

                DropTarjetaPrepaga_Supervisor.SelectedValue = (Datos[0].c1).ToString();
                DropCargaAutomatica_Supervisor.SelectedValue = (Datos[0].c2).ToString();
                DropCargaManuel_Supervisor.SelectedValue = (Datos[0].c3).ToString();
                DropFacturacion_Supervisor.SelectedValue = "0";
                DropMovimientos_Supervisor.SelectedValue = (Datos[0].c5).ToString();

                DropExplicacionesPedidas_Supervisor.SelectedValue = (Datos[0].ep1).ToString();
                DropEjerciciosPedidos_Supervisor.SelectedValue = (Datos[0].ep2).ToString();

                return;
            }

            Session["boton_Presionado"] = 0;
            return;

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if ((int)Session["boton_Presionado"] == 1) // puesto para que tenga que cargar si es que hay un administrador probado
            {
                p1C.actualizarCategoriaAdministrador(int.Parse(Administrador_Supervisor.Text), int.Parse(DropAdministrador_Supervisor.SelectedValue),
                    int.Parse(DropComentarioAdministrador_Supervisor.SelectedValue),int.Parse(DropControlAdministrador_Supervisor.SelectedValue),
                    int.Parse(DropUsuario_Supervisor.SelectedValue), int.Parse(DropComentarioUsuario_Supervisor.SelectedValue),
                    int.Parse(DropEmpresa_Supervisor.SelectedValue), int.Parse(DropPrecios_Supervisor.SelectedValue),
                    int.Parse(DropOfertas_Supervisor.SelectedValue), int.Parse(DropValorOfertas_Supervisor.SelectedValue),
                    int.Parse(DropEjercicios_Supervisor.SelectedValue), int.Parse(DropExplicacion_Supervisor.SelectedValue), 
                    int.Parse(DropTarjetaPrepaga_Supervisor.SelectedValue),int.Parse(DropCargaAutomatica_Supervisor.SelectedValue),
                    int.Parse(DropCargaManuel_Supervisor.SelectedValue), int.Parse(DropMovimientos_Supervisor.SelectedValue),
                    int.Parse(DropExplicacionesPedidas_Supervisor.SelectedValue), int.Parse(DropEjerciciosPedidos_Supervisor.SelectedValue));
                Session["boton_Presionado"] = 0;
                return;
            }

            return;
        }
    }
}