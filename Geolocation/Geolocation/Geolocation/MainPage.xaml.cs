using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Plugin.Geolocator;

namespace Geolocation
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public Xamarin.Forms.GoogleMaps.Map mapa = new Xamarin.Forms.GoogleMaps.Map();

        public MainPage()
        {
            //Se genera el metodo para que se muestre el mapa en la pantalla principal
            mapa.IsShowingUser = true;
            //Se invoca el metodo que nos obtendra las coordenadas de nuestra ubicacion actual
            findMe();

            //Se crea una variable que llevara las coordenadas a dar al Pin
            var position = new Position(19.251615, -103.753149);
            //Se crea el Pin a mostrar en el mapa
            var pin1 = new Pin
            {
                Type = PinType.Generic,

                Position = position,
                Label = "Mi ubicacion",
                Address = "Pos aqui"
            };

            mapa.Pins.Add(pin1);

            Content = new StackLayout
            {

                Children = {
                    mapa
                }
            };
        }

        private async void findMe()
        {
            //Acceso al API
            var locator = CrossGeolocator.Current;
            //Uso del Geolocator
            Plugin.Geolocator.Abstractions.Position position = new Plugin.Geolocator.Abstractions.Position();

            position = await locator.GetPositionAsync();
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                            Distance.FromMeters(200)));
        }
    }
}
