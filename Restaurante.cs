namespace Tp_Progra2
{
    public class Restaurante
    {
        private string nombre;
        private List<Mesa> mesas;
        private List<Empleado> empleados;
        private List<Producto> inventario;
        private List<Plato> menu; 
        private decimal arca;

        public Restaurante(string nombre)
        {
            this.nombre = nombre;
            this.mesas = new List<Mesa>();
            this.empleados = new List<Empleado>();
            this.inventario = new List<Producto>();
            this.menu = new List<Plato>();
            this.arca = 1000000;
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

        public List<Plato> Menu
        {
            get { return menu; }
            set { menu = value ?? new List<Plato>(); }
        }

        public decimal Arca
        {
            get { return arca; }
            set { arca = value; }
        }

        // Sobrecarga del operador + para agregar Producto al Inventario
        public static Restaurante operator +(Restaurante restaurante, Producto producto)
        {
            if (restaurante.Inventario.Any(p => p.Nombre == producto.Nombre))
            {
                throw new InvalidOperationException("El producto ya existe en el inventario.");
            }
            restaurante.Inventario.Add(producto);
            return restaurante;
        }

        // Sobrecarga del operador - para eliminar Producto del Inventario
        public static Restaurante operator -(Restaurante restaurante, Producto producto)
        {
            if (!restaurante.Inventario.Remove(producto))
            {
                throw new KeyNotFoundException("El producto no se encontró en el inventario.");
            }
            return restaurante;
        }

        // Sobrecarga del operador + para agregar Plato al Menu
        public static Restaurante operator +(Restaurante restaurante, Plato plato)
        {
            if (restaurante.Menu.Any(p => p.Nombre == plato.Nombre))
            {
                throw new InvalidOperationException("El plato ya existe en el menú.");
            }
            restaurante.Menu.Add(plato);
            return restaurante;
        }

        // Sobrecarga del operador - para eliminar Plato del Menu
        public static Restaurante operator -(Restaurante restaurante, Plato plato)
        {
            if (!restaurante.Menu.Remove(plato))
            {
                throw new KeyNotFoundException("El plato no se encontró en el menú.");
            }
            return restaurante;
        }
    }
}

