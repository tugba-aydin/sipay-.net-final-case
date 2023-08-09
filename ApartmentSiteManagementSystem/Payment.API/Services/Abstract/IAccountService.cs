using Payment.API.Entities;
using Payment.API.Models.Requests.Account;

namespace Payment.API.Services.Abstract
{
    public interface IAccountService
    {
        List<Account> GetAllAccounts();
        string AddAccount(CreateAccountRequest request);
        void UpdateAccount(UpdateAccountRequest request);
    }
}
