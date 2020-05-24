using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Listas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string> alumnos;
        public MainPage()
        {
            InitializeComponent();
            alumnos = new ObservableCollection<string>();
            lstAlumnos.ItemsSource = alumnos;
        }
        private void BtnAgregar_Clicked(object sender, EventArgs args)
        {
            alumnos.Add(txtAlumno.Text);
            txtAlumno.Text = "";
        }
        async private void lstAlumnos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var el = e.Item as String;
            await DisplayAlert("Seleccionado", el, "OK");
            await Navigation?.PushAsync(new Vistas.Alumno { 
                Title = el
                });
        }

        /*async private void ToolbarItemAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation?.PushAsync(new Vistas.FormAlumno
            {
                Alumno = new Modelo.Alumno()
            });
        }*/
    }
}
