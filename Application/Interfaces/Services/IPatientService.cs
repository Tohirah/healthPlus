using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IPatientService
    {
        BaseResponse CreatePatient(CreatePatientRequestModel request);
        BaseResponse UpdatePatient(UpdatePatientRequestModel request);
        public PatientResponseModel GetPatientById(int id);
        public PatientResponseModel GetPatientByPatientNumber(string patientNumber);
        //public IList<PatientResponseModel> GetPatients();
    }
}
