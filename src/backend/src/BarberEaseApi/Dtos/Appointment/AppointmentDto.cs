namespace BarberEaseApi.Dtos.Appointment
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Guid ClientId { get; set; }
        public Guid EstablishmentServiceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
