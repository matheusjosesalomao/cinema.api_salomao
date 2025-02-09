using Cinema.Filmes.Domain.Models;

namespace Cinema.Filmes.Domain.Services
{
    public interface IFilmesService
    {
        /// <summary>
        /// Realiza pesquisa em filmes.
        /// </summary>
        /// <param name="pesquisa">Criterios de pesquisa.</param>
        /// <returns>
        ///     Lista dos filmes encontrados conforme criterio de pesquisa.
        /// </returns>
        Task<IEnumerable<Filme>> ObterFilmesAsync(Pesquisa pesquisa);

        Task<Filme> ObterFilmesPorIdAsync(int movieId);
    }
}