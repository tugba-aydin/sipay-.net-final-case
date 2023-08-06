﻿using BLL.Models.Requests.Invoice;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators.Invoice
{
    public class UpdateInvoiceRequestValidator:AbstractValidator<UpdateInvoiceRequest>
    {
        public UpdateInvoiceRequestValidator()
        {
            RuleFor(request=>request.Id).NotEmpty().NotNull();
            RuleFor(request => request.IsPaid).NotEmpty();
            RuleFor(request => request.UserId).NotEmpty();
            RuleFor(request => request.Price).NotEmpty().GreaterThan(0);
            RuleFor(request => request.ApartmentId).NotEmpty();
        }
    }
}