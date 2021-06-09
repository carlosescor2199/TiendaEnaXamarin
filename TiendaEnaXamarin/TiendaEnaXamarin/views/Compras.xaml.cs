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
    public partial class Compras : ContentPage
    {
        private static ObservableCollection<Compra> listCompras;
        public Compras()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            cargar();
        }

        public async void cargar()
        {
            HttpClient cl = Endpoint.GetConection();
            string content = await cl.GetStringAsync(Endpoint.url + "/ventas");
            List<Compra> compras = JsonConvert.DeserializeObject<List<Compra>>(content);
            listCompras = new ObservableCollection<Compra>(compras);
            List<CompraVista> listComp = new List<CompraVista>();

            foreach (Compra comp in listCompras)
            {
                CompraVista newComp = new CompraVista(comp.producto.nombre, comp.producto.precio);
                listComp.Add(newComp);
            }

            ComprasList.ItemsSource = listComp;
        }
    }
}