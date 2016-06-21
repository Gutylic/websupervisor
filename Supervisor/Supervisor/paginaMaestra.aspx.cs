using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Supervisor
{
    public partial class paginaMaestra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPanel_1Administrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-administrador.aspx");
        }

        protected void BtnPanel_2Comentario_Click(object sender, EventArgs e)
        {
            Response.Redirect("2-consultaAdministrador.aspx");
        }

        protected void BtnPanel_3Control_Click(object sender, EventArgs e)
        {
            Response.Redirect("3-controlIngreso.aspx");
        }

        protected void BtnPanel_1Usuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-usuario.aspx");
        }

        protected void BtnPanel_2ComentarioUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("2-mensajeUsuario.aspx");
        }

        protected void BtnPanel_1Empresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-empresas.aspx");
        }

        protected void BtnPanel_2Precios_Click(object sender, EventArgs e)
        {
            Response.Redirect("2-precios.aspx");
        }

        protected void BtnPanel_3Oferta_Click(object sender, EventArgs e)
        {
            Response.Redirect("3-ofertas.aspx");
        }

        protected void BtnPanel_4ValorOferta_Click(object sender, EventArgs e)
        {
            Response.Redirect("4-valorOfertas.aspx");
        }

        protected void BtnCompraVideos_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-comprasEjercicios.aspx");
        }

        protected void BtnCompraEjercicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("2-comprasVideos.aspx");
        }

        protected void BtnInsertarEjercicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-ejerciciosInsertar.aspx");
        }

        protected void BtnActualizarEjercicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("2-ejerciciosActualizar.aspx");
        }

        protected void BtnTarjetaPrepaga_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-tarjetaPrepaga.aspx");
        }

        protected void BtnCargaAutomatica_Click(object sender, EventArgs e)
        {
            Response.Redirect("2-cargaAutomatica.aspx");
        }

        protected void BtnCargaManual_Click(object sender, EventArgs e)
        {
            Response.Redirect("3-cargaManual.aspx");
        }

        protected void BtnFacturacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("4-Facturacion.aspx");
        }

        protected void BtnMovimiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("5-movimientos.aspx");
        }

        protected void BtnExplicacionesPedidas_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-explicacionPedida.aspx");
        }

        protected void BtnEjerciciosPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("2-ejercicioPedido.aspx");
        }

        protected void BtnCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("1-categoria.aspx");
        }
               
    }

}