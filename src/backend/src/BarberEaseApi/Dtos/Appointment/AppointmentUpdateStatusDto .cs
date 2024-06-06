using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Appointment
{
    public class AppointmentUpdateStatusDto
    {
        [Required(ErrorMessage = "Status is required")]
        [StringLength(10, ErrorMessage = "Status must have {1} chars")]
        public string Status { get; set; }
    }
}
