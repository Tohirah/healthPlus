using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthPlus.Application.Services
{
    public class JWTAuthentication : IJWTAuthentication
    {
        public IConfiguration Configuration { get; }
        public JWTAuthentication(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string GenerateToken(UserResponseModel model)
        {
            string key = Configuration["Jwt:Key"];
            string issuer = Configuration["Jwt:Issuer"];
            string audience = Configuration["Jwt:Audience"];
            double expiryMinutes = 60d;

            var claims = new List<Claim> (){
            new Claim(ClaimTypes.Name, $"{model.LastName} {model.FirstName}"),
            new Claim(ClaimTypes.NameIdentifier, model.Id.ToString())
            
            };
            foreach (var role in model.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
                expires: DateTime.Now.AddMinutes(expiryMinutes), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}