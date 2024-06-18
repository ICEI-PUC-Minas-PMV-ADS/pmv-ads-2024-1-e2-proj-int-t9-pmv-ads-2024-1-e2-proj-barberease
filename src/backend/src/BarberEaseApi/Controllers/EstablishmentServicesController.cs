using System.Net;
using BarberEaseApi.Dtos.EstablishmentService;
using BarberEaseApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberEaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentServicesController : ControllerBase
    {
        private readonly IEstablishmentServiceService _service;

        public EstablishmentServicesController(IEstablishmentServiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EstablishmentServiceCreateDto establishmentService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Create(establishmentService);
                if (result == null)
                {
                    return Conflict();
                }
                var link = Url.Link("GetServiceById", new { id = result.Id });
                var createdUri = link != null ? new Uri(link) : null;
                return Created(createdUri, result);
            }
            catch (ArgumentException exc)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException exc)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }

        [HttpGet("{establishmentId:guid}/establishment")]
        public async Task<ActionResult> GetByEstablishmentId(Guid establishmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetByEstablishmentId(establishmentId));
            }
            catch (ArgumentException exc)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }

        [HttpGet("{id:guid}", Name = "GetServiceById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException exc)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put([FromBody] EstablishmentServiceUpdateDto establishmentService, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Update(establishmentService, id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException exc)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Delete(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (ArgumentException exc)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }
    }
}
