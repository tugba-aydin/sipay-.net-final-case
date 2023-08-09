using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Models.Requests.Payment;
using Payment.API.Services.Abstract;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService _paymentService)
        {
            paymentService = _paymentService;

        }
        [HttpPost]
        public IActionResult PayInvoice([FromBody] CreatePaymentRequest request)
        {
            var result = paymentService.Pay(request);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
