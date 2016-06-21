using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class panel1PedidoExplicacion
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? cantidad;

        public List<mostrarExplicacionPedidaResult> mostrarPedidoExplicacion(int empresa)
        {
            return db.mostrarExplicacionPedida(empresa).ToList();        
        }

        public int? paginadoPedidoExplicacion(int empresa)
        {
            db.paginadoExplicacionPedida(empresa, ref cantidad);
            return cantidad;        
        }

        public void borrarPedidoExplicacion(int id_PedidoExplicacion)
        {
            db.borrarPedidoExplicacion(id_PedidoExplicacion);        
        }
               
        public void actualizarIndice()
        {
            db.actualizarSecuenciaPedidoExplicacion();
        }

    }
}
