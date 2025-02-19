using Cinema.Bilhetes.Api.Application.Commands;
using Cinema.Bilhetes.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.Bilhetes.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class BilhetesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBilhetesQueries _bilhetesQueries;

        public BilhetesController(IMediator mediator, IBilhetesQueries bilhetesQueries)
        {
            _mediator = mediator;
            _bilhetesQueries = bilhetesQueries;
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
                var idUsuario = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (idUsuario == null)
                    return StatusCode(StatusCodes.Status403Forbidden, "Usuário não autenticado");

                var comando = new RealizarCheckInFilmeCommand(filmeId, idUsuario);
                var enviarComando = await _mediator.Send(comando);

                if (enviarComando)
                    return Ok($"Check-in realizado com sucesso para o filme de Id = {filmeId}");

                return NotFound($"Filme com Id = {filmeId} não foi encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBilhetesPorUsuarioAsync()
        {
            try
            {
                var idUsuario = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (idUsuario == null)
                    return StatusCode(StatusCodes.Status403Forbidden, "Usuário não autenticado");

                var bilhetes = _bilhetesQueries.ObterBilhetesPorUsuario(idUsuario);

                return Ok(bilhetes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
    }
}
