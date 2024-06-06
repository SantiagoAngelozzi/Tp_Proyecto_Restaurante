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
            restaurante.Menu.Add(plato);
        }

        public void ModificarPlato(Restaurante restaurante, Plato plato, string nuevoNombre, List<Ingrediente> nuevosIngredientes, int nuevoTiempoPreparacion, decimal nuevoPrecio)
        {
            plato.Nombre = nuevoNombre;
            plato.Ingredientes = nuevosIngredientes;
            plato.TiempoPreparacion = nuevoTiempoPreparacion;
            plato.Precio = nuevoPrecio;
        }

        public void EliminarPlato(Restaurante restaurante, Plato plato)
        {
            restaurante.Menu.Remove(plato);
        }
    }
}
