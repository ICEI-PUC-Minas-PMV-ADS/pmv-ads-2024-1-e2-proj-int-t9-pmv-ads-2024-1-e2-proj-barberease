using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Client
{
    public class ClientDtoCreate
    {
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail is in invalid format")]
        [StringLength(100, ErrorMessage = "E-mail must have {1} chars")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FirstName is require")]
        [StringLength(50, ErrorMessage = "FirstName must have {1} chars")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is require")]
        [StringLength(50, ErrorMessage = "LastName must have {1} chars")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "City is require")]
        [StringLength(50, ErrorMessage = "City must have {1} chars")]
        public string City { get; set; }


        [Required(ErrorMessage = "State is require")]
        [StringLength(50, ErrorMessage = "State must have {1} chars")]
        public string State { get; set; }

        [StringLength(50, ErrorMessage = "Phone must have {1} chars")]
        [Phone(ErrorMessage = "Phone is in invalid format")]
        public string? Phone { get; set; }
    }
}
