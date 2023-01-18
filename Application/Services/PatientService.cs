using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository _repository;

        public PatientService(IRepository repository) 
        {
            _repository = repository;
        }
        public BaseResponse CreatePatient(CreatePatientRequestModel request)
        {
            var salt = Guid.NewGuid().ToString();

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Address = request.Address,
                UserName = request.Email,
                Salt = salt
            };
            user.Password =$"{request.Password} {salt}";

            _repository.Add(user);

            var patient = new Patient
            {
                Allergies = request.Allergies,
                BloodGroup = request.BloodGroup,
                Genotype = request.Genotype,
                EmergencyContact = request.EmergencyContact,
                PatientNumber = $"PA{Guid.NewGuid().ToString().Substring(0, 4).Replace("-", "")}",
                DateOfBirth = request.DateOfBirth,
                UserId = user.Id,
                User = user,
            };

            _repository.Add<Patient>(patient);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Profile Successfully Created",
                Status = true
            };
        }

        public BaseResponse UpdatePatient()
        {
            throw new NotImplementedException();
        }
    }
}
