using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace PM2E144
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
      

        public Home()
        {
            InitializeComponent();
           


        }
        



        private void btnSitios_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Inicio());
        }

    
      

        private void ListaSitios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}