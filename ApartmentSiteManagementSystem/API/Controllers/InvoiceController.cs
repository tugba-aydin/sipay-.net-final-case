using BLL.Models.Requests.Invoice;
using BLL.Services.Abstract;
using BLL.Services.Concrete;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApartmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        private readonly UserManager<User> userManager;
        private readonly IEnumerable<Claim> claims;

        public InvoiceController(IInvoiceService _invoiceService, UserManager<User> _userManager)
        {
               invoiceService = _invoiceService;
            userManager = _userManager;
            //this.claims = claims;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var result = invoiceService.GetAllInvoices();
            return Ok(result);
        }
        [Authorize(Roles = "User")]
        [Authorize]
        [HttpGet("Invoices/Detail")]
        public async Task<IActionResult> GetInvoicesDetail()
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result=invoiceService.GetDetailInvoices(userId, role);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetInvoiceDetail(string id)
        {
            invoiceService.GetInvoiceDetail(id);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("NotPaid")]
        public IActionResult GetNotPaidInvoices()
        {
            var result = invoiceService.GetAllNotPaidInvoices();
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddInvoice([FromBody] CreateInvoiceRequest invoice)
        {
            invoiceService.AddInvoice(invoice);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("/multiInvoices")]
        public IActionResult AddInvoices([FromBody] List<CreateInvoiceRequest> invoices)
        {
            invoiceService.AddInvoices(invoices);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateInvoice([FromBody] UpdateInvoiceRequest invoice)
        {
            invoiceService.UpdateInvoice(invoice);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteInvoice(string id)
        {
            invoiceService.DeleteInvoice(id);
            return Ok();
        }

    }
}
