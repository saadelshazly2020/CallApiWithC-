using Newtonsoft.Json;
using NT.Integration.Medicus;
using NT.Integration.Medicus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NT.MedicusIntegration.Dll
{
    public class ResultApi : BaseObj
    {

        /// <summary>
        /// add report for specific patient (no PDF file).
        /// </summary>
        /// <param name="body"> MedicalReportBody object that has list of Medical Reports , each medical report has list of panels that has list of biomarkers </param>
        /// <returns> Response object with status code and message</returns>
        public static async Task<Response> MedicalReport(List<MedicalReport> body)
        {
            Response jsonObj;
            try
            {
                //Map domain to entity
                List<Integration.Medicus.Entities.MedicalReport> medicalReport = ApiHelper.CreateMap<MedicalReport, Integration.Medicus.Entities.MedicalReport>(body);
                jsonObj = await PostAsync(medicalReport, UrlType.MedicalReport);
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
        public static async Task<Response> MedicalReportPDF(List<MedicalReportPdf> body)
        {
            Response jsonObj = null;
            try
            {
                //map domain to entity
               List< Integration.Medicus.Entities.MedicalReportPdf> medicalReportPdf = ApiHelper.CreateMap< MedicalReportPdf, Integration.Medicus.Entities.MedicalReportPdf>(body);
                jsonObj = await PostAsync(medicalReportPdf, UrlType.MedicalReportPDF);
            }
            catch (Exception e)
            {

                logger.Fatal(e.Message);
            }

            return jsonObj;
        }

    }
}
