using Newtonsoft.Json;
using NT.Integration.Medicus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NT.Integration.Medicus.Domain;
namespace NT.MedicusIntegration.Dll
{
    public class PatientApi:BaseObj
    {
        /// <summary>
        /// add new patient with specified data
        /// </summary>
        /// <param name="body"> PatientBody object that has list of patients and each patient has list of attributes  </param>
        /// <returns> Response object with status code and message</returns>
        public static async Task<Response> AddPatient(List<Patient> body)
        {
            Response jsonObj = null;
            try
            {
                //Map domain to entity
                List<Integration.Medicus.Entities.Patient> medicalReport = ApiHelper.CreateMap<Patient, Integration.Medicus.Entities.Patient>(body);
                jsonObj = await PostAsync(body,  UrlType.AddPatient);
            }
            catch (Exception e)
            {
                logger.Fatal(e.InnerException);
            }

            return jsonObj;
        }
    }
}
