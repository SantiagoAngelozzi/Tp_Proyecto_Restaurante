using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Delivery : Empleado
    {
        public Delivery(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public void RealizarEntrega()
        {
            // Implementación de la entrega
        }
    }
}
