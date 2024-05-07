using Microsoft.AspNetCore.Mvc;

namespace BarberEaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var someNumbers = Enumerable.Range(1, 5).ToList();

            return Ok(someNumbers);
        }
    }
}
