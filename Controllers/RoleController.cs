using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }

        [HttpPost]
        public IActionResult CreateRole([FromBody] CreateRoleRequestModel request)
        {
            var response = _roleService.CreateRole(request);
            
            return response.Status? Ok(response) : BadRequest(response);
        }
    }
}
