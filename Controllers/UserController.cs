using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthentication _auth;

        public UserController(IUserService userService, IJWTAuthentication auth)
        {
            _userService = userService;
            _auth = auth;
        }

        [HttpPost]
        public IActionResult CreateRole([FromBody] CreateRoleRequestModel request)
        {
            var response = _userService.CreateRole(request);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("roleId")]
        public IActionResult GetRoleById([FromQuery] int roleId)
        {
            var response = _userService.GetRoleById(roleId);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpGet("RoleName")]
        public IActionResult GetRoleByName([FromQuery] string RoleName)
        {
            var response = _userService.GetRoleByName(RoleName);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }


        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var response = _userService.GetRoles();

            return (response != null) ? Ok(response) : BadRequest(response);
        }

        [HttpGet("UserId")]
        public IActionResult GetUserById([FromQuery] int UserId)
        {
            var response = _userService.GetUserById(UserId);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }


        [HttpGet("email")]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {
            var response = _userService.GetUserByUsername(email);

            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            var response = _userService.GetUsers();

            return Ok(response);
        }

        [HttpGet("Login/{email}")]
        public IActionResult Login([FromRoute] LoginRequestModel request)
        {
            var login = _userService.Login(request.Email, request.Password);

              if (!login.Status)
               {
                   return BadRequest(login);
               }
               var token = _auth.GenerateToken(login);
               var response = new LoginResponseModel
               {
                   Data = login,
                   Token = token
               };
               return Ok(response);
        }
    }
}
