using Newtonsoft.Json;
using NT.MedicusIntegration.Dll.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NT.MedicusIntegration.Dll
{
    public class MedicusIntegration
    {
        HttpClient Client;
        public MedicusIntegration()
        {
            Client = new HttpClient();
        }
        /// <summary>
        /// GetToken method is used to get access token to be used as bearer Authorization.
        /// </summary>
        /// <returns>AuthResponse object with access token </returns>
        public async Task<AuthResponse> GetToken()
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
            string _ContentType = "application/json";
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
            using (HttpResponseMessage response = await Client.PostAsync("http://104.155.18.156/aggregator/api/web/oauth2/token", content))
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                jsonObj = JsonConvert.DeserializeObject<AuthResponse>(responseBody);
            }
            return jsonObj;
        }
        /// <summary>
        /// add new patient with specified data
        /// </summary>
        /// <param name="body"> PatientBody object that has list of patients and each patient has list of attributes  </param>
        /// <returns> Response object with status code and message</returns>
        public async Task<Response> AddPatient(PatientBody body)
        {
            Response jsonObj;
            try
            {
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
                var auth = GetToken();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + auth.Result.access_token);
                var Content = JsonConvert.SerializeObject(body);
                var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
                var byteContent = new ByteArrayContent(buffer);
                using (HttpResponseMessage response = await Client.PostAsync("http://104.155.18.156/aggregator/api/web/v1/patients/add", byteContent))
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    jsonObj = JsonConvert.DeserializeObject<Response>(responseBody);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return jsonObj;
        }
        /// <summary>
        /// add new order of existing patient.
        /// </summary>
        /// <param name="body"> OrderBody object that has list of Orders</param>
        /// <returns> Response object with status code and message</returns>
        public async Task<Response> ManageOrder(OrderBody body)
        {
            Response jsonObj;
            try
            {
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
                var auth = GetToken();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + auth.Result.access_token);
                var Content = JsonConvert.SerializeObject(body);
                var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
                var byteContent = new ByteArrayContent(buffer);
                using (HttpResponseMessage response = await Client.PostAsync("http://104.155.18.156/aggregator/api/web/v1/manage-orders/manage", byteContent))
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    jsonObj = JsonConvert.DeserializeObject<Response>(responseBody);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return jsonObj;
        }
        /// <summary>
        /// add report for specific patient (no PDF file).
        /// </summary>
        /// <param name="body"> MedicalReportBody object that has list of Medical Reports , each medical report has list of panels that has list of biomarkers </param>
        /// <returns> Response object with status code and message</returns>
        public async Task<Response> MedicalReport(MedicalReportBody body)
        {
            Response jsonObj;
            try
            {
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
                var auth = GetToken();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + auth.Result.access_token);
                var Content = JsonConvert.SerializeObject(body);
                var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
                var byteContent = new ByteArrayContent(buffer);
                using (HttpResponseMessage response = await Client.PostAsync("http://104.155.18.156/aggregator/api/web/v1/medical-records/add", byteContent))
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    jsonObj = JsonConvert.DeserializeObject<Response>(responseBody);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return jsonObj;
        }
        /// <summary>
        /// add PDF report for specific patient.
        /// </summary>
        /// <param name="body"> MedicalReportBody object that has list of MedicalReportPdfs each MedicalReportPdf contains the file as Base64.  </param>
        /// <returns> Response object with status code and message</returns>
        public async Task<Response> MedicalReportPDF(MedicalReportPdfBody body)
        {
            Response jsonObj;
            try
            {
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;");
                var auth = GetToken();
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + auth.Result.access_token);
                var Content = JsonConvert.SerializeObject(body);
                var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
                var byteContent = new ByteArrayContent(buffer);
                using (HttpResponseMessage response = await Client.PostAsync("http://104.155.18.156/aggregator/api/web/v1/pdf/add", byteContent))
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    jsonObj = JsonConvert.DeserializeObject<Response>(responseBody);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return jsonObj;
        }


    }
}
