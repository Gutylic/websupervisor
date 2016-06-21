using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Net;
using Logica;
using Datos;
using mercadopago;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Supervisor
{
    public partial class _2_cargaAutomatica : System.Web.UI.Page
    {

        panel2Credito p2C = new panel2Credito();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class valores
        {
            public string fecha { get; set; }
            public decimal? monto { get; set; }
            public string comision { get; set; }
            public string usuario { get; set; }
            public string tipo { get; set; }
            public int identidad { get; set; }

        }


        protected void BtnMercadoPago_Click(object sender, EventArgs e)
        {
            if (TextBox_Archivo_MercadoPago.Text == string.Empty)
            {
                return;
            }

            //MP mp = new MP("7071654091217780", "F4SUQfv2CA4YUvPj0VsFROGywMkcYvyC");
            //JObject payment_info = mp.getPaymentInfo(Request["id"]);

            //string mensaje = payment_info["response"].ToString();


            List<string> lista = new List<string>();

            lista.Add("fecha");
            lista.Add("monto_bruto");
            lista.Add("usuario");
            lista.Add("comision");
            
            XElement xml = new XElement("pagos");

            string url = "http://www.colegioeba.com/pagos/mercadopago/OK/" + TextBox_Archivo_MercadoPago.Text + ".html";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);


            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            HttpWebResponse resp;

            try
            {
                resp = req.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                resp = ex.Response as HttpWebResponse;

                string script = @"<script type='text/javascript'>
                                alert('No existe el identificador requerido');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            StreamReader reader = new StreamReader(resp.GetResponseStream());

            string HTML = reader.ReadToEnd();

            string[] nombre_de_archivo = HTML.Split(',');
            
            string[] etiqueta_1 = nombre_de_archivo[21].Split(':');
            string[] etiqueta_2 = nombre_de_archivo[3].Split(':');
            string[] etiqueta_3 = nombre_de_archivo[17].Split(':');
            string[] etiqueta_4 = nombre_de_archivo[22].Split(':');
            
            string[] fecha = etiqueta_2[1].Split('T');
            string[] datos = fecha[0].Split('-');

            string ano = datos[0].Trim();

            string moneda = etiqueta_1[1].Trim();

            string comisiones = etiqueta_4[1].Trim();

            XElement pago = new XElement("pago");

            XElement etiqueta_secundaria = new XElement("fecha");
            etiqueta_secundaria.Add(datos[2] + datos[1] + ano);
            pago.Add(etiqueta_secundaria);

            XElement etiqueta_tercearia = new XElement("monto_bruto");
            etiqueta_tercearia.Add(moneda);
            pago.Add(etiqueta_tercearia);

            XElement etiqueta_cuartaria = new XElement("usuario");
            etiqueta_cuartaria.Add(etiqueta_3[1].Trim());
            pago.Add(etiqueta_cuartaria);

            XElement etiqueta_quintaria = new XElement("comision");
            etiqueta_quintaria.Add(etiqueta_4[1].Trim());
            pago.Add(etiqueta_quintaria);

            xml.Add(pago);

            if (!File.Exists("c:\\pagos/MercadoPago/" + TextBox_Archivo_MercadoPago.Text + ".xml"))
            {

                xml.Save("c:\\pagos/MercadoPago/" + TextBox_Archivo_MercadoPago.Text + ".xml");

            }
            else
            {

                string script = @"<script type='text/javascript'>
                                alert('El identificador requerido ya fue cargado en la base de datos');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;


            }

            XDocument doc = XDocument.Load("c:\\pagos/MercadoPago/" + TextBox_Archivo_MercadoPago.Text + ".xml");

            var query = from m in doc.Descendants("pago")
                        select new valores
                        {
                            fecha = m.Element("fecha").Value,
                            monto = Convert.ToDecimal(m.Element("monto_bruto").Value),
                            usuario = m.Element("usuario").Value,
                        };

            List<valores> Tabla = query.ToList<valores>();

            foreach (valores m in Tabla)
            {

                // conversion usuario nombre de usuario a ==> id_Usuario       
                // int id_Usuario =

                // p2C.insertaCargaAutomatica(m.monto, id_Usuario, Convert.ToInt16(Session["Empresa"]));

            }

            string confirmacion = @"<script type='text/javascript'>
                                alert('Los datos fueron cargados satisfactoriamente');
                                </script>";

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion, false);

            TextBox_Archivo_MercadoPago.Text = "";

            return;
        }

        protected void BtnPaypal_Click(object sender, EventArgs e)
        {
            if (TextBox_Archivo_Paypal.Text == string.Empty || TextBox_DolarPeso.Text == string.Empty)
            {
                return;
            }

            try
            {
                decimal.Parse(TextBox_DolarPeso.Text);
            }
            catch
            {
                string confirmacion = @"<script type='text/javascript'>
                                alert('Los datos no pudieron ser cargados verifique los valores ingresados');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion, false);
                return;
            }


            List<string> lista = new List<string>();

            lista.Add("fecha");
            lista.Add("monto_bruto");
            lista.Add("usuario");


            XElement xml = new XElement("pagos");

            string url = "http://www.colegioeba.com/pagos/paypal/" + TextBox_Archivo_Paypal.Text + ".html";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);




            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            HttpWebResponse resp;

            try
            {
                resp = req.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                resp = ex.Response as HttpWebResponse;

                string script = @"<script type='text/javascript'>
                                alert('No existe el identificador requerido');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }


            StreamReader reader = new StreamReader(resp.GetResponseStream());

            string HTML = reader.ReadToEnd();

            string[] nombre_de_archivo = HTML.Split('&');

            string[] etiqueta_1 = nombre_de_archivo[0].Split('=');
            string[] etiqueta_2 = nombre_de_archivo[4].Split('=');

            string[] fecha = etiqueta_2[1].Split('+');
            string[] dia = fecha[2].Split('%');

            switch (fecha[1])
            {

                case "Jan":
                    fecha[1] = "01";
                    break;

                case "Feb":

                    fecha[1] = "02";
                    break;

                case "Mar":
                    fecha[1] = "03";
                    break;

                case "Apr":

                    fecha[1] = "04";
                    break;

                case "May":
                    fecha[1] = "05";
                    break;

                case "Jun":

                    fecha[1] = "06";
                    break;

                case "Jul":
                    fecha[1] = "07";
                    break;

                case "Agu":

                    fecha[1] = "08";
                    break;

                case "Sep":
                    fecha[1] = "09";
                    break;

                case "Oct":

                    fecha[1] = "10";
                    break;

                case "Nov":
                    fecha[1] = "11";
                    break;

                case "Dec":

                    fecha[1] = "12";
                    break;
            }


            string[] etiqueta_3 = nombre_de_archivo[26].Split('=');

            string[] moneda = etiqueta_1[1].Split('.');

            XElement pago = new XElement("pago");

            XElement etiqueta_secundaria = new XElement("fecha");
            etiqueta_secundaria.Add(dia[0] + fecha[1] + fecha[3]);
            pago.Add(etiqueta_secundaria);

            XElement etiqueta_tercearia = new XElement("monto_bruto");
            etiqueta_tercearia.Add(moneda[0]);
            pago.Add(etiqueta_tercearia);

            XElement etiqueta_cuartaria = new XElement("usuario");
            etiqueta_cuartaria.Add(etiqueta_3[1]);
            pago.Add(etiqueta_cuartaria);

            xml.Add(pago);

            if (!File.Exists("c:\\pagos/PayPal/" + TextBox_Archivo_Paypal.Text + ".xml"))
            {

                xml.Save("c:\\pagos/PayPal/" + TextBox_Archivo_Paypal.Text + ".xml");

            }
            else
            {

                string script = @"<script type='text/javascript'>
                                alert('El identificador que usted requiere ya fue cargado');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;


            }

            XDocument doc = XDocument.Load("c:\\pagos/PayPal/" + TextBox_Archivo_Paypal.Text + ".xml");

            var query = from m in doc.Descendants("pago")
                        select new valores
                        {
                            fecha = m.Element("fecha").Value,
                            monto = Convert.ToDecimal(m.Element("monto_bruto").Value),
                            usuario = m.Element("usuario").Value,
                        };

            List<valores> Tabla = query.ToList<valores>();

            foreach (valores m in Tabla)
            {

                // conversion usuario nombre de usuario a ==> id_Usuario       
                // int id_Usuario =

                // p2C.insertaCargaAutomatica(m.monto, id_Usuario, Convert.ToInt16(Session["Empresa"]));

            }

            string confirmacion_1 = @"<script type='text/javascript'>
                                alert('Los datos fueron cargados satisfactoriamente');
                                </script>";

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion_1, false);

            TextBox_Archivo_Paypal.Text = "";

            return;
        }
    }
}