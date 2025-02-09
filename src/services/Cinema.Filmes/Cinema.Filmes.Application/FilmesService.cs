using Cinema.Filmes.Domain.Adapters;
using Cinema.Filmes.Domain.Models;
using Cinema.Filmes.Domain.Services;

namespace Cinema.Filmes.Application
{
    public class FilmesService : IFilmesService
    {
        private readonly ITmdbAdapter tmdbAdapter;

        public FilmesService(ITmdbAdapter tmdbAdapter)
        {
            this.tmdbAdapter = tmdbAdapter ?? throw new ArgumentNullException(nameof(tmdbAdapter));
        }

        public async Task<IEnumerable<Filme>> ObterFilmesAsync(
            Pesquisa pesquisa)
        {
            if (pesquisa == null || string.IsNullOrWhiteSpace(pesquisa.TermoPesquisa))
            {
                throw new Exception("Critérios de pesquisa não são validos.");
            }

            IEnumerable<Filme> resultado = await tmdbAdapter
                .GetFilmesAsync(pesquisa);

            return resultado;
        }

        public async Task<Filme> ObterFilmesPorIdAsync(int movie_id)
        {
            if (movie_id < 0)
            {
                throw new Exception("Critérios de pesquisa não são validos.");
            }

            var resultado = await tmdbAdapter
                .GetFilmesPorIdAsync(movie_id);

            return resultado;
        }
    }
}
