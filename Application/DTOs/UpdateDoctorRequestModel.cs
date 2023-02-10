﻿using HealthPlus.Domain.Enum;

namespace HealthPlus.Application.DTOs
{
    public class UpdateDoctorRequestModel
    {
        public string PhoneNumber { get; set; }
        public string ProfileImage { get; set; }
        public string Address { get; set; }
    }
}
