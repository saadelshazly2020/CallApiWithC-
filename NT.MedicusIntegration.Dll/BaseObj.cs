using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NT.MedicusIntegration.Dll
{
    public class BaseObj
    {
        private static HttpClient _client = new HttpClient();
        protected static HttpClient Client { get {
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
                var access_token = GetToken().Result.access_token;
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + access_token);
                return _client;
            } }
        /// <summary>
        /// GetToken method is used to get access token to be used as bearer Authorization.
        /// </summary>
        /// <returns>AuthResponse object with access token </returns>
        protected static async Task<AuthResponse> GetToken()
        {
            AuthResponse jsonObj;
            var content = new FormUrlEncodedContent(new[]
              {
                 new KeyValuePair <string, string>("grant_type", "password"),
                  new KeyValuePair <string, string>("username", "al_borg"),
                   new KeyValuePair <string, string>("password", "2PHg@mAw8FOAzJZkLAE2AyN!p-F_5#od"),
                 new KeyValuePair<string, string>("client_id", "qM5nTQcM^KWFr2s1OhCaAwVlLdSg3vLY"),
                   new KeyValuePair<string, string>("client_secret", "UHb!ue*gjxL_xz&^4yHDJpR5Qe5?7RbU")
            });
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
            using (HttpResponseMessage response = await _client.PostAsync("http://104.155.18.156/aggregator/api/web/oauth2/token", content))
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                jsonObj = JsonConvert.DeserializeObject<AuthResponse>(responseBody);
            }
            return jsonObj;
        }

    }
}
