using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Appointment
{
    public class AppointmentUpdateDto
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(10, ErrorMessage = "Status must have {1} chars")]
        public string Status { get; set; }

        [Required(ErrorMessage = "EstablishmentServiceId is required")]
        public Guid EstablishmentServiceId { get; set; }
    }
}
