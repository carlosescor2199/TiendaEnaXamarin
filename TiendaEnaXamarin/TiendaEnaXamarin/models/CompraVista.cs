using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.views
{
    public class CompraVista
    {
        public string nombre_producto { get; set; }
        public float total { get; set; }

        public CompraVista(string nombre_producto, float total)
        {
            this.nombre_producto = nombre_producto;
            this.total = total;
        }
    }
}
