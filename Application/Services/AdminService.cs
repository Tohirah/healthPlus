using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository _repository;

        public AdminService(IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse CreateAdmin(CreateAdminRequestModel request)
        {
            var salt = Guid.NewGuid().ToString();
            var adminNumber = Guid.NewGuid().ToString().Substring(5, 10).Replace("-", "");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                UserName = request.Email,
                Salt = salt,
                Password = $"{request.Password} {salt}",
            };
            _repository.Add<User>(user);

            var role = _repository.Get<Role>(x => x.Name == "Admin");
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Role not found",
                    Status = false
                };
            }
            else
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                };
                _repository.Add<UserRole>(userRole);
            }

            var admin = new Admin
            {
                AdminNumber = adminNumber,
                DateOfBirth = request.DateOfBirth,
                UserId = user.Id,
                User = user,
                ProfileImage = request.ProfileImage,
            };

            _repository.Add<Admin>(admin);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Admin profile created successfully",
                Status = true
            };
        }

        public AdminResponseModel GetAdminByAdminNumber(string adminNUmber)
        {
            throw new NotImplementedException();
        }

        public AdminResponseModel GetAdminById(int adminId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateAdmin(UpdateAdminRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
