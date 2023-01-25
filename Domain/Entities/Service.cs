namespace HealthPlus.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string ServiceName { get; set; }
        public decimal Cost { get; set; }
    }
}
