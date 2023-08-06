using BLL.Models.Requests.Apartment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators.Apartment
{
    public class CreateApartmentRequestValidator:AbstractValidator<CreateApartmentRequest>
    {
        public CreateApartmentRequestValidator()
        {
            RuleFor(request=>request.State).NotEmpty().NotNull();
            RuleFor(request=>request.FloorLocation).NotEmpty().NotNull();
            RuleFor(request=>request.ApartmentNumber).NotEmpty().NotNull();
            RuleFor(request=>request.Block).NotEmpty().NotNull();
            RuleFor(request => request.Type).NotEmpty().NotNull();
        }
    }
}
