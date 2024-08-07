﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Encargado : Empleado
    {
        private string rol = "encargado";
        public Encargado(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public string Rol
        {
            get => rol;
            set => rol = value;
        }

        public void AgregarProductoAInventario(Restaurante restaurante, Producto producto)
        {
            if (restaurante.Inventario.Any(p => p.Nombre == producto.Nombre))
            {
                throw new InvalidOperationException("El producto ya existe en el inventario.");
            }
            restaurante.Inventario.Add(producto);
        }

        public void AgregarBebidaAlInventario(Restaurante restaurante, Bebida bebida)
        {

            if (restaurante.Inventario.Any(p => p.Nombre == bebida.Nombre))
            {
                throw new InvalidOperationException("El producto ya existe en el inventario.");
            }
            restaurante.Inventario.Add(bebida);
        }

        public void EstablecerPrecioPlato(Restaurante restaurante, string nombreDelPlato, decimal nuevoPrecio)
        {
            var platoExistente = restaurante.MenuPlatos.Keys.FirstOrDefault(plato => plato.Nombre == nombreDelPlato);
            if (platoExistente == null)
            {
                throw new InvalidOperationException($"El plato {nombreDelPlato} no se encontró en el menú.");
            }

            // Establecer el nuevo precio del plato
            platoExistente.Precio = nuevoPrecio;

            Console.WriteLine($"El precio del plato {nombreDelPlato} ha sido establecido a {nuevoPrecio}.");
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

        public void ComprarProducto(Restaurante restaurante, Proveedor proveedor, string nombreProducto, int cantidad)
        {       
                var precioPorUnidad = proveedor.PrecioUnitario;
                decimal costoTotal = cantidad * proveedor.PrecioUnitario;
                if (restaurante.Arca < costoTotal)
                {
                    throw new InvalidOperationException("Fondos insuficientes en las arcas del restaurante.");
                }

                Producto producto = proveedor.VenderProducto(nombreProducto, cantidad, precioPorUnidad);
                restaurante.Arca -= costoTotal;
                AgregarProductoAInventario(restaurante, producto);

        }

        public void ComprarBebidas(Restaurante restaurante, Proveedor proveedor, string nombreProducto, int cantidad, bool alcoholica)
        {
            var precioPorUnidad = proveedor.PrecioUnitario;
            decimal costoTotal = cantidad * proveedor.PrecioUnitario;
            if (restaurante.Arca < costoTotal)
            {
                throw new InvalidOperationException("Fondos insuficientes en las arcas del restaurante.");
            }

            Bebida bebida = proveedor.VenderBebida(nombreProducto, cantidad, precioPorUnidad, alcoholica);
            restaurante.Arca -= costoTotal;
            AgregarBebidaAlInventario(restaurante, bebida);
        }

        public void PagarEmpleados(Restaurante restaurante)
        {
            decimal totalSueldos = 0;

            // Ordenar empleados por prioridad: primero encargados, luego cocineros, y finalmente meseros y delivery
            var empleadosOrdenados = restaurante.Empleados.OrderByDescending(e => e is Encargado).ThenByDescending(e => e is Cocinero).ThenBy(e => e is Mesero || e is DeliveryBoy).ToList();

            foreach (var empleado in empleadosOrdenados)
            {
                totalSueldos += empleado.Sueldo;
            }

            if (restaurante.Arca < totalSueldos)
            {
                throw new InvalidOperationException("No hay suficiente balance para pagar a todos los empleados");
            }
            else
            {
                // Pagar a cada empleado según el orden
                foreach (var empleado in empleadosOrdenados)
                {
                    if (restaurante.Arca >= empleado.Sueldo)
                    {
                        restaurante.Arca -= empleado.Sueldo;
                        Console.WriteLine($"Pagado {empleado.Sueldo} a {empleado.GetType().Name} {empleado.Nombre}");
                    }
                    else
                    {
                        Console.WriteLine($"No se puede pagar a {empleado.GetType().Name} {empleado.Nombre} debido a fondos insuficientes.");
                        throw new InvalidOperationException("Fondos insuficientes durante el pago a los empleados");
                    }
                }
            }

            Console.WriteLine($"Total sueldos pagados: ${totalSueldos}");
            Console.WriteLine($"Balance restante: ${restaurante.Arca}");
        }

        public void JuntarDineroDelDia(Restaurante restaurante)
        {
            decimal totalIngresosEmpleados = 0;

            foreach (var empleado in restaurante.Empleados)
            {
                if (empleado is Mesero mesero)
                {
                    totalIngresosEmpleados += mesero.IngresosTotales;
                    mesero.IngresosTotales = 0; // Reiniciar ingresos después de cobrar
                }
                else if (empleado is DeliveryBoy delivery)
                {
                    totalIngresosEmpleados += delivery.IngresosTotales;
                    delivery.IngresosTotales = 0; // Reiniciar ingresos después de cobrar
                }
            }

            restaurante.Arca += totalIngresosEmpleados;
            Console.WriteLine($"total de ingresos del dia: ${totalIngresosEmpleados}");
            Console.WriteLine($"Balance restante: ${restaurante.Arca}");
        }

        public void AsignarMeseroAMesa(Mesero mesero, Mesa mesa)
        {
            if (mesa.MeseroAsignado != null)
            {
                throw new InvalidOperationException($"La mesa {mesa.Id} ya tiene un mesero asignado: {mesa.MeseroAsignado.Nombre}.");
            }

            mesa.AsignarMesero(mesero, mesa);
            Console.WriteLine($"El mesero {mesero.Nombre} ha sido asignado a la mesa {mesa.Id}.");
        }
    }
}
