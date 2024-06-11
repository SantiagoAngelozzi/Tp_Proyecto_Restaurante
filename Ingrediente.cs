using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Ingrediente
    {
        private Producto producto;
        private int cantidad;

        public Ingrediente(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public Producto Producto
        {
            get => producto;
            set => producto = value;
        }

        public int Cantidad
        {
            get => cantidad;
            set => cantidad = value;
        }
    }
}
