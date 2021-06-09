using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models
{
    public class LoginUser
    {
        public string identifier;
        public string password;

        public LoginUser()
        {
        }

        public LoginUser(string identifier, string password)
        {
            this.identifier = identifier;
            this.password = password;
        }
    }
}
