using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NT.MedicusIntegration.Dll
{
    public  class ResultApi : BaseObj
    {
        public ResultApi()
        {

        }
        /// <summary>
        /// add report for specific patient (no PDF file).
        /// </summary>
        /// <param name="body"> MedicalReportBody object that has list of Medical Reports , each medical report has list of panels that has list of biomarkers </param>
        /// <returns> Response object with status code and message</returns>
        public static async Task<Response> MedicalReport(MedicalReportBody body)
        {
            Response jsonObj;
            try
            {
                var Content = JsonConvert.SerializeObject(body);
                var buffer = System.Text.Encoding.UTF8.GetBytes(Content);
                var byteContent = new ByteArrayContent(buffer);
                var token= GetToken().Result;
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
        public static async Task<Response> MedicalReportPDF(MedicalReportPdfBody body)
        {
            Response jsonObj;
            try
            {
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
