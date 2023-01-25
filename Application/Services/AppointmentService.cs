using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;
using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository _repository;

        public AppointmentService(IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse BookAppointment(CreateAppointmentRequestModel request)
        {
            //var cost = _repository.Get<Service>(x => x.Id == id);
            var appointment = new Appointment
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                AppointmentDate = request.AppointmentDate,
                Reason = request.Reason
            };

            if(request.DoctorId < 1)
            {
                appointment.IsAssigned= false;
            }
            else
            {
                appointment.IsAssigned = true;
            }

            _repository.Add<Appointment>(appointment);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment booked successfully",
                Status = true
            };
        }

        public BaseResponse UpdateAppointmentStatus(int id, AppointmentStatus appointmentStatus)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.AppointmentStatus = appointmentStatus;

            var appointmentUpdate =  _repository.Update<Appointment>(appointment);
            _repository.SaveChanges();
            if(appointmentUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Appoinment Status not updated",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Appointment Aprroved",
                Status = true
            };
        }
        public BaseResponse ApproveAppointment(int id)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.AppointmentStatus = (AppointmentStatus)2;

            var appointmentUpdate = _repository.Update<Appointment>(appointment);
            _repository.SaveChanges();

            if (appointmentUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Appoinment Status not updated",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Appointment Aprroved",
                Status = true
            };
        }

        public BaseResponse CancelAppointment(int id)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.AppointmentStatus = (AppointmentStatus)5;

            var appointmentUpdate = _repository.Update<Appointment>(appointment);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment Cancelled",
                Status = true
            };
        }


        public BaseResponse RejectAppointment(int id)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.AppointmentStatus = (AppointmentStatus)3;

            var appointmentUpdate = _repository.Update<Appointment>(appointment);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment Rejected",
                Status = true
            };
        }
        public AppointmentResponseModel GetAppointmentById(int id)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);


            return new AppointmentResponseModel
            {
                AppointmentDate = appointment.AppointmentDate,
                AppointmentStatus = appointment.AppointmentStatus,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                IsAssigned = appointment.IsAssigned,
                IsPaid = appointment.IsPaid,
                Cost = appointment.Cost,
                Reason = appointment.Reason,
                Status = true
            };
        }
    }
}
