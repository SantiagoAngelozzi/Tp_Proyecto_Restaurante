using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Mesa
    {
        private bool cerrada = false; //si es true es por que ya pago
        private int id;
        private int capacidad;
        private Mesero meseroAsignado;
        private List<Pedido> pedidos;

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

        public bool Cerrada
        {
            get => cerrada;
            set => cerrada = value;
        }

        public List<Pedido> Pedidos
        {
            get { return pedidos; }
            set { pedidos = value ?? new List<Pedido>();}
        }

        public Mesero MeseroAsignado
        {
            get => meseroAsignado;
            set => meseroAsignado = value;
        }

    }
}
