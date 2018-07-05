using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Integration.Medicus.Entities
{
    internal class ApiConstants
    {
        #region Api Urls
        protected static string Url
        {
            get
            {
                return "http://104.155.18.156/aggregator/api/web/";
            }
        }
        public  string GetTokenUrl { get { return Url + "oauth2/token"; } }
        public  string AddPatientUrl { get { return Url + "v1/patients/add"; } }
        public  string ManageOrderUrl { get { return Url + "v1/manage-orders/manage"; } }
        public  string MedicalReportUrl { get { return Url + "v1/medical-records/add"; } }
        public  string MedicalReportPDFUrl { get { return Url + "v1/pdf/add"; } }
        #endregion

        #region Credentials
        public string grant_type { get { return "password"; } }
        public  string username { get { return "al_borg"; } }
        public  string password { get { return "2PHg@mAw8FOAzJZkLAE2AyN!p-F_5#od"; } }
        public  string client_id { get { return "qM5nTQcM^KWFr2s1OhCaAwVlLdSg3vLY"; } }
        public  string client_secret { get { return "UHb!ue*gjxL_xz&^4yHDJpR5Qe5?7RbU"; } }
        #endregion
    }
}
