using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Invoice
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string ApartmentId { get; set; }
        public bool IsPaid { get; set; }
        public string Type { get; set; }
        public string Period { get; set; }
        public User? User { get; set; }
        public Apartment? Apartment { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
