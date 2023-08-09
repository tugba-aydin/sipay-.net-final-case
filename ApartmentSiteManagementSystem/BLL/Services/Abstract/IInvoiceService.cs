using BLL.Models.Requests.Invoice;
using BLL.Models.Responses.Invoice;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IInvoiceService
    {
        List<InvoiceResponse> GetAllInvoices();
        InvoiceResponse GetInvoiceDetail(string id);
        void AddInvoice(CreateInvoiceRequest invoiceRequest);
        void AddInvoices(List<CreateInvoiceRequest> invoiceRequests);
        void DeleteInvoice(string id);
        void UpdateInvoice(UpdateInvoiceRequest invoinceRequest);
        List<InvoiceResponse> GetAllNotPaidInvoices();
        List<InvoiceResponse> GetDetailInvoices(string? userId, string role);
    }
}
