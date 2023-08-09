using AutoMapper;
using Payment.API.Entities;
using Payment.API.Models.Requests.Account;
using Payment.API.Repository;
using Payment.API.Services.Abstract;

namespace Payment.API.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> repository;
        private readonly IMapper mapper;
        public AccountService(IRepository<Account> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public string AddAccount(CreateAccountRequest request)
        {
            if (request != null)
            {
                var result = mapper.Map<Account>(request);
                
                result.Id = Guid.NewGuid().ToString();
                repository.Add(result);
                return result.Id;
            }
            return "";
        }

        public List<Account> GetAllAccounts()
        {
            return repository.GetAll();
        }

        public void UpdateAccount(UpdateAccountRequest request)
        {
            if(request != null)
            {
                var result= mapper.Map<Account>(request);
                repository.Update(result);
            }
        }
    }
}
