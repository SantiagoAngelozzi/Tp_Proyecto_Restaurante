using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Pedido
    {
        private string platoPedido;
        private string bebidaPedida;
        private TipoPedido tipoPedido;
        private TipoPagoPedido tipoPago;
        private bool pagado = false;

        public Pedido(string platoPedido, string bebidaPedida, TipoPedido tipoPedido, TipoPagoPedido tipoPago) 
        {
            this.platoPedido = platoPedido;
            this.bebidaPedida = bebidaPedida;
            this.tipoPedido = tipoPedido;
            this.tipoPago = tipoPago;
        }

        public Pedido(string platoPedido, TipoPedido tipoPedido, TipoPagoPedido tipoPago)
        {
            this.platoPedido = platoPedido;
            this.tipoPedido = tipoPedido;
            this.tipoPago = tipoPago;
        } 

        public string PlatoPedido 
        { 
            get => platoPedido;
            set => platoPedido = value;
        }

        public string BebidaPedida
        {
            get => bebidaPedida;
            set => bebidaPedida = value;
        }

        public TipoPedido TipoPedido
        {
            get => tipoPedido;
            set => tipoPedido = value;
        }

        public TipoPagoPedido TipoPago
        {
            get => tipoPago;
            set => tipoPago = value;
        }

        public bool Pagado
        {
            get => pagado;
            set => pagado = value;
        }
    }
}
