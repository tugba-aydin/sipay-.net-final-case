using AutoMapper;
using Payment.API.Entities;
using Payment.API.Models.Requests.Account;

namespace Payment.API.Helpers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<CreateAccountRequest, Account>().ReverseMap();
        }
    }
}
