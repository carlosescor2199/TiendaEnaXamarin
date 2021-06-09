using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TiendaEnaXamarin.helpers;
using TiendaEnaXamarin.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaEnaXamarin.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        public static User globalUser { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        async void Navegar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Productos());
        }

        public async Task<User> LoginUsers(string username, string password)
        {
            LoginUser user = new LoginUser()
            {
                identifier = username,
                password = password
            };
            HttpClient cliente = Endpoint.GetConection();
            HttpResponseMessage response = await cliente.PostAsync(Endpoint.url + "/auth/local",
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                User usuario = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                globalUser = usuario;
                return usuario;
            }
            return null;
        }

        private async void LoginUser(object sender, EventArgs e)
        {
            try
            {
                User user = await LoginUsers(EntryUser.Text, EntryPassword.Text);

                if (user != null)
                {
                    await DisplayAlert("Exitoso", "Usuario Encontrado", "Ok");
                    await Navigation.PushAsync(new Productos());
                }
                else
                {
                    await DisplayAlert("Fallido", "Datos invalidos", "Ok");
                }
            } catch(NullReferenceException err)
            {
                await DisplayAlert("Fallido", "Datos invalidos", "Ok");
            }           
        }
    }
}
