using BLL.Models.Requests.Payment;
using BLL.Services.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Pay([FromBody]CreatePaymentRequest request)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            paymentService.Pay(request,role);
            return Ok();
        }
    }
}
