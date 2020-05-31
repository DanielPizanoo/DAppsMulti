using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIITEC2App.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }

        async private void BtnLoginS2_Clicked(object sender, EventArgs e)
        {
            await Navigation?.PushModalAsync(new OAUTH2Login());
        }
    }
}