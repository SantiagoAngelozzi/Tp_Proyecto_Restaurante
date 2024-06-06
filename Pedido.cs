using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Pedido
    {
        private Plato platoPedido;
        private Bebida bebidaPedida;
        private TipoPedido tipoPedido;

        public Pedido(Plato platoPedido, Bebida bebidaPedida, TipoPedido tipoPedido) 
        {
            this.platoPedido = platoPedido;
            this.bebidaPedida = bebidaPedida;
            this.tipoPedido = tipoPedido;
        }

        public Plato PlatoPedido 
        { 
            get => platoPedido;
            set => platoPedido = value;
        }

        public Bebida BebidaPedida
        {
            get => bebidaPedida;
            set => bebidaPedida = value;
        }

        public TipoPedido TipoPedido
        {
            get => tipoPedido;
            set => tipoPedido = value;
        }
    }
}
