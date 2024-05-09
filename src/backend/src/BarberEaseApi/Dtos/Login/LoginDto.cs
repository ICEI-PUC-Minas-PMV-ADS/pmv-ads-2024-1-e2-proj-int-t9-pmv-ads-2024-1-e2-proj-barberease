using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Login

{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail is in invalid format")]
        [StringLength(100, ErrorMessage = "E-mail must have {1} chars")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "UserType is required")]
        public string UserType { get; set; }
    }
}
