using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using S2 = SIITEC2App.Modelo.Siitec2;

namespace SIITEC2App.Vistas.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consultar : ContentPage
    {
        public S2.Perfil Perfil { get; set; }

        public Consultar()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                this.Perfil = await S2.Perfil.GetAsync();
                this.OnPropertyChanged("Perfil");
            } 
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            AppSettings.Instance.AuthToken = null;
            (App.Current as App).LoginCheck();
        }
    }
}