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
            var hospitalService = _repository.Get<HospitalService>(x => x.ServiceName == "Consultation");
            var appointment = new Appointment
            {
                // PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                AppointmentDate = request.AppointmentDate,
                Reason = request.Reason,
                Cost = hospitalService.Price
            };

            if(request.DoctorId > 0)
            {
                appointment.IsAssigned= true;
            }
            else
            {
                appointment.IsAssigned = false;
            }

            _repository.Add<Appointment>(appointment);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment booked successfully",
                Status = true
            };
        }

        public BaseResponse UpdateAppointment(int id, UpdateAppointmentRequestModel request)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.AppointmentDate = request.AppointmentDate;
            appointment.DoctorId = request.DoctorId;
            appointment.IsAssigned = request.IsAssigned;

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
            if(appointment.AppointmentStatus == (AppointmentStatus) 1)
            {
                appointment.AppointmentStatus = (AppointmentStatus)5;
            }
            else
            {

                return new BaseResponse
                {
                    Message = "Appointment cancellation is waiting for approval",
                    Status = true
                };
            }

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

        public BaseResponse PayForAppointment(int id)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.IsPaid = true;

            _repository.Update(appointment);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment updated successfully",
                Status = true
            };
        }

        public BaseResponse AssignAppointmentToDoctor(int id, UpdateAppointmentRequestModel request)
        {
            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.DoctorId = request.DoctorId;
            appointment.IsAssigned = true;

            _repository.Update(appointment);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment updated successfully",
                Status = true
            };
        }

        public BaseResponse FulfillAppointment(int id)
        {

            var appointment = _repository.Get<Appointment>(x => x.Id == id);
            appointment.AppointmentStatus = (AppointmentStatus)4;

            _repository.Update(appointment);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Appointment updated successfully",
                Status = true
            };
        }

        public IList<AppointmentResponseModel> GetAppointments()
        {
            var appointments = _repository.GetAll<Appointment>().ToList();

            var appointmentResponse = appointments.Select(x => new AppointmentResponseModel
            {
                Id= x.Id,
                AppointmentDate = x.AppointmentDate,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                Reason = x.Reason,
                IsAssigned = x.IsAssigned,
                IsPaid = x.IsPaid,
                AppointmentStatus = x.AppointmentStatus,
                Cost = x.Cost
            }).ToList();

            return appointmentResponse;
        }
    }
}
