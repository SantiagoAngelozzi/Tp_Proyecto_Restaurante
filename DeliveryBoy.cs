using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class DeliveryBoy : Empleado
    {
        private decimal ingresosTotales;
        private string rol = "delivery";

        public DeliveryBoy(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public string Rol
        {
            get => rol;
            set => rol = value;
        }

        public decimal IngresosTotales
        {
            get => ingresosTotales; 
            set => ingresosTotales = value;
        }

        public decimal CalcularConsumos(Restaurante restaurante)
        {
            var pedidosDelivery = restaurante.Pedidos.Where(p => p.TipoPedido == TipoPedido.delivery).ToList();
            foreach (var pedido in pedidosDelivery)
            {
                var plato = restaurante.MenuPlatos.Keys.FirstOrDefault(p => p.Nombre == pedido.PlatoPedido);
                if (plato != null)
                {
                    ingresosTotales += plato.Precio;
                }

                var bebida = restaurante.Inventario.FirstOrDefault(b => b.Nombre == pedido.BebidaPedida && b is Bebida);
                if (bebida != null)
                {
                    ingresosTotales += bebida.Precio;
                }
            }
            return ingresosTotales;
        }

        public void RealizarEntregaDelivery(Restaurante restaurante)
        {
            var pedidosDelivery = restaurante.Pedidos.Where(p => p.TipoPedido == TipoPedido.delivery).ToList();

            foreach (var pedido in pedidosDelivery)
            {
                // Busca el plato en el diccionario MenuPlatos
                var plato = restaurante.MenuPlatos.Keys.FirstOrDefault(p => p.Nombre == pedido.PlatoPedido);
                if (plato != null)
                {
                    if (restaurante.MenuPlatos[plato] > 0)
                    {
                        restaurante.MenuPlatos[plato]--;
                    }
                    else
                    {
                        Console.WriteLine($"No hay suficiente cantidad del plato {pedido.PlatoPedido}");
                    }
                }

                // Busca la bebida en el inventario
                if (!string.IsNullOrEmpty(pedido.BebidaPedida))
                {
                    var bebidaInventario = restaurante.Inventario.Find(producto => producto.Nombre == pedido.BebidaPedida && producto is Bebida);
                    if (bebidaInventario != null && bebidaInventario.Cantidad > 0)
                    {
                        bebidaInventario.Cantidad--;
                    }
                    else
                    {
                        Console.WriteLine($"No hay suficiente cantidad de la bebida {pedido.BebidaPedida}");
                    }
                }
            }

            foreach (var p in pedidosDelivery)
            {
                p.Pagado = true;
            }
        }
    }
}
