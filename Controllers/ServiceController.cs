using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpPost]
        public IActionResult CreateService([FromBody] CreateServiceRequestModel request)
        {
            var response = _serviceService.CreateService(request);

            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
