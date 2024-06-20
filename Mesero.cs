using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Mesero : Empleado
    {
        private string rol = "mesero";
        private Mesa mesaAsignada;
        private decimal ingresosTotales;

        public Mesero(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public string Rol
        {
            get => rol;
            set => rol = value;
        }

        public Mesa MesaAsignada
        {
            get => mesaAsignada;
            set => mesaAsignada = value;
        }

        public decimal IngresosTotales
        {
            get => ingresosTotales;
            set => ingresosTotales = value;
        }


        public void AsignarPedidosAmesas(Restaurante restaurante)
        {
            var pedidosMesa = restaurante.Pedidos.Where(p => p.TipoPedido == TipoPedido.mesa && !p.Pagado).ToList();

            // Recorrer las mesas disponibles y asignar un pedido a cada una
            foreach (var mesa in restaurante.Mesas)
            {
                if (!pedidosMesa.Any())
                {
                    break; // No hay más pedidos para asignar
                }

                if (!mesa.Cerrada && mesa.PedidoAsignado == null) // Solo asignar a mesas abiertas sin pedidos
                {
                    var pedido = pedidosMesa.First();
                    mesa.PedidoAsignado = pedido;
                    pedidosMesa.Remove(pedido); // Remover el pedido asignado de la lista

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
            }
        }

        public void CobrarMesa(Restaurante restaurante)
        {
            if (MesaAsignada == null)
            {
                throw new InvalidOperationException("No hay mesa asignada al mesero.");
            }

            var mesa = restaurante.Mesas.FirstOrDefault(m => m.Id == MesaAsignada.Id);
            if (mesa == null)
            {
                throw new InvalidOperationException($"La mesa asignada no existe en el restaurante.");
            }

            if (mesa.Cerrada)
            {
                throw new InvalidOperationException($"La mesa {mesa.Id} ya está cerrada.");
            }

            var pedido = mesa.PedidoAsignado;
            if (pedido == null)
            {
                throw new InvalidOperationException($"No hay pedido asignado a la mesa {mesa.Id}.");
            }

            if (!pedido.Pagado)
            {
                pedido.Pagado = true;
            }

            // Marcar la mesa como cerrada
            mesa.Cerrada = true;
            Console.WriteLine($"Mesa {mesa.Id} cobrada con éxito.");
        }
    

        public decimal CalcularConsumo(Restaurante restaurante)
        {
            var pedidosMesa = restaurante.Pedidos.Where(p => p.TipoPedido == TipoPedido.mesa && p.Pagado).ToList();
            foreach (var pedido in pedidosMesa)
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
    }
}
