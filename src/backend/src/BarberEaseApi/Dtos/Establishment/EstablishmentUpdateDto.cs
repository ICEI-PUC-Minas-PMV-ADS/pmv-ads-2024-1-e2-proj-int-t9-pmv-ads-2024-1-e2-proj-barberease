using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Establishment
{
    public class EstablishmentUpdateDto
    {
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail is in invalid format")]
        [StringLength(100, ErrorMessage = "E-mail must have {1} chars")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "CompanyName is required")]
        [StringLength(100, ErrorMessage = "CompanyName must have {1} chars")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Cnpj is required")]
        [StringLength(14, ErrorMessage = "Cnpj must have {1} chars")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "OwnerFirstName is required")]
        [StringLength(50, ErrorMessage = "OwnerFirstName must have {1} chars")]
        public string OwnerFirstName { get; set; }

        [Required(ErrorMessage = "OwnerLastName is required")]
        [StringLength(50, ErrorMessage = "OwnerLastName must have {1} chars")]
        public string OwnerLastName { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City must have {1} chars")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State must have {1} chars")]
        public string State { get; set; }

        [Required(ErrorMessage = "Cep is required")]
        [StringLength(8, ErrorMessage = "Cep must have {1} chars")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must have {1} chars")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "Phone must have {1} chars")]
        public string? Phone { get; set; }
    }
}
