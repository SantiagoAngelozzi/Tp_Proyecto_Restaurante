using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Empleado
    {
        private string nombre;
        private string apellido;
        private string direccion;
        private string contacto;
        private decimal sueldo;

        public Empleado(string nombre, string apellido, string direccion, string contacto, decimal sueldo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.contacto = contacto;
            this.sueldo = sueldo;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Apellido
        {
            get => apellido;
            set => apellido = value;
        }

        public string Direccion
        {
            get => direccion;
            set => direccion = value;
        }

        public string Contacto
        {
            get => contacto;
            set => contacto = value;
        }

        public decimal Sueldo
        {
            get => sueldo;
            set => sueldo = value;
        }
    }
}
