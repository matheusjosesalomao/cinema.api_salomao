using AutoMapper;
using Cinema.Filmes.Api.Dtos;
using Cinema.Filmes.Domain.Models;
using Cinema.Filmes.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Filmes.Api.Controllers
{
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmesService filmesService;
        private readonly IMapper mapper;

        public FilmesController(IFilmesService filmesService, IMapper mapper)
        {
            this.filmesService = filmesService ??
                throw new ArgumentNullException(nameof(filmesService));

            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Pesquisa por filmes.
        /// </summary>
        /// <param name="filmesGet">
        ///     Criterios de pesquisa na base de filmes.
        /// </param>
        /// <response code="200">Lista de resultados.</response>
        /// <response code="400">
        ///     Parametros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">Erro interno.</response>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(FilmesGetResult), 200)]
        /// <response code="400"> Dados inválidos</response>
        /// <response code="500">Erro interno.</response>
        public async Task<IActionResult> GetFilmesAsync(
            [FromQuery] FilmesGet filmesGet)
        {
            Pesquisa pesquisa = mapper.Map<FilmesGet, Pesquisa>(filmesGet);
            IEnumerable<Filme> filmes = await filmesService
                .ObterFilmesAsync(pesquisa);
            IEnumerable<FilmesGetResult> filmesGetResults =
                mapper.Map<IEnumerable<FilmesGetResult>>(filmes);

            return Ok(filmesGetResults);
        }

        /// <summary>
        /// Obtém filmes por Id.
        /// </summary>
        /// <param name="filmeId">
        ///     Id do filme
        /// </param>
        /// <response code="200">Retorna o filme.</response>
        /// <response code="400">
        ///     Parâmetros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">Erro interno.</response>
        [HttpGet("{filmeId:int}"), AllowAnonymous]
        [ProducesResponseType(typeof(FilmesGetResult), 200)]
        /// <response code="400"> Dados inválidos</response>
        /// <response code="500">Erro interno.</response>
        public async Task<IActionResult> GetFilmePorIdAsync(
            [FromRoute] int filmeId)
        {
            var filme = await filmesService.ObterFilmesPorIdAsync(filmeId);
            var filmeResult = mapper.Map<FilmesGetResult>(filme);

            return Ok(filmeResult);
        }
    }
}
