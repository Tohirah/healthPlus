using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class NurseService : INurseService
    {
        private readonly IRepository _repository;

        public NurseService (IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse CreateNurse(CreateNurseRequestModel request)
        {
            var nurse = new Nurse
            {
                NurseNumber = $"NR{Guid.NewGuid().ToString().Substring(0, 7)}",
                DateOfBirth = request.DateOfBirth,
                ProfileImage = request.ProfileImage
            };

            var salt = Guid.NewGuid().ToString();
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Password = $"{request.Password} {salt}",
                Gender = request.Gender,
                UserName = request.Email,
                Salt = salt
            };

            _repository.Add<Nurse>(nurse);
            _repository.Add<User>(user);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Nurse profile created successfully",
                Status = true
            };
        }

        public NurseResponseModel GetNurseById(int id)
        {
            throw new NotImplementedException();
        }

        public NurseResponseModel GetNurseByNurseNumber(string nurseNumber)
        {
            throw new NotImplementedException();
        }

        public IList<NurseResponseModel> GetNurses()
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateNurse(UpdateNurseRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
