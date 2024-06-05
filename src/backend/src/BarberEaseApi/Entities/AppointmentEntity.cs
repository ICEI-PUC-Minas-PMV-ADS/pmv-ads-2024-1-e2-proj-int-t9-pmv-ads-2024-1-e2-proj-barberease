namespace BarberEaseApi.Entities
{
    public class AppointmentEntity : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Guid ClientId { get; set; }
        public Guid EstablishmentServiceId { get; set; }

        public EstablishmentServiceEntity EstablishmentService { get; set; }
        public ClientEntity Client { get; set; }
    }
}
