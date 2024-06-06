using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Mesero : Empleado
    {
        public Mesero(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public void RealizarEntrega()
        {
            // Implementación de la entrega
        }
    }
}
