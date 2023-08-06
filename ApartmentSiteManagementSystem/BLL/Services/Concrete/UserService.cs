using AutoMapper;
using BLL.Models.Requests;
using BLL.Models.Requests.User;
using BLL.Services.Abstract;
using BLL.Validators.User;
using DAL.Entities;
using DAL.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IAuthService authService;
        private readonly IMapper mapper;
        public UserService(IRepository<User> _repository, IAuthService _authService,IMapper _mapper)
        {
            repository = _repository;
            authService = _authService;
            mapper = _mapper;
        }
        public async Task AddUser(CreateUserRequest user)
        {
            if (user != null) 
            {
                CreateUserRequestValidator validator = new CreateUserRequestValidator();
                validator.ValidateAndThrow(user);
                await authService.Register(user);
            }
        }

        public void DeleteUser(string identityNumber)
        {
            if (identityNumber != null)
            {
                var model = GetAllUsers();
                var data=model.Where(user => user.IdentityNumber.ToString()==identityNumber).FirstOrDefault();
                repository.Delete(data.Id);
            }
        }

        public List<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        public User GetUserDetail(string identityNumber)
        {
            if(identityNumber !=null)
            {
                var model = GetAllUsers().Where(user => user.IdentityNumber.Equals(identityNumber)).FirstOrDefault();
                return repository.GetById(model.Id);
            }
            return null;
        }

        public void UpdateUser(UpdateUserRequest userRequest)
        {
            if(userRequest != null)
            {
                UpdateUserRequestValidator validations = new UpdateUserRequestValidator();
                validations.ValidateAndThrow(userRequest);
                var user=mapper.Map<User>(userRequest);
                repository.Update(user);
            }
        }
    }
}
