using Cinema.Bilhetes.Infra.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Bilhetes.Api.Controllers
{
    [Route("[controller]")]
    public class BilhetesController : ControllerBase
    {
        private readonly IFilmesApi _fimesApi;

        public BilhetesController(IFilmesApi filmesApi)
        {
            _fimesApi = filmesApi;
        }

        [HttpPost("check-in")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CheckInFilmeAsync([FromQuery] int filmeId)
        {
            try
            {
                var filmeResult = await _fimesApi.GetFilmePorIdAsync(filmeId);
                if (filmeResult is null)
                    return NotFound($"Filme com Id = {filmeId} não foi encontrado.");

                // Realizar o check-in do filme vinculando o usuário

                return Ok(filmeId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
    }
}
