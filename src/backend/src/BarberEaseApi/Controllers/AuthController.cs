using System.Net;
using BarberEaseApi.Dtos.Login;
using BarberEaseApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberEaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Login(login);
                return Ok(result);
            }
            catch (ArgumentException exc)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }
    }
}
