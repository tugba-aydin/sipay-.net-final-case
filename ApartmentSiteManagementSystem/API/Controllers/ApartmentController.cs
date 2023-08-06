using AutoMapper;
using BLL.Models.Requests.Apartment;
using BLL.Models.Responses.Apartment;
using BLL.Services.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService apartmentService;
        private readonly IMapper mapper;
        public ApartmentController(IApartmentService _apartmentService,IMapper _mapper)
        {
            apartmentService = _apartmentService;
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult GetAllApartments() { 
            var result = apartmentService.GetAllApartments();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetApartmentDetail(string id) { 
            apartmentService.GetApartmentDetail(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddApartment([FromBody] CreateApartmentRequest apartment)
        {
            apartmentService.AddApartment(apartment);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateApartment([FromBody] UpdateApartmentRequest apartment)
        {
            apartmentService.UpdateApartment(apartment);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteApartment(string id)
        {
            apartmentService.DeleteApartment(id);
            return Ok();
        }
    }
}
