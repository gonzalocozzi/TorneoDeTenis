using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TorneoDeTenis.DTO;
using TorneoDeTenis.Services;

namespace TorneoDeTenis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TorneoController(ITorneoService torneoService) : ControllerBase
    {
        private readonly ITorneoService _torneoService = torneoService;

        [HttpPost("CrearTorneo")]
        public ActionResult CrearTorneo([FromBody] TorneoRequest torneoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var torneo = _torneoService.CrearTorneo(torneoRequest);
                var jsonString = JsonConvert.SerializeObject(torneo);

                return Content(jsonString, "application/json");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}