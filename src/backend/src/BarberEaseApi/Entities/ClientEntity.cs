using System.Security.Cryptography;
using System.Text;

namespace BarberEaseApi.Entities
{
    public class ClientEntity : BaseEntity
    {
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Phone { get; set; }

        public IEnumerable<AppointmentEntity> Appointments { get; set; }

        public void SetPassword(string password)
        {
            // This simulates hashing password, but sha256 is a easy to break
            // hash, this should to be changed to bcypt or similar.
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            HashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
