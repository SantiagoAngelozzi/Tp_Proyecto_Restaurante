using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Proveedor
    {
        private string tipoProducto;
        private string medioPago;
        private string nombre;
        private string cuit;
        private string direccion;
        private string diaEntrega;

        public Proveedor(string tipoProducto, string medioPago, string nombre, string cuit, string direccion, string diaEntrega)
        {
            this.tipoProducto = tipoProducto;
            this.medioPago = medioPago;
            this.nombre = nombre;
            this.cuit = cuit;
            this.direccion = direccion;
            this.diaEntrega = diaEntrega;
        }

        public string TipoProducto
        {
            get => tipoProducto;
            set => tipoProducto = value;
        }

        public string MedioPago
        {
            get => medioPago;
            set => medioPago = value;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string CUIT
        {
            get => cuit;
            set => cuit = value;
        }

        public string Direccion
        {
            get => direccion;
            set => direccion = value;
        }

        public string DiaEntrega
        {
            get => diaEntrega;
            set => diaEntrega = value;
        }
    }
}
