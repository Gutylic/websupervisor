using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaIngreso
    {

        public int errorContrasena(string contrasena)
        {
            if (contrasena.Length < 10 && contrasena.Length > 5)
            {
                return 1;                
            }
            return -1;
        }

    }
}
