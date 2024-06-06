using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Bebida : Producto
    {
        private bool esAlcoholica;

        public Bebida(string nombre, int cantidad, decimal precio, bool esAlcoholica) : base(nombre, cantidad, precio)
        {
            this.esAlcoholica = esAlcoholica;
        }

        public bool EsAlcoholica
        {
            get => esAlcoholica;
            set => esAlcoholica = value;
        }
    }
}
