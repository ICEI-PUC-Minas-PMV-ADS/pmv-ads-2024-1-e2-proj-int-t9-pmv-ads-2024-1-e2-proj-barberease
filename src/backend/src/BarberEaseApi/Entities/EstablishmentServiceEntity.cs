namespace BarberEaseApi.Entities
{
    public class EstablishmentServiceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid EstablishmentId { get; set; }

        public EstablishmentEntity Establishment { get; set; }
        public IEnumerable<AppointmentEntity> Appointments { get; set; }
    }
}
