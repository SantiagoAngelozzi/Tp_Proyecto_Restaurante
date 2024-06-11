using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Mesa
    {
        private bool ocupada = false;
        private int id;
        private int capacidad;
        private Mesero meseroAsignado;
        private Plato platoAsignado;

        public Mesa(int id, int capacidad)
        {
            this.id = id;
            this.capacidad = capacidad;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Capacidad
        {
            get => capacidad;
            set => capacidad = value;
        }

        public bool Ocupada
        {
            get => ocupada;
            set => ocupada = value;
        }

        public Plato PlatoAsignado
        {
            get => platoAsignado;
            set => platoAsignado = value;
        }

        public Mesero MeseroAsignado
        {
            get => meseroAsignado;
            set => meseroAsignado = value;
        }
    }
}
