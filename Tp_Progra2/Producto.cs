using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Producto
    {
        private string nombre;
        private int cantidad;
        private decimal precio;

        public Producto(string nombre, int cantidad, decimal precio)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public Producto(string nombre) 
        {
            this.nombre = nombre;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public int Cantidad
        {
            get => cantidad;
            set => cantidad = value;
        }

        public decimal Precio
        {
            get => precio;
            set => precio = value;
        }
    }
}
