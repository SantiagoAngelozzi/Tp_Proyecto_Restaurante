using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Plato
    {
        private string nombre;
        private List<Ingrediente> ingredientes;
        private int tiempoPreparacion;
        private decimal precio;

        public Plato(string nombre, List<Ingrediente> ingredientes,decimal precio,int tiempoPreparacion)
        {
            this.nombre = nombre;
            this.ingredientes = ingredientes;
            this.precio = precio;
            this.tiempoPreparacion = tiempoPreparacion;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public decimal Precio
        {
            get => precio;
            set => precio = value;
        }

        public List<Ingrediente> Ingredientes
        {
            get => ingredientes;
            set => ingredientes = value;
        }

        public int TiempoPreparacion
        {
            get => tiempoPreparacion;
            set => tiempoPreparacion = value;
        }

    }

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
