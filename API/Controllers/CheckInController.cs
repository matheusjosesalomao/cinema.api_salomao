using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriptoMoeda.Api.Controllers
{
    [Route("[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly ICheckInService checkInService;

        public CheckInController(ICheckInService checkInService)
        {
            this.checkInService = checkInService ??
                throw new ArgumentNullException(nameof(checkInService));
        }

        [HttpPost("check-in")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CheckInFilmeAsync([FromQuery] int filmeId)
        {
            try
            {
                // Verifica se o ID do filme é válido
                //var filme = await checkInService.ObterFilmesPorIdAsync(filmeId);
                //if (filme == null)
                //{
                //    return NotFound($"Filme com Id = {filmeId} não foi encontrado.");
                //}

                // Realiza o check-in do filme
                var sucesso = await checkInService.CheckInFilmeAsync(filmeId);
                if (sucesso)
                {
                    return Ok($"Check-in realizado com sucesso para o filme de Id = {filmeId}.");
                }

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao realizar o check-in para o filme de Id = {filmeId}.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }

    }
}
