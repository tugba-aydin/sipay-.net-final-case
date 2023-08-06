using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Account
    {
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ValidDate { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
