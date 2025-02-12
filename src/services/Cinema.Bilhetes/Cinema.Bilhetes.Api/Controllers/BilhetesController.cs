using Cinema.Bilhetes.Domain.Bilhetes;
using Cinema.Bilhetes.Infra.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.Bilhetes.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class BilhetesController : ControllerBase
    {
        private readonly IFilmesApi _fimesApi;
        private readonly IBilheteRepository _bilheteRepository;

        public BilhetesController(IFilmesApi filmesApi, IBilheteRepository bilheteRepository)
        {
            _fimesApi = filmesApi;
            _bilheteRepository = bilheteRepository;
        }

        [HttpPost("check-in")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CheckInFilmeAsync([FromQuery] int filmeId)
        {
            try
            {
                var filmeResult = await _fimesApi.GetFilmePorIdAsync(filmeId);
                if (filmeResult is null)
                    return NotFound($"Filme com Id = {filmeId} não foi encontrado.");

                var idUsuario = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (idUsuario == null)
                    return StatusCode(StatusCodes.Status403Forbidden, "Usuário não autenticado");

                var bilhete = new Bilhete(filmeResult.Id, 20, idUsuario);

                await _bilheteRepository.CreateAsync(bilhete);

                return Ok($"Check-in realizado com sucesso para o filme de Id = {filmeId}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
    }
}
