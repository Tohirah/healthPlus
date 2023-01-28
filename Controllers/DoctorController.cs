using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost]
        public IActionResult CreateDoctor([FromBody] CreateDoctorRequestModel request)
        {
            var response = _doctorService.CreateDoctor(request);
            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpGet("id")]
        public IActionResult GetDoctorById([FromQuery] int id)
        {
            var response = _doctorService.GetDoctorById(id);
            return response.Status? Ok(response): NotFound(response.Message);
        }

        [HttpGet("doctorNumber")]
        public IActionResult GetDoctorByDoctorNumber([FromQuery] string doctorNumber)
        {
            var response = _doctorService.GetDoctorByDoctorNumber(doctorNumber);
            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePassword([FromRoute] int id, UpdatePasswordRequestModel password)
        {
            var response = _doctorService.UpdatePassword(id, password);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var response = _doctorService.GetDoctors();
            return (response != null) ? Ok(response) : BadRequest();
        }
    }
}
