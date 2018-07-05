using Newtonsoft.Json;
using NLog;
using NT.Integration.Medicus;
using NT.Integration.Medicus.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NT.Integration.Medicus
{
    public class BaseObj
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        private static HttpClient _client = new HttpClient();
        protected static HttpClient Client
        {
            get
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
                var access_token = GetToken().Result.access_token;
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + access_token);
                return _client;
            }
        }
        /// <summary>
        /// GetToken method is used to get access token to be used as bearer Authorization.
        /// </summary>
        /// <returns>AuthResponse object with access token </returns>
        protected static async Task<AuthResponse> GetToken()
        {
            Entities.ApiConstants apiConstants = ApiHelper.JsonDeserializer<Entities.ApiConstants>("ApiConstants1.json");
             AuthResponse jsonObj;
            var content = new FormUrlEncodedContent(new[]
              {
                 new KeyValuePair <string, string>(nameof(apiConstants.grant_type), apiConstants.grant_type),
                  new KeyValuePair <string, string>(nameof(apiConstants.username), apiConstants.username),
                   new KeyValuePair <string, string>(nameof(apiConstants.password), apiConstants.password),
                 new KeyValuePair<string, string>(nameof(apiConstants.client_id), apiConstants.client_id),
                   new KeyValuePair<string, string>(nameof(apiConstants.client_secret), apiConstants.client_secret)
            });
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
            using (HttpResponseMessage response = await _client.PostAsync(apiConstants.GetTokenUrl, content))
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                jsonObj = JsonConvert.DeserializeObject<AuthResponse>(responseBody);
            }
            return jsonObj;
        }
        protected static async Task<Response> PostAsync<T>(T body, UrlType urlType)
        {
            Response jsonObj;
            var Content = JsonConvert.SerializeObject(body);
            var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
            var byteContent = new ByteArrayContent(buffer);
            Entities.ApiConstants apiConstants = ApiHelper.JsonDeserializer<Entities.ApiConstants>("ApiConstants.json");
            string apiUrl = string.Empty;
            switch (urlType)
            {
                case UrlType.GetToken:
                    apiUrl = apiConstants.GetTokenUrl;
                    break;
                case UrlType.AddPatient:
                    apiUrl = apiConstants.AddPatientUrl;
                    break;
                case UrlType.ManageOrder:
                    apiUrl = apiConstants.ManageOrderUrl;
                    break;
                case UrlType.MedicalReport:
                    apiUrl = apiConstants.MedicalReportUrl;
                    break;
                case UrlType.MedicalReportPDF:
                    apiUrl = apiConstants.MedicalReportPDFUrl;
                    break;
                default:
                    break;
            }
            using (HttpResponseMessage response = await Client.PostAsync(apiUrl, byteContent))
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                jsonObj = JsonConvert.DeserializeObject<Response>(responseBody);
            }
            return jsonObj;
        }

        

    }
}
