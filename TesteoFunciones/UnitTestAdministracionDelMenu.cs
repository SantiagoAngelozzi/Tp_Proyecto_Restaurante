using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Progra2;

namespace TesteoFunciones
{
    [TestClass]
    public class UnitTestAdministracionDelMenu
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CrearPlato_IngredientesInsuficientes()
        {
            Restaurante restaurante = new Restaurante("Buen Comer");
            Cocinero cocinero = new Cocinero("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);
            Producto producto1 = new Producto("Pan");
            Producto producto2 = new Producto("Chorizo");

            Ingrediente ingrediente1 = new Ingrediente(producto1, 1);
            Ingrediente ingrediente2 = new Ingrediente(producto2, 1);

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            ingredientes.Add(ingrediente1);
            ingredientes.Add(ingrediente2);

            restaurante.CrearPlatoCocinero(cocinero, restaurante, ingredientes, "choripan", 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EliminarPlato_Inexistente()
        {
            Restaurante restaurante = new Restaurante("Buen Comer");
            Cocinero cocinero = new Cocinero("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);

            restaurante.EliminarPlatoCocinero(cocinero, restaurante, "Choripan", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EliminarPlato_CantidadInapropiada()
        {
            Restaurante restaurante = new Restaurante("Buen Comer");
            Cocinero cocinero = new Cocinero("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);

            Encargado encargado = new Encargado("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);

            Proveedor proveedorCarbohidratos = new Proveedor(TipoProducto.carbohidratos, TipoPagoProveedor.Transferencia, 200, "panificadora patagonia", "12-12345678-1", "calle falsa 500", "1127141998", "lunes");
            Proveedor prveedorEmbutidos = new Proveedor(TipoProducto.embutidos, TipoPagoProveedor.Transferencia, 200, "embutidos jonson", "12-12345678-1", "calle falsa 500", "1127141998", "martes");

            restaurante.ComprarProductoEncargado(encargado, restaurante, prveedorEmbutidos, "Chorizo", 1);
            restaurante.ComprarProductoEncargado(encargado, restaurante, proveedorCarbohidratos, "Pan", 1);

            Producto producto1 = new Producto("Pan");
            Producto producto2 = new Producto("Chorizo");

            Ingrediente ingrediente1 = new Ingrediente(producto1, 1);
            Ingrediente ingrediente2 = new Ingrediente(producto2, 1);

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            ingredientes.Add(ingrediente1);
            ingredientes.Add(ingrediente2);

            restaurante.CrearPlatoCocinero(cocinero, restaurante, ingredientes, "Choripan", 1, 1);

            restaurante.EliminarPlatoCocinero(cocinero, restaurante, "Choripan", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ModificarPlato_Inexistente()
        {
            Restaurante restaurante = new Restaurante("Buen Comer");
            Cocinero cocinero = new Cocinero("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);

            Producto producto1 = new Producto("Pan");
            Producto producto2 = new Producto("Chorizo");

            Ingrediente ingrediente1 = new Ingrediente(producto1, 1);
            Ingrediente ingrediente2 = new Ingrediente(producto2, 2);

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            ingredientes.Add(ingrediente1);
            ingredientes.Add(ingrediente2);

            restaurante.ModificarPlatoCocinero(cocinero, restaurante, "Choripan", "Chori Pan", ingredientes, 2);
        }
    }

}
