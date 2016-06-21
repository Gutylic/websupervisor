using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel3Precios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public int? paginadoOfertas()
        {
            db.paginadoOfertas(ref cantidad);
            return cantidad;
        }

        public List<mostrarOfertasResult> mostrarOfertas(int empresa)
        {
            return db.mostrarOfertas(empresa).ToList();
        }

        public void actualizarOferta(int id_Empresa,bool oferta_1PrestamoSOS,bool oferta_2registro,bool oferta_3ProximaCarga,bool oferta_4AumentoCarga,bool oferta_5RegaloCarga,bool oferta_6DosXUno,bool oferta_7DosXUnoIgualProducto,bool oferta_8Gratis,bool oferta_9DescuentoSegundo,bool oferta_10BonificaciónHabitue,bool oferta_11AumentoDiasCompras,bool oferta_12AumentoDiasTodasCompras,bool oferta_13DescuentoCompra,bool oferta_14ImpresionGratis,bool oferta_15VideosGratis,bool oferta_16EjerciciosGratis,bool oferta_17ExplicacionesGratis)
        {
            db.actualizarOfertas(id_Empresa, oferta_1PrestamoSOS, oferta_2registro, oferta_3ProximaCarga, oferta_4AumentoCarga, oferta_5RegaloCarga, oferta_6DosXUno, oferta_7DosXUnoIgualProducto, oferta_8Gratis, oferta_9DescuentoSegundo, oferta_10BonificaciónHabitue, oferta_11AumentoDiasCompras, oferta_12AumentoDiasTodasCompras, oferta_13DescuentoCompra, oferta_14ImpresionGratis, oferta_15VideosGratis, oferta_16EjerciciosGratis, oferta_17ExplicacionesGratis);
        }


    }
}
