using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Proveedor
    {
        private TipoProducto tipoProducto;
        private TipoPagoProveedor tipoPago;
        private string nombre;
        private string cuit;
        private string direccion;
        private string contacto;
        private string diaEntrega;
        private decimal precioUnitario;

        public Proveedor(TipoProducto tipoProducto, TipoPagoProveedor tipoPago, decimal precioUnitario, string nombre, string cuit, string direccion,string contacto, string diaEntrega)
        {
            this.tipoProducto = tipoProducto;
            this.tipoPago = tipoPago;
            this.precioUnitario = precioUnitario;
            this.nombre = nombre;
            this.cuit = cuit;
            this.direccion = direccion;
            this.contacto = contacto;
            this.diaEntrega = diaEntrega;
        }

        public TipoProducto TipoProducto
        {
            get => tipoProducto;
            set => tipoProducto = value;
        }

        public TipoPagoProveedor TipoPago
        {
            get => tipoPago;
            set => tipoPago = value;
        }

        public decimal PrecioUnitario
        {
            get => precioUnitario;
            set => precioUnitario = value;
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

        public string Contacto
        {
            get => contacto;
            set => contacto = value;
        }

        public string DiaEntrega
        {
            get => diaEntrega;
            set => diaEntrega = value;
        }
        public Producto VenderProducto(string nombreProducto, int cantidad, decimal precioUnitario)
        {
            return new Producto(nombreProducto, cantidad, precioUnitario);
        }
    }
}
