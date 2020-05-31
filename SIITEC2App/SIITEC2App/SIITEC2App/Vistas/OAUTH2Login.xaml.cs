using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHelpers.Uri;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIITEC2App.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OAUTH2Login : ContentPage
    {
        public OAUTH2Login()
        {
            InitializeComponent();
            WebViewOAuth2.Navigated += WebViewOAuth2_Navigated;
        }

        async private void WebViewOAuth2_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var uri = new Uri(e.Url);
            if (!uri.AbsolutePath.EndsWith("/oauth2/app"))
            {
                return;
            }
            var qp = new QueryParameters(uri.Query.Substring(1));
            if (qp.ContainsParam("code"))
            {
                var codigo = qp.GetParam("code");
                await DisplayAlert("CODIGO", qp.GetParam("code"), "OK");
                var token = await ApiHandler.CanjearCodigo(codigo);
                await DisplayAlert("ACCESS TOKEN", token.AccessToken, "OK");
                AppSettings.Instance.AuthToken = token;
                (App.Current as App).LoginCheck();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var authRequestUri = new UriBuilder(ApiHandler.AUTH_REQUEST_URL);
            var parameters = new QueryParameters();
            parameters.Add("response_type", "code");
            parameters.Add("client_id", ApiHandler.CLIENT_ID);
            authRequestUri.Query = parameters.ToString();
            WebViewOAuth2.Source = authRequestUri.Uri;
        }
    }
}