﻿namespace HealthPlus.Domain.Entities
{
    public class MedicalRecord : BaseEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<Consultation> Consultations { get; set; } = new HashSet<Consultation>();
    }
}
