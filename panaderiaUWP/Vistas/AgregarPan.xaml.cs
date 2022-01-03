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
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace panaderiaUWP
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AgregarPan : Page
    {
        public StorageFile file;
        public byte[] imageByte;

        public AgregarPan()
        {
            this.InitializeComponent();
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var pan = new Modelos.Pans()
            {
                PanID = int.Parse(ID.Text),
                AdminID = 1,
                NombrePan = nombrePan.Text,
                Precio = decimal.Parse(precio.Text),
                Cantidad = int.Parse(cantidad.Text),
                Imagen = this.imageByte,
            };
            var panJson = JsonConvert.SerializeObject(pan);
            var client = new HttpClient();
            var HttpContent = new StringContent(panJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PostAsync("https://localhost:44325/api/pans", HttpContent);

            Frame.GoBack();
        }

        private void AppBarButton_Click2(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Capturar(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");

            file = await picker.PickSingleFileAsync();
            if (file == null)
                return;

            var bitmap = new BitmapImage();
            await bitmap.SetSourceAsync(await file.OpenReadAsync());
            Serializar();
            this.Imagen1.Source = bitmap;
        }

        private async void Serializar()
        {
            using(var inputStream = await file.OpenSequentialReadAsync())
            {
                var readStream = inputStream.AsStreamForRead();
                var byteArray = new byte[readStream.Length];
                await readStream.ReadAsync(byteArray, 0, byteArray.Length);
                this.imageByte = byteArray;
            }
        }
    }
}
