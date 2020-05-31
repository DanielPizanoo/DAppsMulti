using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SIITEC2App.Modelo.Siitec2
{
    public class Perfil
    {
        [JsonProperty("usuario_id")]
        public int ID { get; private set; }

        [JsonProperty("tipo_usuario")]
        public string TipoUsuario { get; private set; }

        [JsonProperty("nombre")]
        public string Nombre { get; private set; }

        [JsonProperty("apellido1")]
        public string Apellido1 { get; private set; }

        [JsonProperty("apellido2")]
        public string Apellido2 { get; private set; }

        [JsonProperty("carrera")]
        public string Carrera { get; private set; }

        [JsonProperty("departamento")]
        public string Departamento { get; private set; }

        public static async Task<Perfil> GetAsync()
        {
            var client = new HttpClient();

            var token = AppSettings.Instance.AuthToken;

            var request = new HttpRequestMessage(HttpMethod.Get, ApiHandler.API_URL + "/perfil/own");
            request.Headers.Authorization = new AuthenticationHeaderValue(token.Type, token.AccessToken);

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Perfil>(content);
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(String.Format("{0}: {1}", response.StatusCode, content));
            }
        }
    }
}
