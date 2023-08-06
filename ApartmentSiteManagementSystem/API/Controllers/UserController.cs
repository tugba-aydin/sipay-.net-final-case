using BLL.Services.Abstract;
using BLL.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Entities;
using BLL.Models.Requests.User;
using BLL.Services.Concrete;
using BLL.Models.Requests.Invoice;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ApartmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
           var result= userService.GetAllUsers();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserDetail(string identityNumber)
        {
            userService.GetUserDetail(identityNumber);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]CreateUserRequest user)
        {
            if(user == null) { return BadRequest(); }
            await userService.AddUser(user);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest user)
        {
            userService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteUser(string identityNumber)
        {
            if(identityNumber == null)
            {
                return BadRequest();
            }
            userService.DeleteUser(identityNumber);
            return Ok();
        }
    }
}
