using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E144.Controller;
using PM2E144.Models;
using Plugin.Media;
using Plugin.Geolocator;

using Xamarin.Essentials;
using System.IO;

namespace PM2E144
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
      
        public byte[] imageByte;
       
        public Inicio()
        {
            InitializeComponent();
           Localizar();
        }
        private async void Localizar()
        {
            var locator = CrossGeolocator.Current; 

            locator.DesiredAccuracy = 50;

            if (locator.IsGeolocationAvailable) 
            {
                if (locator.IsGeolocationEnabled) 
                {
                    if (!locator.IsListening) 
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5); 
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        lon.Text = loc.Longitude.ToString();
                       
                        lat.Text = loc.Latitude.ToString();
                        
                    };
                }
            }
        }

        private async void TomarFoto_Clicked(object sender, EventArgs e)
        {

            var TakePic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions 
            { 
            Directory= "PhotoApp",
            Name="Imagen.jpg"
       
             });

   

                //await DisplayAlert("Ubicacion del archivo", TakePic.Path, "Ok");

                if (TakePic != null)
            {
                Stream imageStream = null;
                imageStream = TakePic.GetStream();
                BinaryReader br = new BinaryReader(imageStream);
                imageByte = br.ReadBytes((int)imageStream.Length);

                foto.Source = ImageSource.FromStream(()=> { return TakePic.GetStream(); });      
            }

            //compartir imagen

            var sharephoto = TakePic.Path;

            await Share.RequestAsync(new ShareFileRequest  
            
            { 
            Title = "Foto",
            File = new ShareFile(sharephoto)
            
            });

         


        }

        private async  void BtnGuardar_Clicked(object sender, EventArgs e)
        {

            var Sitio = new Sitios

            {
                
                Imagen = imageByte ,
                Latitud = Convert.ToInt32(lat.Text),
                Longitud = Convert.ToInt32(lon.Text),
                Descripcion = Descrip.Text,
                



            };
           
            var resultado = await App.DB.guardar(Sitio);

            if (resultado != 0 )
                await DisplayAlert("Aviso", "Ingresado con exito", "OK");
            else
                await DisplayAlert("Aviso", "Error", "OK");

            await Navigation.PopAsync();


        }

        private void BtnLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaSitios());
        }
    }
}