using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Appointment
{
    public class AppointmentCreateDto
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, ErrorMessage = "Status must have {1} chars")]
        public string Status { get; set; } // CANCELLED CONFIRMED RECEIVED

        [Required(ErrorMessage = "ClientId is required")]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "EstablishmentServiceId is required")]
        public Guid EstablishmentServiceId { get; set; }
    }
}
