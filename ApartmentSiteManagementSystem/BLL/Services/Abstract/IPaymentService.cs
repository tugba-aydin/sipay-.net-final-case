using BLL.Models.Requests.Payment;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IPaymentService
    {
        List<Payment> GetAllPayments();
        Task Pay(CreatePaymentRequest request);
    }
}
