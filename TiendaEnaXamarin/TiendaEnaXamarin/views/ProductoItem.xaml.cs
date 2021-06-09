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
    public partial class ProductoItem : ContentPage
    {
        private ProductoVista producto { get; set; }
        private User user { get; set; }
        public ProductoItem(ProductoVista productoVista)
        {
            InitializeComponent();
            user = Login.globalUser;
            producto = productoVista;
            lblNombre.Text = producto.nombre;
            lblPrecio.Text = "$ " + producto.precio;
            lblStock.Text = "" + producto.stock;
            imgProdcuto.Source = producto.imagen;
        }


        public async Task<bool> realizarComprar()
        {
            NewVenta newVenta = new NewVenta()
            {
                producto = producto.id,
                users_permissions_user = user.id,
                total = producto.precio,
            };
            HttpClient cliente = Endpoint.GetConection();
            HttpResponseMessage response = await cliente.PostAsync(Endpoint.url + "/ventas",
                new StringContent(JsonConvert.SerializeObject(newVenta), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> actualizarStockNumVenta()
        {
            UpdateStockNumVentas prod = new UpdateStockNumVentas
            {
                stock = producto.stock - 1,
                numero_ventas = producto.numero_ventas + 1
            };
            HttpClient cliente = Endpoint.GetConection();
            HttpResponseMessage response = await cliente.PutAsync(Endpoint.url + "/productos/" + producto.id,
                new StringContent(JsonConvert.SerializeObject(prod), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> actualizarTotales()
        {
            HttpClient cl = Endpoint.GetConection();
            string content = await cl.GetStringAsync(Endpoint.url + "/totales/1");
            Totales totales = JsonConvert.DeserializeObject<Totales>(content);
            
            Totales tol = new Totales
            {
                numero_ventas = totales.numero_ventas + 1,
                total_ventas = totales.total_ventas + producto.precio,
            };
            HttpResponseMessage response = await cl.PutAsync(Endpoint.url + "/totales/1",
                new StringContent(JsonConvert.SerializeObject(tol), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        private async void comprar(object sender, EventArgs e)
        {
            bool resCompra = await realizarComprar();
            bool resStock = await actualizarStockNumVenta();
            bool resTotales = await actualizarTotales();

            if (!resCompra || !resStock || !resTotales)
            {
                await DisplayAlert("Error", "Comprar no realizada", "Ok");
            }
            else
            {
                await DisplayAlert("Success", "Comprar realizada con Exito", "Ok");
                await Navigation.PushAsync(new Productos());
            }

        }
    }
}