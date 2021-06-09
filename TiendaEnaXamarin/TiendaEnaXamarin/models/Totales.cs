using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class Totales
    {
        public int numero_ventas { get; set; }
        public float total_ventas { get; set; }

        public Totales()
        {
        }

        public Totales(int numero_ventas, float total_ventas)
        {
            this.numero_ventas = numero_ventas;
            this.total_ventas = total_ventas;
        }
    }
}
