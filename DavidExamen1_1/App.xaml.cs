using DavidExamen1_1.Services;
using DavidExamen1_1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidExamen1_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var x = DataBase.connection;
            MainPage = new NavigationPage(new LlistaAlumnes());
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
