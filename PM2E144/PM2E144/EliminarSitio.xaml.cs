using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E144.Models;

namespace PM2E144
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EliminarSitio : ContentPage
    {
        public EliminarSitio()
        {
            InitializeComponent();
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {



            var sitio = new Sitios

            {
                Id = Convert.ToInt32(Id.Text),




            };
            var Resultado = await App.DB.borrar(sitio);

            if (Resultado != 0)

                await DisplayAlert("Aviso", "Borrado con exito", "OK");
            else
                await DisplayAlert("Aviso", "Error", "OK");

            await Navigation.PopAsync();
        }
    }
}