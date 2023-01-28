﻿namespace HealthPlus.Domain.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<Consultation> Consultations { get; set; }
        public Consultation Consultation{ get; set; }
    }
}
