namespace NT.Integration.Medicus.Domain
{
    public class Biomarker
    {
        public string biomarker_abbreviation { get; set; }
        public int biomarker_value { get; set; }
        public string biomarker_unit { get; set; }
        public string reference_range { get; set; }
        public int result_date { get; set; }
        public string method { get; set; }
        public string biomarker_comment { get; set; }



    }
}