using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class NewVenta
    {
        public int producto { get; set; }
	    public int users_permissions_user { get; set; }
        public float total { get; set; }

        public NewVenta()
        {
        }

        public NewVenta(int producto, int users_permissions_user, float total)
        {
            this.producto = producto;
            this.users_permissions_user = users_permissions_user;
            this.total = total;
        }
    }
}
