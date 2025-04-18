using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimento.Data.DTO;
using TesteDesenvolvimento.Dominio.Dominio;
using TesteDesenvolvimento.Service.Service.Interface;

namespace TesteDesenvolvimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AltitudeController : ControllerBase
    {
        private readonly IAltitudeService _altitudeService;
        private readonly IMapper _mapper;

        public AltitudeController(IAltitudeService altitudeService, IMapper mapper)
        {
            _altitudeService = altitudeService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("adicionar", Name = "Adicionar")]
        public async Task<IActionResult> AdicionarAsync([FromBody] Altitude altitude)
        {
            if(altitude == null)
            {
                return BadRequest("Altitude não pdoe ser nulla.");
            }

            try
            {
                AltitudeDTO altitudeDTO = new AltitudeDTO();
                altitudeDTO.Latitude = altitude.Latitude;
                altitudeDTO.Longitude = altitude.Longitude;
                altitudeDTO.Radius = altitude.Radius;

                await _altitudeService.AdicionarAsync(altitude);
                return Ok("Altitude adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar a altitude: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar", Name = "ListarAtitudes")]
        public async Task<IActionResult> ListarAtitudes()
        {
            try
            {
                var altitudes = await _altitudeService.ListarAsync(); // ✅ await aqui!
                return Ok(altitudes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter altitudes: {ex.Message}");
            }
        }

    }
}
