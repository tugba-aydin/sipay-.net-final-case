using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Requests.Invoice
{
    public class UpdateInvoiceRequest
    {
        public string Id { get; set; }
        public decimal? Price { get; set; }
        public string? UserId { get; set; }
        public string? ApartmentId { get; set; }
        public bool? IsPaid { get; set; }
    }
}
