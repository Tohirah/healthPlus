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

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {
            var response = _doctorService.GetDoctorById(id);
            return response.Status? Ok(response): NotFound(response.Message);
        }

        [HttpGet("{doctorNumber}")]
        public IActionResult GetDoctorByDoctorNumber(string doctorNumber)
        {
            var response = _doctorService.GetDoctorByDoctorNumber(doctorNumber);
            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        ////public IActionResult GetDoctors()
        ////{
        ////    var response =_doctorService.GetDoctors();
        ////    return (response != null) ? Ok(response) : BadRequest();
        ////}
    }
}
