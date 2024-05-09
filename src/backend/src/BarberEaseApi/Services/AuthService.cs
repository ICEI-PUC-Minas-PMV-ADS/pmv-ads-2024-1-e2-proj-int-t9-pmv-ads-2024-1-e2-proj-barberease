using System.Security.Cryptography;
using System.Text;
using BarberEaseApi.Dtos.Login;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IEstablishmentRepository _establishmentRepository;

        public AuthService(
            IClientRepository clientRepository,
            IEstablishmentRepository establishmentRepository)
        {
            _clientRepository = clientRepository;
            _establishmentRepository = establishmentRepository;
        }

        public async Task<LoginDtoResult> Login(LoginDto loginDto)
        {
            var result = new LoginDtoResult();
            if (loginDto == null)
            {
                result.Authenticated = false;
                result.Message = "Authentication failed";
                return result;
            }

            if (loginDto.UserType == "Client")
            {
                var clientResult = await _clientRepository.FindByEmail(loginDto.Email);
                if (clientResult == null)
                {
                    result.Authenticated = false;
                    result.Message = "Authentication failed";
                }
                else
                {

                    if (!VerifyPassword(loginDto.Password, clientResult.HashedPassword))
                    {
                        result.Authenticated = false;
                        result.Message = "Authentication failed";
                    }
                    else
                    {
                        result.UserType = "Client";
                        result.Authenticated = true;
                        result.Identifier = clientResult.Id;
                        result.Message = "Authenticated successfully";
                    }
                }
                return result;
            }

            if (loginDto.UserType == "Establishment")
            {
                var establishmentResult = await _establishmentRepository.FindByEmail(loginDto.Email);
                if (establishmentResult == null)
                {
                    result.Authenticated = false;
                    result.Message = "Authentication failed";
                }
                else
                {

                    if (!VerifyPassword(loginDto.Password, establishmentResult.HashedPassword))
                    {
                        result.Authenticated = false;
                        result.Message = "Authentication failed";
                    }
                    else
                    {
                        result.UserType = "Establishment";
                        result.Authenticated = true;
                        result.Identifier = establishmentResult.Id;
                        result.Message = "Authenticated successfully";
                    }
                }
                return result;
            }

            result.Authenticated = false;
            result.Message = "Authentication failed";

            return result;
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var newHashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return newHashedPassword == hashedPassword;
        }
    }
}
