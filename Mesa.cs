using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Mesa
    {
        private int id;
        private int capacidad;
        private bool ocupada;
        private Mesero meseroAsignado;

        public Mesa(int id, int capacidad, bool ocupada, Mesero meseroAsignado)
        {
            this.id = id;
            this.capacidad = capacidad;
            this.ocupada = false;
            this.meseroAsignado = meseroAsignado;
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

        public Mesero MeseroAsignado
        {
            get => meseroAsignado;
            set => meseroAsignado = value;
        }
    }
}
