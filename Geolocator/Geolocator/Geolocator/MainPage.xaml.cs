using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Geolocator
{
    public partial class MainPage : ContentPage
    {
        double lati;
        double longi;

        public MainPage()
        {
            InitializeComponent();
            Localizar();
        }

        public async void Localizar()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if(locator.IsGeolocationAvailable)
            {
                if (!locator.IsListening)
                {
                    await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                }
                locator.PositionChanged += (cambio, args) =>
                {
                    var loc = args.Position;
                    lon.Text = loc.Longitude.ToString();
                    longi = double.Parse(lon.Text);
                    lat.Text = loc.Latitude.ToString();
                    lati = double.Parse(lat.Text);
                };
            }
        }

        public async void mostrarMapa(object sender, EventArgs args1)
        {
            MapLaunchOptions options = new MapLaunchOptions { Name = "Mi posición actual" };
            await Map.OpenAsync(lati, longi, options);
        }
    }
}
