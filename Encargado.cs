using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Encargado : Empleado
    {
        public Encargado(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public void AgregarProductoAInventario(Restaurante restaurante, Producto producto)
        {
            restaurante += producto;
        }

        public void EstablecerPrecioPlato(Restaurante restaurante, Plato plato, decimal nuevoPrecio)
        {
            var platoExistente = restaurante.Menu.FirstOrDefault(p => p.Nombre == plato.Nombre);
            if (platoExistente == null)
            {
                throw new KeyNotFoundException("El plato no se encontró en el menú.");
            }
            platoExistente.Precio = nuevoPrecio;
        }

        public void ConsultarStockVigente(Restaurante restaurante)
        {
            if (restaurante.Inventario.Count == 0)
            {
                throw new InvalidOperationException("El inventario está vacío.");
            }

            foreach (var producto in restaurante.Inventario)
            {
                Console.WriteLine($"Producto: {producto.Nombre}, Cantidad: {producto.Cantidad}");
            }
        }

        public void ConsultarStockPorAgotarse(Restaurante restaurante, int umbral)
        {
            var productosPorAgotarse = restaurante.Inventario.Where(p => p.Cantidad < umbral).ToList();
            if (productosPorAgotarse.Count == 0)
            {
                throw new InvalidOperationException("No hay productos por agotarse según el umbral proporcionado.");
            }

            foreach (var producto in productosPorAgotarse)
            {
                Console.WriteLine($"Producto: {producto.Nombre}, Cantidad: {producto.Cantidad}");
            }
        }

        public void ComprarProducto(Restaurante restaurante, Proveedor proveedor, string nombreProducto, int cantidad, decimal precioUnitario)
        {
            decimal costoTotal = cantidad * precioUnitario;
            if (restaurante.Arca < costoTotal)
            {
                throw new InvalidOperationException("Fondos insuficientes en las arcas del restaurante.");
            }

            Producto producto = proveedor.VenderProducto(nombreProducto, cantidad, precioUnitario);
            restaurante.Arca -= costoTotal;
            AgregarProductoAInventario(restaurante, producto);
        }

        public void AsignarMeseroAMesa(Mesero mesero, Mesa mesa)
        {
            mesa.MeseroAsignado = mesero;
        }
    }
}
