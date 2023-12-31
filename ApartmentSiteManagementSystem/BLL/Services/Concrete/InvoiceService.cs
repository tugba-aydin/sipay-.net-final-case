﻿using AutoMapper;
using BLL.Models.Requests.Invoice;
using BLL.Models.Responses.Invoice;
using BLL.Services.Abstract;
using BLL.Validators.Invoice;
using DAL.Entities;
using DAL.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class InvoiceService:IInvoiceService
    {
        private readonly IRepository<Invoice> repository;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private IHttpContextAccessor httpContextAccessor;
        public InvoiceService(IRepository<Invoice> _repository,IMapper _mapper,UserManager<User> _userManager, IHttpContextAccessor httpContextAccessor)
        {
            repository= _repository;
            mapper= _mapper;
            userManager= _userManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void AddInvoice(CreateInvoiceRequest invoiceRequest)
        {
            if ( invoiceRequest!= null)
            {
                CreateInvoiceRequestValidator validator = new CreateInvoiceRequestValidator();
                validator.ValidateAndThrow(invoiceRequest);
                var invoice=mapper.Map<Invoice>(invoiceRequest);
                invoice.Id = Guid.NewGuid().ToString();
                invoice.CreatedAt = DateTime.UtcNow;
                invoice.UpdatedAt = DateTime.UtcNow;
                invoice.DueDate = DateTime.UtcNow.AddMonths(1);
                invoice.Period = "";
                repository.Add(invoice);
            }
        }

        public void AddInvoices(List<CreateInvoiceRequest> invoiceRequests)
        {
            foreach (var item in invoiceRequests)
            {
                CreateInvoiceRequestValidator validator = new CreateInvoiceRequestValidator();
                validator.ValidateAndThrow(item);
                var invoice = mapper.Map<Invoice>(item);
                invoice.Id = Guid.NewGuid().ToString();
                invoice.CreatedAt = DateTime.UtcNow;
                invoice.UpdatedAt = DateTime.UtcNow;
                invoice.DueDate = DateTime.UtcNow.AddMonths(1);
                invoice.Period = DateTime.UtcNow.Month.ToString()+"/"+DateTime.UtcNow.Year.ToString();
                repository.Add(invoice);
            }
        }

        public void DeleteInvoice(string id)
        {
            if (id != null)
            {
                repository.Delete(id);
            }
        }

        public List<InvoiceResponse> GetAllInvoices()
        {
            var invoices = repository.GetAll();
            return mapper.Map<List<InvoiceResponse>>(invoices);
        }

        public List<InvoiceResponse> GetAllNotPaidInvoices()
        {
            var invoices = repository.GetAll().Where(data => data.IsPaid == false).ToList();
            return mapper.Map<List<InvoiceResponse>>(invoices);
        }

        public List<InvoiceResponse> GetDetailInvoices(string? userId, string role)
        {
            if (role == "User")
            {
                var invoices = repository.GetAll().Where(data => data.UserId == userId).ToList();
                return mapper.Map<List<InvoiceResponse>>(invoices);
            }
            return null;
        }

        public InvoiceResponse GetInvoiceDetail(string id)
        {  
            if (id != null)
            {
                var invoice= repository.GetById(id);
                return mapper.Map<InvoiceResponse>(invoice);
            }
            else return null;
        }

        public void UpdateInvoice(UpdateInvoiceRequest invoiceRequest)
        {
            if (invoiceRequest != null)
            {
                UpdateInvoiceRequestValidator validations = new UpdateInvoiceRequestValidator();
                validations.ValidateAndThrow(invoiceRequest);
                var invoice = mapper.Map<Invoice>(invoiceRequest);
                invoice.UpdatedAt=DateTime.Now;
                repository.Update(invoice);
            }
        }
    }
}
