using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Cocinero : Empleado
    {
        public Cocinero(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {
            
        }
        public Plato CrearPlato(Restaurante restaurante, List<Ingrediente> ingredientes, string nombrePlato, float tiempoPreparacion) 
        {
            foreach (var ingrediente in ingredientes)
            {
                var productoEnInventario = restaurante.Inventario.FirstOrDefault(p => p.Nombre == ingrediente.Producto.Nombre);
                if (productoEnInventario == null || productoEnInventario.Cantidad < ingrediente.Cantidad)
                {
                    throw new InvalidOperationException($"No hay suficiente {ingrediente.Producto.Nombre} en el inventario.");
                }
            }

            // Restar la cantidad necesaria de cada ingrediente del inventario
            foreach (var ingrediente in ingredientes)
            {
                var productoEnInventario = restaurante.Inventario.First(p => p.Nombre == ingrediente.Producto.Nombre);
                productoEnInventario.Cantidad -= ingrediente.Cantidad;
            }

            // Crear el nuevo plato
            Plato nuevoPlato = new Plato(nombrePlato,ingredientes, tiempoPreparacion);

            // Agregar el nuevo plato al menú del restaurante
            AgregarPlatoAlMenu(restaurante, nuevoPlato);

            return nuevoPlato;
        }
    

        public void AgregarPlatoAlMenu(Restaurante restaurante, Plato plato)
        {
            restaurante += plato;
        }

        public void ModificarPlato(Restaurante restaurante, Plato plato, string nuevoNombre, List<Ingrediente> nuevosIngredientes, int nuevoTiempoPreparacion)
        {
            var platoExistente = restaurante.Menu.FirstOrDefault(p => p.Nombre == plato.Nombre);
            if (platoExistente == null)
            {
                throw new KeyNotFoundException("El plato no se encontró en el menú.");
            }

            platoExistente.Nombre = nuevoNombre;
            platoExistente.Ingredientes = nuevosIngredientes;
            platoExistente.TiempoPreparacion = nuevoTiempoPreparacion;
        }

        public void EliminarPlato(Restaurante restaurante, Plato plato)
        {
            restaurante -= plato;
        }
    }
}
