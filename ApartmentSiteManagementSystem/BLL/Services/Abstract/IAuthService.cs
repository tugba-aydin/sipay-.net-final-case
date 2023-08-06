using BLL.Models.Requests.Auth;
using BLL.Models.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IAuthService
    {
        Task<(int, string)> Register(CreateUserRequest model);
        Task<(int, string)> Login(LoginRequest model);
    }
}
