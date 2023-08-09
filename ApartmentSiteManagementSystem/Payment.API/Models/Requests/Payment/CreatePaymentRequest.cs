namespace Payment.API.Models.Requests.Payment
{
    public class CreatePaymentRequest
    {
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ValidDate { get; set; }
        public string InvoiceId { get; set; }
        public decimal Price { get; set; }
    }
}
