using BLL.Models.Requests.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators.User
{
    public class CreateUserRequestValidator:AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator() {
            RuleFor(request => request.Username).NotEmpty();
            RuleFor(request => request.Phone).NotEmpty().NotNull();
            RuleFor(request => request.Email).NotEmpty().NotNull();
            RuleFor(request => request.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(request => request.Surname).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(request => request.IdentityNumber).NotEmpty().NotNull().Length(11);
            RuleFor(request => request.Role).NotEmpty().NotNull();
        }
    }
}
