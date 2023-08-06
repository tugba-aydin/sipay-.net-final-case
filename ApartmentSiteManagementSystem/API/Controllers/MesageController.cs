using BLL.Models.Requests.Apartment;
using BLL.Models.Requests.Message;
using BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesageController : ControllerBase
    {
        private readonly IMessageService messageService;
        public MesageController(IMessageService _messageService)
        {
            messageService = _messageService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllMessages()
        {
            var result=messageService.GetAllMessages();
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetMessageDetail(string id)
        {
            var reult=messageService.GetMessageDetail(id);
            return Ok(reult);
        }
        [Authorize(Roles ="User")]
        [HttpPost]
        public IActionResult AddMessage([FromBody] CreateMessageRequest messageRequest)
        {
            messageService.SendMessage(messageRequest);
            return Ok();
        }
    }
}
