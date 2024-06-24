using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class RegistroDeConsumos
    {
        public static void EstadoMesa(Restaurante restaurante, int idMesa)
        {
            var mesa = restaurante.Mesas.FirstOrDefault(m => m.Id == idMesa);

            if (mesa == null)
            {
                Console.WriteLine($"La mesa con ID {idMesa} no existe en el restaurante.");
                return;
            }

            if (mesa.Cerrada)
            {
                Console.WriteLine($"La mesa con ID {idMesa} ya está paga.");
            }
            else
            {
                Console.WriteLine($"La mesa con ID {idMesa} aún no está paga.");
            }
        }

        public static void ConsumoPorDelivery(Restaurante restaurante, DeliveryBoy delivery)
        {
            decimal totalConsumo = delivery.CalcularConsumos(restaurante);

            Console.WriteLine($"Ingresos totales por consumo de delivery: {totalConsumo}");
        }

        public static void ConsumoPorMesero(Restaurante restaurante, Mesero mesero)
        {
            var totalConsumo = mesero.CalcularConsumo(restaurante);
            Console.WriteLine($"Ingresos totales por consumo en mesas: {totalConsumo}");
        }

        public static void ConsumoPorMedioPago(Restaurante restaurante)
        {
            var pedidosAgrupadosPorTipoPago = restaurante.Pedidos.GroupBy(p => p.TipoPago).ToList();

            foreach (var grupo in pedidosAgrupadosPorTipoPago)
            {
                Console.WriteLine($"Tipo de Pago: {grupo.Key} - Cantidad de Pedidos: {grupo.Count()}");
            }
        }

        public static void Top3Ventas(Restaurante restaurante)
        {
            var pedidosPagados = restaurante.Pedidos.Where(p => p.Pagado).ToList();

            var top3Pedidos = pedidosPagados
                .OrderByDescending(p =>
                {
                    var plato = restaurante.MenuPlatos.Keys.FirstOrDefault(pl => pl.Nombre == p.PlatoPedido);
                    return plato != null ? plato.Precio : 0;
                })
                .Take(3)
                .ToList();

            Console.WriteLine("Top 3 ventas:");

            foreach (var pedido in top3Pedidos)
            {
                var plato = restaurante.MenuPlatos.Keys.FirstOrDefault(pl => pl.Nombre == pedido.PlatoPedido);
                var bebida = restaurante.Inventario.OfType<Bebida>().FirstOrDefault(b => b.Nombre == pedido.BebidaPedida);

                if (plato != null)
                {
                    Console.WriteLine($"Plato: {plato.Nombre}, Precio: {plato.Precio:C}");
                }
                if (bebida != null)
                {
                    Console.WriteLine($"Bebida: {bebida.Nombre}, Precio: {bebida.Precio:C}");
                }
            }
        }

        public static void ConsumoTotal(Restaurante restaurante, Mesero mesero, DeliveryBoy delivery)
        {
            var consumoPorDelivery = delivery.CalcularConsumos(restaurante);
            var consumoPorMeseros = mesero.CalcularConsumo(restaurante);

            var consumoTotal = consumoPorDelivery + consumoPorMeseros;

            Console.WriteLine($"el consumo total es: $ {consumoTotal}");
        }
    }
}
