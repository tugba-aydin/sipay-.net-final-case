using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Responses.Invoice
{
    public class InvoiceResponse
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string ApartmentId { get; set; }
        public bool IsPaid { get; set; }
        public string Type { get; set; }
        public string Period { get; set; }
    }
}
