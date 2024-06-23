using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Progra2;

namespace TesteoFunciones
{
    [TestClass]
    public class UnitTestAdministracionDelStock
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConsultarStockVigente_InventarioVacio()
        {
            Restaurante restaurante = new Restaurante("Buen Comer");
            Encargado encargado = new Encargado("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);

            restaurante.ConsultarStockVigenteEncargado(encargado, restaurante);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConsultarStockPorAgotarse_NoHayStockPorAgotarse()
        {
            Restaurante restaurante = new Restaurante("Buen Comer");
            Encargado encargado = new Encargado("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);
            Proveedor proveedorCarbohidratos = new Proveedor(TipoProducto.carbohidratos, TipoPagoProveedor.Transferencia, 200, "panificadora patagonia", "12-12345678-1", "calle falsa 500", "1127141998", "lunes");
            Proveedor prveedorEmbutidos = new Proveedor(TipoProducto.embutidos, TipoPagoProveedor.Transferencia, 200, "embutidos jonson", "12-12345678-1", "calle falsa 500", "1127141998", "martes");

            restaurante.ComprarProductoEncargado(encargado, restaurante, prveedorEmbutidos, "Chorizo", 200);
            restaurante.ComprarProductoEncargado(encargado, restaurante, proveedorCarbohidratos, "Pan", 200);

            restaurante.ConsultarStockPorAgotarseEncargado(encargado, restaurante, 199);
        }
    }

}
