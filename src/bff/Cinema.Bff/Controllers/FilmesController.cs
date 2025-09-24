using Cinema.Bff.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly FilmesService _filmesService;

        public FilmesController(FilmesService filmesService)
        {
            _filmesService = filmesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmes([FromQuery] string termo, [FromQuery] int? ano)
        {
            var filmes = await _filmesService.BuscarFilmesAsync(termo, ano);
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmePorId(int id)
        {
            var filme = await _filmesService.BuscarFilmePorIdAsync(id);
            if (filme == null)
                return NotFound();

            return Ok(filme);
        }
    }
}
