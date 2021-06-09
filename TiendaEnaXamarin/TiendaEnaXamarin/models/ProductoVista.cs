using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class ProductoVista
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int stock { get; set; }
        public int numero_ventas { get; set; }
        public string imagen { get; set; }

        public ProductoVista() { }

        public ProductoVista(int stock, int numero_ventas)
        {
            this.stock = stock;
            this.numero_ventas = numero_ventas;
        }

        public ProductoVista(int id, string nombre, float precio, int stock, int numero_ventas, string imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.numero_ventas = numero_ventas;
            this.imagen = imagen;
        }
    }
}
