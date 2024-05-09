using BarberEaseApi.Dtos.Login;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;

namespace BarberEaseApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientRepository _clientRepository;
        // private readonly IEstablishmentRepository _establishmentRepository;

        public AuthService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            // _establishmentRepository = establishmentRepository
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

                    if (!clientResult.VerifyPassword(loginDto.Password))
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

            result.Authenticated = false;
            result.Message = "Authentication failed";

            return result;
        }
    }
}
