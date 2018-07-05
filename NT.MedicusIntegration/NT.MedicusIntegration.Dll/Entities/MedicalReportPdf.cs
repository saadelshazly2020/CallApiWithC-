namespace NT.Integration.Medicus.Entities
{
    internal class MedicalReportPdf
    {
        public int patient_number { get; set; }
        public int order_number { get; set; }
        public string service_name { get; set; }
        public string base64 { get; set; }
    }
}