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
            restaurante.Inventario.Add(producto);
        }

        public void EstablecerPrecioPlato(Restaurante restaurante, Plato plato, decimal nuevoPrecio)
        {
            plato.Precio = nuevoPrecio;
        }

        public void ConsultarStockVigente(Restaurante restaurante)
        {
            foreach (var producto in restaurante.Inventario)
            {
                Console.WriteLine($"Producto: {producto.Nombre}, Cantidad: {producto.Cantidad}");
            }
        }

        public void ConsultarStockPorAgotarse(Restaurante restaurante, int umbral)
        {
            foreach (var producto in restaurante.Inventario)
            {
                if (producto.Cantidad < umbral)
                {
                    Console.WriteLine($"Producto: {producto.Nombre}, Cantidad: {producto.Cantidad}");
                }
            }
        }
    }
}
