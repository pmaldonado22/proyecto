using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace panaderiaUWP.Vistas
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EditarPan : Page
    {
        private Modelos.Pans pan = new Modelos.Pans();
        public EditarPan()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            pan = e.Parameter as Modelos.Pans;
            ID.Text = pan.PanID.ToString();
            pan.AdminID = 1;
            nombrePan.Text = pan.NombrePan;
            precio.Text = pan.Precio.ToString();
            cantidad.Text = pan.Cantidad.ToString();
            //ByteToImage(pan.Imagen);
        }




        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            pan.PanID = int.Parse(ID.Text);
            pan.AdminID = 1;
            pan.NombrePan = nombrePan.Text;
            pan.Precio = decimal.Parse(precio.Text);
            pan.Cantidad = int.Parse(cantidad.Text);

            var panJson = JsonConvert.SerializeObject(pan);
            var HttpContent = new StringContent(panJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            await client.PutAsync("https://localhost:44325/api/pans" + pan.PanID, HttpContent);

            Frame.GoBack();
        }

        private async void AppBarButton_Click2(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            await client.DeleteAsync("https://localhost:44325/api/pans" + pan.PanID);
            Frame.GoBack();
        }
    }
}
