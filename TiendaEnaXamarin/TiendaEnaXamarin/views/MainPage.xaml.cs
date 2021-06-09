using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TiendaEnaXamarin.helpers;
using TiendaEnaXamarin.models;
using TiendaEnaXamarin.views;
using Xamarin.Forms;

namespace TiendaEnaXamarin
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        async void Navegar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        public async Task<User> signUpUsers(string username, string cedula, string email, string password, string nombre_completo)
        {
            NewUser user = new NewUser()
            {
                username = username,
                email = email,
                cedula = cedula,
                password = password,
                nombre_completo = nombre_completo

            };
            HttpClient cliente = Endpoint.GetConection();
            
            var response = await cliente.PostAsync(Endpoint.url + "/auth/local/register",
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        private async void Registrar(object sender, EventArgs e)
        {
            try
            {
                User user = await signUpUsers(EntryUsername.Text, EntryCedula.Text, EntryEmail.Text, EntryPassword.Text, EntryNombreCompleto.Text);
                if (user != null)
                {
                    await DisplayAlert("Exitoso", "Usuario guardado de manera satisfactoria", "Ok");
                    await Navigation.PushAsync(new Login());
                }
                else
                {
                    await DisplayAlert("Fallido", "Datos invalidos", "Ok");
                }
            } catch (NullReferenceException err)
            {
                Console.WriteLine(err);
                DisplayAlert("Fallido", "Datos invalidos", "Ok");
            }
            
        }
    }
}
