using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel4Precios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public int? paginadoValorOfertas()
        {
            db.paginadoValorOfertas(ref cantidad);
            return cantidad;
        }

        public List<mostrarValorOfertasResult> mostrarValorOfertas(int empresa)
        {
            return db.mostrarValorOfertas(empresa).ToList();
        }

        public void actualizarValorOferta(int id_Empresa, decimal oferta_1PrestamoSOS, decimal oferta_2registro, int oferta_3ProximaCarga, int oferta_4AumentoCarga, decimal oferta_5RegaloCarga, decimal oferta_9DescuentoSegundo,int oferta_11AumentoDiasCompras, int oferta_12AumentoDiasTodasCompras, decimal oferta_13DescuentoCompra)
        {
            db.actualizarValorOfertas(id_Empresa,oferta_1PrestamoSOS, oferta_2registro, oferta_3ProximaCarga, oferta_4AumentoCarga, oferta_5RegaloCarga,true,true,0,oferta_9DescuentoSegundo, oferta_11AumentoDiasCompras, oferta_12AumentoDiasTodasCompras, oferta_13DescuentoCompra,0,0,0,0);
        }


    }
}
