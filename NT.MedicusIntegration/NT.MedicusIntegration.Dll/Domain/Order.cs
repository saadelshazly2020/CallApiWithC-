namespace NT.Integration.Medicus.Domain
{
    public class Order
    {
        public int patient_number { get; set; }
        public int order_number { get; set; }
        public string order_status { get; set; }

    }
}