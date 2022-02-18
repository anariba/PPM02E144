using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E144.Controller;
using PM2E144.Models;
using System.IO;

namespace PM2E144
{


    public partial class App : Application

    {
        static SitioDB basedatos;

        public static SitioDB DB
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new SitioDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SitioDB.db3"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();

            MainPage = new NavigationPage(new Home());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
