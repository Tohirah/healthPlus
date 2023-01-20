using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository _doctorRepository;

        public DoctorService (IRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public BaseResponse CreateDoctor(CreateDoctorRequestModel request)
        {
            var salt = Guid.NewGuid().ToString();
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Gender = request.Gender,
                UserName = request.Email,
                Salt= salt
                
            };
            user.Password = $"{request.Password} {salt}";

            _doctorRepository.Add(user);

            var doctor = new Doctor
            {
                DoctorNumber = $"DR{Guid.NewGuid().ToString().Substring(4, 4).Replace("-", "")}",
                DateOfBirth= request.DateOfBirth,
                UserId = user.Id,
                User= user,
            };

            _doctorRepository.Add(doctor);
            _doctorRepository.SaveChanges();

            return new BaseResponse
            {
                Message = "Profile Created Successfully",
                Status = true
            };
        }
    }
}
