using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] CreatePatientRequestModel request)
        {
            var response = _patientService.CreatePatient(request);

            return response.Status?Ok(response) : BadRequest(response);
        }


        [HttpGet("{id}")]
        public IActionResult getpatientbyid([FromQuery] int id)
        {
            var response = _patientService.GetPatientbyId(id);

            return (response != null) ? ok(response) : NotFound(response);
        }

        //[HttpPost]
        //public IActionResult GetPatients()
        //{
        //    var response = _patientService.GetPatients();

        //    return (response != null) ? Ok(response) : BadRequest(response);
        //}
    }
}
