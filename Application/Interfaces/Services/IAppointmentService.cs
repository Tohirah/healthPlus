using HealthPlus.Application.DTOs;
using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        BaseResponse BookAppointment(CreateAppointmentRequestModel request);
        public BaseResponse UpdateAppointmentStatus(int id, AppointmentStatus appointmentStatus);
        BaseResponse ApproveAppointment(int id);
        BaseResponse RejectAppointment(int id);
        BaseResponse CancelAppointment(int id);
        AppointmentResponseModel GetAppointmentById(int id);
        BaseResponse PayForAppointment (int id, bool ispaid);
        BaseResponse AssignAppointmentToDoctor(UpdateAppointmentRequestModel updateAppointmentRequestModel);
        BaseResponse FulfillAppointment(int id);

    }
}
