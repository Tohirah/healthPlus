using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateRole([FromBody] CreateRoleRequestModel request)
        {
            var response = _userService.CreateRole(request);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById([FromQuery] int id)
        {
            var response = _userService.GetRoleById(id);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpGet("{name}")]
        public IActionResult GetRoleByName([FromQuery] string name)
        {
            var response = _userService.GetRoleByName(name);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }


        [HttpGet]
        public IActionResult GetRoles()
        {
            var response = _userService.GetRoles();

            return (response != null) ? Ok(response) : BadRequest(response);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetUserById([FromQuery] int id)
        //{
        //    var response = _userService.GetUserById(id);

        //    return response.Status ? Ok(response) : NotFound(response.Message);
        //}


        //[HttpGet("{name}")]
        //public IActionResult GetUserByName([FromQuery] string name)
        //{
        //    var response = _userService.GetUserByUsername(name);

        //    return response.Status ? Ok(response) : NotFound(response.Message);
        //}

        //[HttpGet]
        //public IActionResult GetUsers()
        //{
        //    var response = _userService.GetUsers();

        //    return (response != null) ? Ok(response) : BadRequest(response);
        //}
    }
}
