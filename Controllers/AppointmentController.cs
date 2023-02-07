using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Application.Services;
using HealthPlus.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public IActionResult BookAppointment([FromBody] CreateAppointmentRequestModel request)
        {
            var response = _appointmentService.BookAppointment(request);

            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public IActionResult ApproveAppointment([FromRoute] int id)
        {
            var response = _appointmentService.ApproveAppointment(id);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpGet("id")]
        public IActionResult GetAppointmentById([FromQuery] int id)
        {
            var response = _appointmentService.GetAppointmentById(id);

            return (response != null) ? Ok(response) : NotFound(response);
        }

        [HttpPut("PayForApointment/{id}")]
       public IActionResult PayForApointment([FromRoute] int id)
        {
            var response = _appointmentService.PayForAppointment(id);

            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpPut("AssignAppointmentToDoctor/{id}")]
        public IActionResult AssignAppointmentToDoctor([FromQuery] int id, UpdateAppointmentRequestModel request)
        {
            var response = _appointmentService.AssignAppointmentToDoctor(id, request);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPut("FulfillAppointment/{id}")]
        public IActionResult FulfillAppointment([FromQuery] int id)
        {
            var response = _appointmentService.FulfillAppointment(id);

            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
