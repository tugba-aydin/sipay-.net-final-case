using BLL.Models.Requests.Payment;
using BLL.Services.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService paymentService;
        public PaymentController(IPaymentService _paymentService)
        {
            paymentService = _paymentService;
        }
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var result = paymentService.GetAllPayments();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Pay(CreatePaymentRequest request)
        {
            paymentService.Pay(request);
            return Ok();
        }
    }
}
