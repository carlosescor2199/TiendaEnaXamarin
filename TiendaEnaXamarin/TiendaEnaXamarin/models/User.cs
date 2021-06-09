using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class User
    {
        public int id;
        public string username;
        public string email;
        public string nombre_completo;
        public string cedula;

        public User() {}

        public User(int id, string username, string email, string nombre_completo, string cedula)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.nombre_completo = nombre_completo;
            this.cedula = cedula;
        }

    }
}
