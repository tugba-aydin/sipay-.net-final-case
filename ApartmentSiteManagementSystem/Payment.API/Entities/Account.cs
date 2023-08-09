namespace Payment.API.Entities
{
    public class Account
    {
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ValidDate { get; set; }
        public decimal Balance { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
