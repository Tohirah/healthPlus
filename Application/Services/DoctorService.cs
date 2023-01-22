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

        public DoctorResponseModel GetDoctorById(int id)
        {
            var doctor = _doctorRepository.Get<Doctor>(x => x.Id == id);
            var user = _doctorRepository.Get<User>(x => x.Id == id);

            if (doctor == null)
            {
                return new DoctorResponseModel
                {
                    Message = $"No record found for doctor with Id {id}",
                    Status = false
                };

            }
            return new DoctorResponseModel
            {
                FirstName = user.FirstName,
                DoctorNumber = doctor.DoctorNumber,
                LastName = user.LastName,
                Gender = user.Gender,
                Address = user.Address,
                DateOfBirth = doctor.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                Status = true
            };
        }

        public DoctorResponseModel GetDoctorByDoctorNumber (string doctorNumber)
        {
            var doctor = _doctorRepository.Get<Doctor>(x=> x.DoctorNumber == doctorNumber);
            var user = _doctorRepository.Get<User>(x => x.Id == doctor.Id);
            if(doctor == null)
            {
                return new DoctorResponseModel
                {
                    Message = $"No Record found with Doctor Number {doctorNumber}",
                    Status = false
                };
            }

            return new DoctorResponseModel
            {
                DoctorNumber = doctor.DoctorNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                Email = user.Email,
                DateOfBirth = doctor.DateOfBirth,
                Status = true
            };
        }


        // How to map responsemodel using both doctor and user entities
        //public IList<DoctorResponseModel> GetDoctors()
        //{
        //    var doctors = _doctorRepository.GetAll<Doctor>();
        //    var users = _doctorRepository.GetAll<User>();


        //    var doctorResponse= users.Select(x => new DoctorResponseModel
        //    {
        //        FirstName = x.FirstName,
        //        LastName = x.LastName,
        //        Gender = x.Gender,
        //        Address = x.Address,
        //        PhoneNumber = x.PhoneNumber,
        //        Password = x.Password,
        //        Email = x.Email,
        //    }).ToList();

        //    return doctorResponse;
        //}

    }
}
