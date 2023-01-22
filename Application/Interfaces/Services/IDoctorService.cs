﻿using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IDoctorService
    {
        BaseResponse CreateDoctor(CreateDoctorRequestModel request);
        public DoctorResponseModel GetDoctorById(int id);
        public DoctorResponseModel GetDoctorByDoctorNumber(string doctorNumber);
        //public IList<DoctorResponseModel> GetDoctors()


    }
}
