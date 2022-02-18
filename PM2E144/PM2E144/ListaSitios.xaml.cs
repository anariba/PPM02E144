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
    public partial class ListaSitios : ContentPage
    {
        public ListaSitios()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listasitios.ItemsSource = await App.DB.Listasitios();

        }

        private async void listasitios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sitios item = (Sitios)e.SelectedItem;
            var newpage = new EliminarSitio();
            newpage.BindingContext = item;
            await Navigation.PushAsync(newpage);


        }

   
    }
}