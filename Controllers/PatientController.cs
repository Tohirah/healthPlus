using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("createPatient")]
        public IActionResult CreatePatient([FromBody] CreatePatientRequestModel request)
        {
            var response = _patientService.CreatePatient(request);

            return response.Status ? Ok(response) : BadRequest(response);
        }


        [HttpGet("getpatientbyid/id")]
        public IActionResult Getpatientbyid([FromQuery] int id)
        {
            var response = _patientService.GetPatientById(id);

            return (response != null) ? Ok(response) : NotFound(response);
        }

        [HttpGet("getPatientByPatientNumber/patientNumber")]
        public IActionResult GetPatientByPatientNumber([FromQuery] string patientNumber)
        {
            var response = _patientService.GetPatientByPatientNumber(patientNumber);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpGet("getPatients")]
        public IActionResult GetPatients()
        {
            var response = _patientService.GetPatients();

            return Ok(response);
        }


        [HttpPut("updatePatient")]
        public IActionResult UpdatePatient(UpdatePatientRequestModel request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var response = _patientService.UpdatePatient(int.Parse(userId), request);
            return response.Status ? Ok(request) : BadRequest(response);
        }
    }
}
