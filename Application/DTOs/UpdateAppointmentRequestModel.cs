using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.DTOs
{
    public class UpdateAppointmentRequestModel
    {
        public int DoctorId { get; set; }
        public bool IsPaid { get; set; }
        public bool IsAssigned { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
    }
}
