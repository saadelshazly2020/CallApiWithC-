using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace NT.MedicusIntegration.Dll
{
    public class PatientApi:BaseObj
    {
        /// <summary>
        /// add new patient with specified data
        /// </summary>
        /// <param name="body"> PatientBody object that has list of patients and each patient has list of attributes  </param>
        /// <returns> Response object with status code and message</returns>
        public static async Task<Response> AddPatient(PatientBody body)
        {
            Response jsonObj;
            try
            {
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
    }
}
