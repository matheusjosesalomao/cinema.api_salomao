using Cinema.Bff.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Bff.Controllers
{
    [ApiController]
    [Route("api/bilhetes")]
    public class BilhetesController : ControllerBase
    {
        private readonly BilhetesService _bilhetesService;

        public BilhetesController(BilhetesService bilhetesService)
        {
            _bilhetesService = bilhetesService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBilhetesPorUsuario()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            try
            {
                var bilhetes = await _bilhetesService.ObterBilhetesPorUsuarioAsync(token);
                return Ok(bilhetes);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost("check-in")]
        [Authorize]
        public async Task<IActionResult> CheckInFilme([FromQuery] int filmeId)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            try
            {
                var result = await _bilhetesService.RealizarCheckInFilmeAsync(filmeId, token);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
