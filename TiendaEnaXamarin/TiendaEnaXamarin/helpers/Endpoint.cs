using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TiendaEnaXamarin.helpers
{
    public class Endpoint
    {
        public static readonly string url = "http://192.168.1.14:1337";

        public static HttpClient GetConection()
        {
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");
            return cliente;
        }
    }
}
