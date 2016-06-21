using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1Credito
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public void actualizarTarjeta(int id_Tarjeta, bool bloqueoTarjeta, DateTime vencimientoTarjeta)
        {
            db.actualizarTarjetaPrepaga(id_Tarjeta, bloqueoTarjeta, vencimientoTarjeta);
        }

        public void borrarTarjeta(int id_Tarjeta)
        {
            db.borrarTarjetaPrepaga(id_Tarjeta);
        }

        public int insertarTarjeta(int cantidadTarjetas, DateTime vencimientoTarjeta, decimal valorTarjeta, int empresa)
        {

            Tabla_TarjetaPrepaga Tarjeta = new Tabla_TarjetaPrepaga();
            bool Resultado;

            for (int I = 1; I <= cantidadTarjetas; I++)
            {
                do
                {
                    Random Numero_De_Tarjeta = new Random();
                    int Numero = Numero_De_Tarjeta.Next(1000000, 999999999); // solo considero numeros recordar que si quiero poner letras debo modificar esto

                    Resultado = db.Tabla_TarjetaPrepaga.Any(p => p.codigoTarjeta == Numero.ToString());
                    if (!Resultado)
                    {
                        db.insertarTarjetaPrepaga(Numero.ToString(), vencimientoTarjeta, valorTarjeta, empresa);
                    }

                } while (Resultado);

            }
            return 1;
          
        }

        public List<buscarTarjetaPrepagaResult> buscarTarjeta(string codigoTarjeta, int empresa)
        {
            return db.buscarTarjetaPrepaga(codigoTarjeta, empresa).ToList();
        }

        public List<mostrarTarjetaPrepagaResult> MostrarTarjeta(int empresa)
        {
            return db.mostrarTarjetaPrepaga(empresa).ToList();
        }

        public int? paginadoTarjeta(int empresa)
        {
            db.paginadoTarjetaPrepaga(empresa, ref cantidad);
            return cantidad;
        }

        public void actualizarIndice()
        {
            db.actualizarSecuenciaTarjetaPrepaga();
        }
        
    }
}
