using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class DeliveryBoy : Empleado
    {
        private List<Pedido> pedidosDelivery;
        private decimal ingresosTotales;
        private string rol = "delivery";

        public DeliveryBoy(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {
           this.pedidosDelivery = new List<Pedido>();
        }

        public string Rol
        {
            get => rol;
            set => rol = value;
        }

        public List<Pedido> PedidosDelivery
        {
            get { return pedidosDelivery; }
            set { pedidosDelivery = value ?? new List<Pedido>(); }
        }

        public decimal IngresosTotales
        {
            get => ingresosTotales; 
            set => ingresosTotales = value;
        }


        public List<Pedido> ObtenerPedidos(Restaurante restaurante)
        {
           foreach (var pedido in restaurante.Pedidos)
           {
               if (pedido.TipoPedido == TipoPedido.delivery)
               {
                    PedidosDelivery.Add(pedido);
               }
           }
           return PedidosDelivery;
        }

        public decimal CalcularIngresos(List<Pedido> pedidos)
        {
            IngresosTotales = 0;

            foreach (var pedido in pedidos)
            {
                IngresosTotales += pedido.PlatoPedido.Precio;

                IngresosTotales += pedido.BebidaPedida.Precio;

            }

            return IngresosTotales;
        }

        public void RealizarEntregas(Restaurante restaurante) 
        {

            foreach (var pedido in restaurante.Pedidos)
            {
                if (pedido.TipoPedido == TipoPedido.delivery)
                {
                    // Verificar y actualizar el inventario de platos
                    if (restaurante.MenuPlatos.ContainsKey(pedido.PlatoPedido) && restaurante.MenuPlatos[pedido.PlatoPedido] > 0)
                    {
                        restaurante.MenuPlatos[pedido.PlatoPedido] -= 1;
                    }
                    else
                    {
                        Console.WriteLine($"No hay suficiente cantidad del plato {pedido.PlatoPedido.Nombre}");
                        continue; // Saltar al siguiente pedido si no hay suficiente cantidad del plato
                    }

                    // Verificar y actualizar el inventario de bebidas
                    var bebidaInventario = restaurante.Inventario.Find(producto => producto.Nombre == pedido.BebidaPedida.Nombre && producto is Bebida);
                    if (bebidaInventario != null && bebidaInventario.Cantidad > 0)
                    {
                        bebidaInventario.Cantidad -= 1;
                    }
                    else
                    {
                        Console.WriteLine($"No hay suficiente cantidad de la bebida {pedido.BebidaPedida.Nombre}");
                    }
                }
            }
        }
    }
}
