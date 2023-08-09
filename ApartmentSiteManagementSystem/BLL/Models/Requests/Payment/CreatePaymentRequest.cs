using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Requests.Payment
{
    public class CreatePaymentRequest
    {
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ValidDate { get; set; }
        public string InvoiceId { get; set; }
        public decimal Price { get; set; }
    }
}
