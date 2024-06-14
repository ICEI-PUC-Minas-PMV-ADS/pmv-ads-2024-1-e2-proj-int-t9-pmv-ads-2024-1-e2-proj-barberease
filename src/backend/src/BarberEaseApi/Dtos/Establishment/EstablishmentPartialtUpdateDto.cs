using System.ComponentModel.DataAnnotations;

namespace BarberEaseApi.Dtos.Establishment
{
    public class EstablishmentPartialtUpdateDto
    {
        [EmailAddress(ErrorMessage = "E-mail is in invalid format")]
        [StringLength(100, ErrorMessage = "E-mail must have {1} chars")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [StringLength(100, ErrorMessage = "CompanyName must have {1} chars")]
        public string? CompanyName { get; set; }

        [StringLength(14, ErrorMessage = "Cnpj must have {1} chars")]
        public string? Cnpj { get; set; }

        [StringLength(50, ErrorMessage = "OwnerFirstName must have {1} chars")]
        public string? OwnerFirstName { get; set; }

        [StringLength(50, ErrorMessage = "OwnerLastName must have {1} chars")]
        public string? OwnerLastName { get; set; }

        [StringLength(50, ErrorMessage = "City must have {1} chars")]
        public string? City { get; set; }

        [StringLength(50, ErrorMessage = "State must have {1} chars")]
        public string? State { get; set; }

        [StringLength(8, ErrorMessage = "Cep must have {1} chars")]
        public string? Cep { get; set; }

        [StringLength(100, ErrorMessage = "Address must have {1} chars")]
        public string? Address { get; set; }

        [StringLength(50, ErrorMessage = "Phone must have {1} chars")]
        public string? Phone { get; set; }
    }
}
