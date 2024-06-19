using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Mesa
    {
        private bool cerrada = false; //si es true es por que ya pago y porque esta desocupada.
        private int id;
        private int capacidad;
        private Mesero meseroAsignado;
        private Pedido pedidoAsignado;

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

        public Pedido PedidoAsignado
        {
            get => pedidoAsignado;
            set => pedidoAsignado = value;
        }

        public Mesero MeseroAsignado
        {
            get => meseroAsignado;
            set => meseroAsignado = value;
        }

        public void AsignarMesero(Mesero mesero, Mesa mesa)
        {
            MeseroAsignado = mesero;
            mesero.MesaAsignada = mesa;
        }
    }
}
