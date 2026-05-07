namespace _08_Organic_DesignPatternsProject.Strategies
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
    }
}
