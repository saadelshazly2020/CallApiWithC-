using System.Collections.Generic;

namespace NT.Integration.Medicus.Domain
{
    public class MedicalReport
    {
        public int patient_number { get; set; }
        public int order_number { get; set; }
        public int registration_date { get; set; }
        public string registration_branch { get; set; }
        public List<Panel> panels{ get; set; }




    }
}