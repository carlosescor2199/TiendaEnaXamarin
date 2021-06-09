using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int stock { get; set; }
        public int numero_ventas { get; set; }
        public Imagen.Imagen imagen { get; set; }

        public Producto() { }

        public Producto(int stock, int numero_ventas)
        {
            this.stock = stock;
            this.numero_ventas = numero_ventas;
        }

        public Producto(int id, string nombre, float precio, int stock, int numero_ventas, Imagen.Imagen imagen)
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
