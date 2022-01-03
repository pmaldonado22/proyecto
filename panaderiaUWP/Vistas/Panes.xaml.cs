using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace panaderiaUWP.Vistas
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            /*var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44325/api/pans");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);
            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Pans>>(content);
            */
            HttpClient client = new HttpClient();
            var JsonResponse = await client.GetStringAsync("https://localhost:44325/api/pans");
            var resultado = JsonConvert.DeserializeObject<List<Modelos.Pans>>(JsonResponse);
            Lista.ItemsSource = resultado;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AgregarPan));
        }
       
        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pan = Lista.SelectedItem as Modelos.Pans;
            Frame.Navigate(typeof(Vistas.EditarPan), pan);
        }

        private void HyperlinkButton_Click2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Vistas.Pasteles));
        }

        private void HyperlinkButton_Click3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Vistas.Sucursales));
        }
    }
}
