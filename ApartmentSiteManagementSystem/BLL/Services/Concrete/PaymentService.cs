using AutoMapper;
using BLL.Models.Requests.Invoice;
using BLL.Models.Requests.Payment;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> repository;
        private readonly IMapper mapper;
        private readonly IInvoiceService invoiceService;
        public PaymentService(IRepository<Payment> _repository,IMapper _mapper, IInvoiceService _invoiceService)
        {
            repository = _repository;
            mapper = _mapper;
            invoiceService = _invoiceService;

        }
        public List<Payment> GetAllPayments()
        {
            return repository.GetAll();
        }

        public async Task Pay(CreatePaymentRequest request)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync("https://localhost:7113/api/Payment", null);
            var model= mapper.Map<Payment>(request);
            model.Id = Guid.NewGuid().ToString();
            model.PaymentDate = DateTime.UtcNow;
            model.Price = invoiceService.GetInvoiceDetail(request.InvoiceId).Price;
            repository.Add(model);
        }
    }
}
