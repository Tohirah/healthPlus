using HealthPlus.Domain.Enum;

namespace HealthPlus.Application.DTOs
{
    public class DoctorResponseModel : BaseResponse
    {
         public string DoctorNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    
    }
}
