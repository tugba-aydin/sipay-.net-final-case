namespace Payment.API.Models.Requests.Account
{
    public class UpdateAccountRequest
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
    }
}
