using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class UpdateStockNumVentas
    {
        public int stock { get; set; }
        public int numero_ventas { get; set; }

        public UpdateStockNumVentas()
        {
        }

        public UpdateStockNumVentas(int stock, int numero_ventas)
        {
            this.stock = stock;
            this.numero_ventas = numero_ventas;
        }
    }
}
