using HealthPlus.Domain.Enums;

namespace HealthPlus.Domain.Entities
{
    public class Patient
    {

        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public string Allergies { get; set; }
        public string EmergencyContact { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
