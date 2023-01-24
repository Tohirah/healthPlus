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

            return response.Status ? Ok(response) : BadRequest(response);
        }


        [HttpGet("{id}")]
        public IActionResult getpatientbyid([FromQuery] int id)
        {
            var response = _patientService.GetPatientById(id);

            return (response != null) ? Ok(response) : NotFound(response);
        }

        [HttpGet("{patientNumber}")]
        public IActionResult GetPatientByPatientNumber([FromQuery] string patientNumber)
        {
            var response = _patientService.GetPatientByPatientNumber(patientNumber);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var response = _patientService.GetPatients();

            return Ok(response);
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePatient([FromRoute] int id,  UpdatePatientRequestModel request)
        {
            var response = _patientService.UpdatePatient(id, request);
            return response.Status ? Ok(request) : BadRequest(response);
        }
    }
}
