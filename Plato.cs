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
        private float tiempoPreparacion;
        private decimal precio;

        public Plato(string nombre, List<Ingrediente> ingredientes, float tiempoPreparacion)
        {
            this.nombre = nombre;
            this.ingredientes = ingredientes;
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

        public float TiempoPreparacion
        {
            get => tiempoPreparacion;
            set => tiempoPreparacion = value;
        }

    }
}
