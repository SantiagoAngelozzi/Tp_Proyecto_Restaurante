using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Progra2;

namespace Test
{
    [TestClass]
    public class UnitTestAdministracionContable
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PagarEmpleados_FondosInsuficientes()
        {
            Restaurante restaurante = new Restaurante("Buen Comer");
            restaurante.Arca = 0;
            Encargado encargado = new Encargado("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);
            restaurante.Empleados.Add(encargado);

            restaurante.PagarEmpleadosEncargado(encargado, restaurante);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PagarleAlProveedor_FondosInsuficientes()
        {
            Restaurante restaurante = new Restaurante("buen comer");
            restaurante.Arca = 0;
            Encargado encargado = new Encargado("Santiago", "Angelozzi", "calle falsa 123", "1127141996", 1000);
            Proveedor proveedor = new Proveedor(TipoProducto.carbohidratos, TipoPagoProveedor.contado, 20, "Panificadora", "12-12345678-1", "calle falsa 500", "1127141998", "Lunes");

            restaurante.Empleados.Add(encargado);
            restaurante.Proveedores.Add(proveedor);

            restaurante.ComprarProductoEncargado(encargado, restaurante, proveedor, "Pan", 20);
        }

    }
}
