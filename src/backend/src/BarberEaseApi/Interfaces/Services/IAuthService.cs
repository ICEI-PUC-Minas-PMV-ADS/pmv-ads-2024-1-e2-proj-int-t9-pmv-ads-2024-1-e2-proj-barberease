using BarberEaseApi.Dtos.Login;

namespace BarberEaseApi.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginDtoResult> Login(LoginDto loginDto);
    }
}
