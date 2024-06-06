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

        public void CrearPlato(Restaurante restaurante, Plato plato)
        {
            restaurante += plato;
        }

        public void ModificarPlato(Restaurante restaurante, Plato plato, string nuevoNombre, List<Ingrediente> nuevosIngredientes, int nuevoTiempoPreparacion, decimal nuevoPrecio)
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
