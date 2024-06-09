using BarberEaseApi.Dtos.Client;
using BarberEaseApi.Dtos.EstablishmentService;

namespace BarberEaseApi.Dtos.Appointment
{
    public class AppointmentDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public ClientDto Client { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EstablishmentServiceDto EstablishmentService { get; set; }
    }
}
