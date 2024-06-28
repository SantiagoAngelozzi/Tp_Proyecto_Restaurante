using Tp_Progra2;
namespace SimulacionInteraccionesProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante("buen comer");

            Cocinero cocinero1 = new Cocinero("esteban", "quito", "calle falsa 123", "1127141996", 50);
            Encargado encargado1 = new Encargado("Juan", "Cruz", "calle verdadera 123", "1127141123", 100);
            Mesero mesero1 = new Mesero("Juan", "Cruz", "calle verdadera 124", "1127141124", 10);
            Mesero mesero2 = new Mesero("Juan", "Cruz", "calle verdadera 125", "1127141124", 10);
            Mesero mesero3 = new Mesero("Juan", "Cruz", "calle verdadera 126", "1127141124", 10);
            Mesero mesero4 = new Mesero("Juan", "Cruz", "calle verdadera 127", "1127141124", 10);
            Mesero meseroJefe = new Mesero("Juan", "Cruz", "calle verdadera 124", "1127141124", 15);
            DeliveryBoy delivery1 = new DeliveryBoy("Juan", "Cruz", "calle verdadera 125", "1127141125", 10);
            DeliveryBoy delivery2 = new DeliveryBoy("Esteban", "Quito", "calle verdadera 125", "1127141125", 10);

            restaurante.Empleados.Add(cocinero1);
            restaurante.Empleados.Add(delivery1);
            restaurante.Empleados.Add(delivery2);
            restaurante.Empleados.Add(encargado1);
            restaurante.Empleados.Add(meseroJefe);
            restaurante.Empleados.Add(mesero1);
            restaurante.Empleados.Add(mesero2);
            restaurante.Empleados.Add(mesero3);
            restaurante.Empleados.Add(mesero4);

            Proveedor proveedorCarbohidratos = new Proveedor(TipoProducto.carbohidratos, TipoPagoProveedor.contado, 200, "panificadora patagonia", "12-12345678-1", "calle falsa 500", "1127141998", "lunes");
            Proveedor proveedorEmbutidos = new Proveedor(TipoProducto.embutidos, TipoPagoProveedor.contado, 200, "embutidos jonson", "12-12345678-1", "calle falsa 500", "1127141998", "martes");
            Proveedor proveedorBebidas = new Proveedor(TipoProducto.bebidas, TipoPagoProveedor.contado, 200, "todo bebidas", "12-12345678-1", "calle falsa 500", "1127141998", "miercoles");
            Proveedor proveedorBebidasAlcohlicas = new Proveedor(TipoProducto.bebidasAlcohlicas, TipoPagoProveedor.contado, 200, "bebidas alcohlicas", "12-12345678-1", "calle falsa 500", "1127141998", "jueves");

            restaurante.Proveedores.Add(proveedorCarbohidratos);
            restaurante.Proveedores.Add(proveedorEmbutidos);
            restaurante.Proveedores.Add(proveedorBebidas);
            restaurante.Proveedores.Add(proveedorBebidasAlcohlicas);

            Producto producto1 = new Producto("pan");
            Producto producto2 = new Producto("chorizo");

            Producto producto3 = new Producto("pan de pancho");
            Producto producto4 = new Producto("salchicha");

            Ingrediente ingrediente1 = new Ingrediente(producto1, 2);
            Ingrediente ingrediente2 = new Ingrediente(producto2, 1);

            Ingrediente ingrediente3 = new Ingrediente(producto3, 2);
            Ingrediente ingrediente4 = new Ingrediente(producto4, 1);

            List<Ingrediente> ingredientes1 = new List<Ingrediente>();

            List<Ingrediente> ingredientes2 = new List<Ingrediente>();

            ingredientes1.Add(ingrediente1);
            ingredientes1.Add(ingrediente2);
            ingredientes2.Add(ingrediente3);
            ingredientes2.Add(ingrediente4);

            Pedido pedido1 = new Pedido("choripan", TipoPedido.delivery, TipoPagoPedido.billeteraVirtual);
            Pedido pedido2 = new Pedido("choripan", TipoPedido.delivery, TipoPagoPedido.billeteraVirtual);
            Pedido pedido3 = new Pedido("choripan", TipoPedido.delivery, TipoPagoPedido.billeteraVirtual);
            Pedido pedido4 = new Pedido("pancho", "cocaCola", TipoPedido.delivery, TipoPagoPedido.billeteraVirtual);
            Pedido pedido5 = new Pedido("choripan", TipoPedido.mesa, TipoPagoPedido.contado);
            Pedido pedido6 = new Pedido("choripan", TipoPedido.mesa, TipoPagoPedido.contado);
            Pedido pedido7 = new Pedido("choripan", TipoPedido.mesa, TipoPagoPedido.contado);
            Pedido pedido8 = new Pedido("pancho", "cocaCola", TipoPedido.mesa, TipoPagoPedido.contado);

            restaurante.Pedidos.Add(pedido1);
            restaurante.Pedidos.Add(pedido2);
            restaurante.Pedidos.Add(pedido3);
            restaurante.Pedidos.Add(pedido4);
            restaurante.Pedidos.Add(pedido5);
            restaurante.Pedidos.Add(pedido6);
            restaurante.Pedidos.Add(pedido7);
            restaurante.Pedidos.Add(pedido8);

            Mesa mesa1 = new Mesa(1, 1);
            Mesa mesa2 = new Mesa(2, 1);
            Mesa mesa3 = new Mesa(3, 1);
            Mesa mesa4 = new Mesa(4, 1);

            restaurante.Mesas.Add(mesa1);
            restaurante.Mesas.Add(mesa2);
            restaurante.Mesas.Add(mesa3);
            restaurante.Mesas.Add(mesa4);


            //INGRESAR PRODUCTOS Y PAGAR AL PROVEEDOR AL INSTANTE:
            restaurante.ComprarBebidaEncargado(encargado1, restaurante, proveedorBebidas, "cocaCola", 100, false);
            restaurante.ComprarProductoEncargado(encargado1, restaurante, proveedorEmbutidos, "salchicha", 100);
            restaurante.ComprarProductoEncargado(encargado1, restaurante, proveedorEmbutidos, "chorizo", 100);
            restaurante.ComprarProductoEncargado(encargado1, restaurante, proveedorCarbohidratos, "pan", 100);
            restaurante.ComprarProductoEncargado(encargado1, restaurante, proveedorCarbohidratos, "pan de pancho", 100);

            //CONSULTA DE STOCK VIGENTE Y POR AGOTARSE:
            restaurante.ConsultarStockVigenteEncargado(encargado1, restaurante);
            restaurante.ConsultarStockPorAgotarseEncargado(encargado1, restaurante, 101);

            //ABM DE PLATOS:
            restaurante.CrearPlatoCocinero(cocinero1, restaurante, ingredientes1, "choripan", 1, 10);
            restaurante.CrearPlatoCocinero(cocinero1, restaurante, ingredientes2, "pancho", 1, 10);

            restaurante.EliminarPlatoCocinero(cocinero1, restaurante, "pancho", 1);
            restaurante.ModificarPlatoCocinero(cocinero1, restaurante, "pancho", "pancho", ingredientes2, 2);

            //CONSULTA DE PLATOS CON UN PRODUCTO
            restaurante.MostrarPlatosSegunProductoCocinero(cocinero1, restaurante, producto1);

            //CONSULTA DE PLATOS DISPONIBLES
            restaurante.MostrarPlatosDisponiblesCocinero(cocinero1, restaurante);

            restaurante.EstablecerPrecioPlatoEncargado(encargado1, restaurante, "pancho", 200);
            restaurante.EstablecerPrecioPlatoEncargado(encargado1, restaurante, "choripan", 200);

            restaurante.RealizarEntregaDelivery(delivery1, restaurante);

            restaurante.AsignarPedidosAMesasMesero(meseroJefe, restaurante);

            restaurante.AsignarMeseroAMesaEncargado(encargado1, mesero1, mesa1);
            restaurante.AsignarMeseroAMesaEncargado(encargado1, mesero2, mesa2);
            restaurante.AsignarMeseroAMesaEncargado(encargado1 ,mesero3, mesa3);
            restaurante.AsignarMeseroAMesaEncargado(encargado1, mesero4, mesa4);

            restaurante.CobrarMesa(mesero1, restaurante);
            restaurante.CobrarMesa(mesero2, restaurante);
            restaurante.CobrarMesa(mesero3, restaurante);
            restaurante.CobrarMesa(mesero4, restaurante);

            //CONSUMO TOTAL
            restaurante.ConsumoTotalRegistroConsumo(restaurante, meseroJefe, delivery1);

            //CONSUMO DE DELIVERY Y MESERO
            restaurante.ConsumoPorDeliveryRegistroConsumo(restaurante, delivery1);
            restaurante.ConsumoPorMeseroRegistroConsumo(restaurante, mesero1);

            //CONSUMO POR MEDIO DE PAGO
            restaurante.ConsumoPorMedioPagoRegistroConsumo(restaurante);

            restaurante.PagarEmpleadosEncargado(encargado1, restaurante);

            //TOP 3 VENTAS
            restaurante.Top3VentasRegistroConsumo(restaurante);

            //CONSULTAR COSUMO NO PAGO DE UNA MESA EN PARTICUALR
            restaurante.EstadoMesaRegistroConsumo(restaurante, 1);

            restaurante.JuntarElDineroDelDiaEncragado(encargado1, restaurante);
        }
    }
}
