using AutoMapper;
using BLL.Models.Requests.Invoice;
using BLL.Models.Requests.Payment;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> repository;
        private readonly IMapper mapper;
        private readonly IInvoiceService invoiceService;
        private readonly IUserService userService;
        public PaymentService(IRepository<Payment> _repository, IMapper _mapper, IInvoiceService _invoiceService, IUserService _userService)
        {
            repository = _repository;
            mapper = _mapper;
            invoiceService = _invoiceService;
            userService = _userService;
        }
        public List<Payment> GetAllPayments()
        {
            return repository.GetAll();
        }

        public async Task Pay(CreatePaymentRequest request, string role)
        {
            var httpClient = new HttpClient();

            string body = JsonConvert.SerializeObject(request);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:7113/api/Payment", content).Result;

            if (result.IsSuccessStatusCode)
            {
                var model = mapper.Map<Payment>(request);
                model.Id = Guid.NewGuid().ToString();
                model.PaymentDate = DateTime.UtcNow;
                repository.Add(model);
                UpdateInvoiceRequest updateInvoice = new UpdateInvoiceRequest { Id = request.InvoiceId, IsPaid = true };
                invoiceService.UpdateInvoice(updateInvoice);
            }
        }
    }
}
