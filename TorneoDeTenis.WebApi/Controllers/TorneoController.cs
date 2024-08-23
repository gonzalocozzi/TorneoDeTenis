using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TorneoDeTenis.WebApi.DTO;
using TorneoDeTenis.WebApi.Services;

namespace TorneoDeTenis.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TorneoController(ITorneoService torneoService) : ControllerBase
    {
        private readonly ITorneoService _torneoService = torneoService;

        [HttpPost("ObtenerTorneo")]
        public async Task<ActionResult> ObtenerTorneo([FromBody] TorneoRequest torneoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var torneo = await _torneoService.CrearTorneo(torneoRequest);
                var jsonString = JsonConvert.SerializeObject(torneo);

                return Content(jsonString, "application/json");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("ObtenerGanador")]
        public async Task<ActionResult> ObtenerGanador([FromBody] TorneoRequest torneoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var torneo = await _torneoService.CrearTorneo(torneoRequest);
                return Ok(torneo.Ganador);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}