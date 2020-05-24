using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listas.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alumno : ContentPage
    {
        public Alumno()
        {
            InitializeComponent();
        }

        async private void ToolbarItemAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation?.PopAsync();
        }
    }
}