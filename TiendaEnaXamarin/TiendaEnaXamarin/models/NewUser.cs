using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class NewUser
    {
        public string username;
        public string email;
        public string nombre_completo;
        public string cedula;
        public string password;
        public bool estrella;

        public NewUser() { }

        public NewUser(string username, string email, string nombre_completo, string cedula, string password, bool estrella)
        {
            this.username = username;
            this.email = email;
            this.nombre_completo = nombre_completo;
            this.cedula = cedula;
            this.password = password;
            this.estrella = estrella;
        }
    }
}
