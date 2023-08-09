using BLL.Models.Requests;
using BLL.Models.Requests.User;
using BLL.Models.Responses.User;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IUserService
    {
        List<UserResponse> GetAllUsers();
        UserResponse GetUserDetail(string identityNumber);
        Task AddUser(CreateUserRequest user);
        void DeleteUser(string identityNumber);
        void UpdateUser(UpdateUserRequest user);
    }
}
