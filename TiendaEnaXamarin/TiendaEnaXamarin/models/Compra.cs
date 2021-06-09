using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class Compra
    {
        public Producto producto { get; set; }
        public User users_permissions_user { get; set; }
        public float total { get; set; }

        public Compra()
        {
        }

        public Compra(Producto producto, User users_permissions_user, float total)
        {
            this.producto = producto;
            this.users_permissions_user = users_permissions_user;
            this.total = total;
        }
    }
}
