using System;
using System.Collections.Generic;
using System.Text;

namespace Apps
{
    class Botones : ContentPage
    {
        public Botones()
        {
            //crear el boton
            Button boton = new Button
            {
                Text = "Presioname",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            boton.Clicked += BtnPresionameOnClicked;

            Button boton2 = new Button { Text = "Presionable" };
            //crear el layout y se hacen los botones
            Content = new StackLayout
            {
                Children =
                {
                    boton,
                    boton2
                }
            };
            for (int i = 0; i < 6; i++)
            {
                var btn = new Button
                {
                    Text = String.Format("Botón{0}", i + 1)
                };
                btn.Clicked += BtnPresionameOnClicked;
                (Content as StackLayout).Children.Add(btn);

            }

            var btnRegresar = new Button();
            btnRegresar.Text = "Regresar";
            btnRegresar.Clicked += BtnRegresar_Clicked;
            (Content as StackLayout).Children.Add(btnRegresar);

            var btnLayouts = new Button
            {
                Text = "Ir a los Layouts"
            };
            btnLayouts.Clicked += BtnLayouts_Clicked;
            (Content as StackLayout).Children.Add(btnLayouts);

            this.Title = "Botones";
            NavigationPage.SetHasNavigationBar(this, false);

        }

        async private void BtnLayouts_Clicked(object sender, EventArgs e)
        {
            await Navigation?.PushAsync(new LayoutsPages());
        }

        async private void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation?.PopAsync();
        }

        private void BtnPresionameOnClicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            boton.BackgroundColor = Color.Coral;
            boton.Text += " - Clickeado";
            DisplayAlert("Botón presionado", "Presionado", "OK");
        }
    }
}
