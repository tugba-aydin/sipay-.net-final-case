using Microsoft.EntityFrameworkCore;
using Payment.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.API.Data
{
    public class ApplicationPaymentDbContext:DbContext
    {
        public ApplicationPaymentDbContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
