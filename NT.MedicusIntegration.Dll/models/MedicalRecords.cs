using System.Collections.Generic;

namespace NT.MedicusIntegration.Dll.models
{
    public class MedicalRecord
    {
        public int patient_number { get; set; }
        public int order_number { get; set; }
        public int registration_date { get; set; }
        public string registration_branch { get; set; }
        public List<Panel> panels{ get; set; }




    }
}