namespace Tp_Progra2
{
    public class Restaurante
    {
        private string nombre;
        private List<Mesa> mesas;
        private List<Empleado> empleados;
        private List<Producto> inventario;
        private List<Plato> menu; 
        private int arca;

        public Restaurante(string nombre)
        {
            this.nombre = nombre;
            this.mesas = new List<Mesa>();
            this.empleados = new List<Empleado>();
            this.inventario = new List<Producto>();
            this.menu = new List<Plato>();
            this.arca = 100000;
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

        public int Arca
        {
            get { return arca; }
            set { arca = value; }
        }
    }
}

