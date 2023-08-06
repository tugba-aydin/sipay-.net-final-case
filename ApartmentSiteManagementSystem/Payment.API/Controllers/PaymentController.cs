using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Abstract;
using BLL.Models.Requests.Payment;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController()
        {
            
        }
        [HttpPost]
        public bool PayInvoice()
        {
            return true;
        }
    }
}
