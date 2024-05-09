using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Client
{
    public class ClientDtoUpdate
    {
        [EmailAddress(ErrorMessage = "E-mail is in invalid format")]
        [StringLength(100, ErrorMessage = "E-mail must have {1} chars")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [StringLength(50, ErrorMessage = "FirstName must have {1} chars")]
        public string? FirstName { get; set; }

        [StringLength(50, ErrorMessage = "LastName must have {1} chars")]
        public string? LastName { get; set; }

        [StringLength(50, ErrorMessage = "City must have {1} chars")]
        public string? City { get; set; }

        [StringLength(50, ErrorMessage = "State must have {1} chars")]
        public string? State { get; set; }

        [StringLength(50, ErrorMessage = "Phone must have {1} chars")]
        [Phone(ErrorMessage = "Phone is in invalid format")]
        public string? Phone { get; set; }
    }
}
