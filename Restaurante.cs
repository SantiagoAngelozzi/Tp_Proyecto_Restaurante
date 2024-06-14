namespace Tp_Progra2
{
    public class Restaurante
    {
        private string nombre;
        private List<Mesa> mesas;
        private List<Pedido> pedidos;
        private List<Empleado> empleados;
        private List<Producto> inventario;
        private Dictionary<Plato, int> menuPlatos;
        private List<Proveedor> proveedores;
        private decimal arca = 1000000;

        public Restaurante(string nombre)
        {
            this.nombre = nombre;
            this.mesas = new List<Mesa>();
            this.pedidos = new List<Pedido>();
            this.empleados = new List<Empleado>();
            this.inventario = new List<Producto>();
            this.menuPlatos = new Dictionary<Plato, int>();
            this.proveedores = new List<Proveedor>();
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Mesa> Mesas
        {
            get { return mesas; }
            set { mesas = value ?? new List<Mesa>(); }
        }

        public List<Empleado> Empleados
        {
            get { return empleados; }
            set { empleados = value ?? new List<Empleado>(); }
        }

        public List<Producto> Inventario
        {
            get { return inventario; }
            set { inventario = value ?? new List<Producto>(); }
        }

        public Dictionary<Plato, int> MenuPlatos
        {
            get { return menuPlatos; }
            set { menuPlatos = value ?? new Dictionary<Plato, int>(); }
        }

        public List<Proveedor> Proveedores
        {
            get { return proveedores; }
            set {proveedores = value ?? new List<Proveedor>(); }
        }

        public decimal Arca
        {
            get { return arca; }
            set { arca = value; }
        }

        //ADMINISTRACION DE STOCK:

        public void ConsultarStockVigenteEncargado(Encargado encargado, Restaurante restaurante)
        {
            encargado.ConsultarStockVigente(restaurante);
        }

        public void ConsultarStockPorAgotarseEncargado(Encargado encargado, Restaurante restaurante, int umbral)
        {
            encargado.ConsultarStockPorAgotarse(restaurante, umbral);
        }

        //ADMINISTRACION DEL MENU:
        public void CrearPlatoCocinero(Cocinero cocinero, Restaurante restaurante, List<Ingrediente> ingredientes, string nombrePLato, float tiempoPreparacion, int cantidadDePlatos)
        {
            cocinero.CrearPlato(restaurante, ingredientes, nombrePLato, tiempoPreparacion, cantidadDePlatos);
        }
        
        public void EliminarPlatoCocinero(Cocinero cocinero, Restaurante restaurante, string nombreDelPlato, int cantidadAEliminar)
        {
            cocinero.EliminarPlato(restaurante, nombreDelPlato, cantidadAEliminar);
        }

        public void ModificarPlatoCocinero(Cocinero cocinero, Restaurante restaurante, string nombreDelPlatoa, string nuevoNombre, List<Ingrediente> nuevosIngredientes, int nuevoTiempoPreparacion)
        {
            cocinero.ModificarPlato(restaurante, nombreDelPlatoa, nuevoNombre, nuevosIngredientes, nuevoTiempoPreparacion);
        }

        public void MostrarPlatosSegunProductoCocinero(Cocinero cocinero, Restaurante restaurante, Producto producto)
        {
            cocinero.MostrarPlatosSegunProducto(restaurante, producto);
        }

        public void MostrarPlatosSinStockCocinero(Cocinero cocinero, Restaurante restaurante)
        {
            cocinero.MostrarPlatosSinStock(restaurante);
        }

        public void EstablecerPrecioPlatoEncargado(Encargado encargado, Restaurante restaurante, string nombreDelPlato, decimal nuevoPrecio)
        {
            encargado.EstablecerPrecioPlato(restaurante, nombreDelPlato, nuevoPrecio);
        }

        //ADMINISTRACION CONTABLE:
        public void PagarEmpleadosEncargado(Encargado encargado, Restaurante restaurante)
        {
            encargado.PagarEmpleados(restaurante);
        }

        public void ComprarProductoEncargado(Encargado encargado, Restaurante restaurante, Proveedor proveedor, string nombreProducto, int cantidad)
        {
            encargado.ComprarProducto(restaurante, proveedor, nombreProducto, cantidad);
        }

        public void JuntarElDineroDelDiaEncragado(Encargado encargado, Restaurante restaurante)
        {
            encargado.JuntarDineroDelDia(restaurante); // NO LO HICE TODAVIA
        }

        //REGISTROS DE CONSUMOS:

        public void ConsumoTotal()
        {
            //Resolver
        }

        public void ConsumoPorDelivery()
        {
            //Resolver
        }

        public void EstadoMesa()
        {
            //Resolver
        }

        public void RegistrarConsumoPorMedioPago()
        {
            //Resolver
        }

        public void ConsumoPorMesero()
        {
            //Resolver
        }

        public void Top3Ventas()
        {
            //Resolver
        }
        


        //Sobrecarga de operadores para agregar a las respectivas listas:
        public static Restaurante operator +(Restaurante restaurante, Empleado empleado)
        {
            restaurante.Empleados.Add(empleado);
            return restaurante;
        }

        public static Restaurante operator -(Restaurante restaurante, Empleado empleado)
        {
            restaurante.Empleados.Remove(empleado);
            return restaurante;
        }

        public static Restaurante operator +(Restaurante restaurante, Proveedor proveedor)
        {
            restaurante.Proveedores.Add(proveedor);
            return restaurante;
        }

        public static Restaurante operator -(Restaurante restaurante, Proveedor proveedor)
        {
            restaurante.Proveedores.Remove(proveedor);
            return restaurante;
        }

        public static Restaurante operator +(Restaurante restaurante, Mesa mesa)
        {
            restaurante.Mesas.Add(mesa);
            return restaurante;
        }

        public static Restaurante operator -(Restaurante restaurante, Mesa mesa)
        {
            restaurante.Mesas.Remove(mesa);
            return restaurante;
        }
    }
}

