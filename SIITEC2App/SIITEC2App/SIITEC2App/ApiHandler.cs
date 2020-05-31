using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebHelpers.OAuth2;
using WebHelpers.Uri;

namespace SIITEC2App
{
    class ApiHandler
    {
        public const string AUTH_REQUEST_URL = "https://siitec2.colima.tecnm.mx/index.php/oauth2/request";
        public const string AUTH_TOKEN_URL = "https://siitec2.colima.tecnm.mx/index.php/oauth2/access_token";

        public const string AUTH_CALLBACK_URL = "https://siitec2.colima.tecnm.mx/index.php/oauth2/app";

        public const string CLIENT_ID = "lwkvd2x7xv8duvkyu5z7t67amxhfhwrvs52oxbmxgarsc37k";
        public const string CLIENT_SECRET = "mNQohtCA6rsgbo870Ya7h0lh31nmOSzR4s1MZdLfcUUnNMVKxeHHO1ldjclpfhNdvaz3RaVaJc04DfalwGMtCBA81ajlTu1EwrJtLvRJ5LIJYeUMCl3r0KS788886yQ2ni0noW2UAEVjwO2onQbZuhduUcTK7TtrUhtCDKozMfZHXgf8V2UCPJCwuZ2HnNLR1dxlmSpaKiVBIloaNzfCqUnMHButZ4Sv8kAUlEgctRQftJllMLWSZLpyFD8";

        public const string API_URL = "https://siitec2.colima.tecnm.mx/api/index.php";

        public static TokenSuccess Token
        {
            get; private set;
        }

        public static async Task<TokenSuccess> CanjearCodigo(string codigo)
        {
            var cliente = new HttpClient();
            var qp = new QueryParameters();
            qp["grant_type"] = "authorization_code";
            qp["client_id"] = CLIENT_ID;
            qp["code"] = codigo;

            var request = new HttpRequestMessage(HttpMethod.Post, AUTH_TOKEN_URL);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", CLIENT_SECRET);
            request.Content = new StringContent(qp.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await cliente.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return Token = JsonConvert.DeserializeObject<TokenSuccess>(content);
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                return null;
            }
        }
    }
}
