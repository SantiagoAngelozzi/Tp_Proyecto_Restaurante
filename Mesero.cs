using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Progra2
{
    public class Mesero : Empleado
    {
        private string rol = "mesero";
        public Mesero(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {

        }

        public string Rol
        {
            get => rol;
            set => rol = value;
        }

        public void ObtenerPedidos(Restaurante restaurante)
        {
            foreach (var pedido in restaurante.Pedidos)
            {
                if (pedido.TipoPedido == TipoPedido.mesa)
                {
                    //ver que hacer
                }
            }
        }

    }
}
