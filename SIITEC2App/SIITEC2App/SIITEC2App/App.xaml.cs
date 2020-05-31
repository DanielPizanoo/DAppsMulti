using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIITEC2App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        public void LoginCheck()
        {
            var token = AppSettings.Instance.AuthToken;
            MainPage = token == null || token.IsExpired ? (Page)new Vistas.Welcome() : new NavigationPage(new Vistas.Perfil.Consultar());
        }

        protected override void OnStart()
        {
            LoginCheck();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
