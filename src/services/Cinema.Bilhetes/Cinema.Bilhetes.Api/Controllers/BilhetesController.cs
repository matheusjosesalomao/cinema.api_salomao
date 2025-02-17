using AutoMapper;
using Cinema.Bilhetes.Api.Application.Commands;
using Cinema.Bilhetes.Api.Dtos;
using Cinema.Bilhetes.Domain.Bilhetes;
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
        private readonly IBilheteRepository _bilheteRepository;
        private readonly IMapper _mapper;

        public BilhetesController(IMediator mediator, IBilheteRepository bilheteRepository, IMapper mapper)
        {
            _mediator = mediator;
            _bilheteRepository = bilheteRepository;
            _mapper = mapper;
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

                var bilhetes = await _bilheteRepository.GetBilhetesByUser(idUsuario);

                return Ok(_mapper.Map<IEnumerable<BilhetesGetResult>>(bilhetes));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
    }
}
