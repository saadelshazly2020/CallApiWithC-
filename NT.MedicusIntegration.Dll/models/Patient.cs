using System.Collections.Generic;

namespace NT.MedicusIntegration.Dll.models
{
    public class Patient
    {
        public Patient()
        {
            attributes = new List<Attribute>();
        }
        public string patient_number { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string birthdate { get; set; }
        public string branch_name { get; set; }
        
        public string phone_number { get; set; }
        public string email { get; set; }
        public List<Attribute> attributes { get; set; }
    }

    public class Attribute
    {
        public string attribute { get; set; }
        public string attribute_value { get; set; }
        public string entered_value_date { get; set; }
    }
}