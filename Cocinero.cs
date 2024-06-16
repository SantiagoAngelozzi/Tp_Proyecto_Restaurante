using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Cocinero : Empleado
    {
        private string rol = "cocinero";
        public Cocinero(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public string Rol
        {
            get => rol;
            set => rol = value;
        }

        public void CrearPlato(Restaurante restaurante, List<Ingrediente> ingredientes, string nombrePlato, float tiempoPreparacion, int cantidadDePlatos)
        {
            foreach (var ingrediente in ingredientes)
            {
                var productoEnInventario = restaurante.Inventario.FirstOrDefault(p => p.Nombre == ingrediente.Producto.Nombre);
                if (productoEnInventario == null || productoEnInventario.Cantidad < ingrediente.Cantidad * cantidadDePlatos)
                {
                    throw new InvalidOperationException($"No hay suficiente {ingrediente.Producto.Nombre} en el inventario.");
                }
            }

            // Restar la cantidad necesaria de cada ingrediente del inventario
            foreach (var ingrediente in ingredientes)
            {
                var productoEnInventario = restaurante.Inventario.First(p => p.Nombre == ingrediente.Producto.Nombre);
                productoEnInventario.Cantidad -= ingrediente.Cantidad * cantidadDePlatos;
            }

            // Crear el nuevo plato
            Plato nuevoPlato = new Plato(nombrePlato, ingredientes, tiempoPreparacion);

            // Agregar el nuevo plato al menú del restaurante
            AgregarPlatoAlMenu(restaurante, nuevoPlato,cantidadDePlatos);
        }

        public void AgregarPlatoAlMenu(Restaurante restaurante, Plato plato, int cantidadDePlatos)
        {
            if (restaurante.MenuPlatos.ContainsKey(plato))
            {
                restaurante.MenuPlatos[plato] += cantidadDePlatos;
            }
            else
            {
                restaurante.MenuPlatos.Add(plato, cantidadDePlatos);
            }

            Console.WriteLine($"Se han agregado {cantidadDePlatos} platos de {plato.Nombre} al menú.");
        }

        public void ModificarPlato(Restaurante restaurante, string nombreDelPlato, string nuevoNombrePlato, List<Ingrediente> nuevosIngredientes, float nuevoTiempoPreparacion)
        {
            // Buscar el plato en el menú
            var platoExistente = restaurante.MenuPlatos.Keys.FirstOrDefault(plato => plato.Nombre == nombreDelPlato);
            if (platoExistente == null)
            {
                throw new InvalidOperationException($"El plato {nombreDelPlato} no se encontró en el menú.");
            }

            // Modificar las propiedades del plato
            platoExistente.Nombre = nuevoNombrePlato;
            platoExistente.Ingredientes = nuevosIngredientes;
            platoExistente.TiempoPreparacion = nuevoTiempoPreparacion;

            Console.WriteLine($"El plato {nombreDelPlato} ha sido modificado exitosamente.");
        }

        public void EliminarPlato(Restaurante restaurante, string nombreDelPlato, int cantidadDePlatosAEliminar)
        {
            // Buscar el plato en el menú
            var platoExistente = restaurante.MenuPlatos.Keys.FirstOrDefault(plato => plato.Nombre == nombreDelPlato);
            if (platoExistente == null)
            {
                throw new InvalidOperationException($"El plato {nombreDelPlato} no se encontró en el menú.");
            }

            // Verificar la cantidad a eliminar
            if (restaurante.MenuPlatos[platoExistente] < cantidadDePlatosAEliminar)
            {
                throw new InvalidOperationException($"No se puede eliminar {cantidadDePlatosAEliminar} platos de {nombreDelPlato} porque solo hay {restaurante.MenuPlatos[platoExistente]} disponibles.");
            }

            // Reducir la cantidad de platos
            restaurante.MenuPlatos[platoExistente] -= cantidadDePlatosAEliminar;

            Console.WriteLine($"Se han eliminado {cantidadDePlatosAEliminar} platos de {nombreDelPlato}. Quedan {restaurante.MenuPlatos[platoExistente]} disponibles.");
            
        }

        public void MostrarPlatosSegunProducto(Restaurante restaurante, Producto producto)
        {
            var platosConProducto = restaurante.MenuPlatos.Keys.Where(plato => plato.Ingredientes.Any(ingrediente => ingrediente.Producto.Nombre == producto.Nombre)).ToList();

            if (platosConProducto.Count == 0)
            {
                throw new InvalidOperationException($"No hay platos en el menú que contengan el producto {producto.Nombre}.");
            }
            else
            {
                Console.WriteLine($"Platos que contienen el producto {producto.Nombre}:");
                foreach (var plato in platosConProducto)
                {
                    Console.WriteLine($"{plato.Nombre} (Cantidad en menú: {restaurante.MenuPlatos[plato]})");
                }
            }
        }

        public void MostrarPlatosSinStock(Restaurante restaurante)
        {

            var platosSinStock = restaurante.MenuPlatos.Where(entry => entry.Value == 0).Select(entry => entry.Key).ToList();

            if (platosSinStock.Count == 0)
            {
                throw new InvalidOperationException("No hay platos sin stock en el menú.");
            }
            else
            {
                Console.WriteLine("Platos sin stock en el menú:");
                foreach (var plato in platosSinStock)
                {
                    Console.WriteLine(plato.Nombre);
                }
            }
        }
    }
}
