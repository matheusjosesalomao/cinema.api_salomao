using Cinema.Bff.Services;
using Cinema.Bff.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Bff.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public AuthController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _usuarioService.LoginAsync(request);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}
