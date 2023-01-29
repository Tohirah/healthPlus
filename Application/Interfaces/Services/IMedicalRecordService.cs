using HealthPlus.Application.DTOs;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IMedicalRecordService
    {
        BaseResponse CreateMedicalRecord(CreateMedicalRecordRequestModel request);
        BaseResponse UpdateMedicalRecord(int id, Consultation consultation);
        MedicalRecordResponseModel GetMedicalRecord(int id);
    }
}
