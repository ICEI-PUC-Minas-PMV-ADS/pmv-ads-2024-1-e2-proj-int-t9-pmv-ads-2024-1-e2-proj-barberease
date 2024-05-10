using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Establishment
{
    public class EstablishmentDtoUpdate
    {
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail is in invalid format")]
        [StringLength(100, ErrorMessage = "E-mail must have {1} chars")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "CompanyName is require")]
        [StringLength(100, ErrorMessage = "CompanyName must have {1} chars")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Cnpj is require")]
        [StringLength(14, ErrorMessage = "Cnpj must have {1} chars")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "OwnerFirstName is require")]
        [StringLength(50, ErrorMessage = "OwnerFirstName must have {1} chars")]
        public string OwnerFirstName { get; set; }

        [Required(ErrorMessage = "OwnerLastName is require")]
        [StringLength(50, ErrorMessage = "OwnerLastName must have {1} chars")]
        public string OwnerLastName { get; set; }

        [Required(ErrorMessage = "City is require")]
        [StringLength(50, ErrorMessage = "City must have {1} chars")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is require")]
        [StringLength(50, ErrorMessage = "State must have {1} chars")]
        public string State { get; set; }

        [Required(ErrorMessage = "Cep is require")]
        [StringLength(8, ErrorMessage = "Cep must have {1} chars")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Address is require")]
        [StringLength(100, ErrorMessage = "Address must have {1} chars")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "Phone must have {1} chars")]
        [Phone(ErrorMessage = "Phone is in invalid format")]
        public string? Phone { get; set; }
    }
}
