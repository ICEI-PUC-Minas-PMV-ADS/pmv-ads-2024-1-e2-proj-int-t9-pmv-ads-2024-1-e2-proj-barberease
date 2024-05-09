namespace BarberEaseApi.Dtos.Login
{
    public class LoginDtoResult
    {
        public bool Authenticated { get; set; }
        public Guid? Identifier { get; set; }
        public string? UserType { get; set; }
        public string Message { get; set; }
    }
}
