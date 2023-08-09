using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Payment
    {
        public string Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public decimal Price { get; set; }
    }
}
