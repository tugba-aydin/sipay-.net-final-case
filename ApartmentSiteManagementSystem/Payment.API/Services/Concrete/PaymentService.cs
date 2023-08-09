using Payment.API.Entities;
using Payment.API.Models.Requests.Account;
using Payment.API.Models.Requests.Payment;
using Payment.API.Repository;
using Payment.API.Services.Abstract;

namespace Payment.API.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService accountService;
        public PaymentService(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public bool Pay(CreatePaymentRequest request)
        {
            if (request != null)
            {
                string id;
                var oldAccount = accountService.GetAllAccounts().Where(data=>data.CardNumber == request.CardNumber).FirstOrDefault();
                if(oldAccount != null) {
                    id= oldAccount.Id;
                }
                else
                {
                    Random random = new Random();
                    CreateAccountRequest account = new CreateAccountRequest()
                    {
                        CardNumber = request.CardNumber,
                        ValidDate = request.ValidDate,
                        Cvv = request.Cvv,
                        Balance = random.Next(1, 10000)
                    }; 
                    id=accountService.AddAccount(account);
                }

                bool result = IsCreditCard(request.CardNumber);
                if (result)
                {
                    UpdateAccountRequest updateAccount = new UpdateAccountRequest();
                    updateAccount.Balance -= request.Price;
                    updateAccount.Id = id;
                    return true;
                }
                return false;
            }
            return false;
        }
        public static bool IsCreditCard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }

            int sumOfDigits = cardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);


            return sumOfDigits % 10 == 0;
        }
    }
}
