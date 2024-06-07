using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.EstablishmentPeriod
{
    public class EstablishmentPeriodCreateDto
    {
        [Required(ErrorMessage = "DayOfWeek is required")]
        [StringLength(20, ErrorMessage = "DayOfWeek must have {1} chars")]
        public string DayOfWeek { get; set; }

        [StringLength(8, ErrorMessage = "OpeningTime must have {1} chars")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$", ErrorMessage = "OpeningTime must be in the format HH:MM:SS")]
        public string? OpeningTime { get; set; }

        [StringLength(8, ErrorMessage = "ClosingTime must have {1} chars")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$", ErrorMessage = "ClosingTime must be in the format HH:MM:SS")]
        public string? ClosingTime { get; set; }

        [StringLength(8, ErrorMessage = "TimeBetweenService must have {1} chars")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$", ErrorMessage = "TimeBetweenService must be in the format HH:MM:SS")]
        public string? TimeBetweenService { get; set; }

        [Required(ErrorMessage = "IsClosed is required")]
        public bool IsClosed { get; set; }

        [Required(ErrorMessage = "EstablishmentId is required")]
        public Guid EstablishmentId { get; set; }
    }
}
