using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Promociones : ContentPage
    {
        private static ObservableCollection<Producto> listProductos;
        public Promociones()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            cargar();
        }

        public async void cargar()
        {
            HttpClient cl = Endpoint.GetConection();
            string content = await cl.GetStringAsync(Endpoint.url + "/productos?promocion=true&stock_gt=0");
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(content);
            listProductos = new ObservableCollection<Producto>(productos);
            List<ProductoVista> listProd = new List<ProductoVista>();

            foreach (Producto prod in listProductos)
            {
                ProductoVista newProd = new ProductoVista(prod.id, prod.nombre, prod.precio, prod.stock, prod.numero_ventas, Endpoint.url + prod.imagen.url);
                listProd.Add(newProd);
            }

            ProductosList.ItemsSource = listProd;
        }

        private async void ProductosList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ProductoVista auxProducto = (ProductoVista)e.SelectedItem;
            ProductoVista producto = new ProductoVista
            {
                id = auxProducto.id,
                nombre = auxProducto.nombre,
                precio = auxProducto.precio,
                stock = auxProducto.stock,
                imagen = auxProducto.imagen
            };
            await Navigation.PushAsync(new ProductoItem(producto));
        }

        private void refresh(object sender, EventArgs e)
        {
            cargar();
        }

        private void buscarProducto(object sender, TextChangedEventArgs e)
        {
            string buscar = TxtBuscar.Text;
            List<ProductoVista> prodList = new List<ProductoVista>();

            if (!buscar.Equals(""))
            {
                foreach (Producto prod in listProductos)
                {
                    if (prod.nombre.ToLower().Contains(buscar.ToLower()))
                    {
                        ProductoVista newProd = new ProductoVista(prod.id, prod.nombre, prod.precio, prod.stock, prod.numero_ventas, Endpoint.url + prod.imagen.url);
                        prodList.Add(newProd);
                    }
                }
            }
            else
            {
                foreach (Producto prod in listProductos)
                {
                    ProductoVista newProd = new ProductoVista(prod.id, prod.nombre, prod.precio, prod.stock, prod.numero_ventas, Endpoint.url + prod.imagen.url);
                    prodList.Add(newProd);

                }
            }
            ProductosList.ItemsSource = prodList;

        }
    }
}