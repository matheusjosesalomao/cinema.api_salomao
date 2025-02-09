using Cinema.Filmes.Domain.Models;

namespace Cinema.Filmes.Domain.Adapters
{
    public interface ITmdbAdapter
    {
        /// <summary>
        /// Realiza pesquisa em filmes.
        /// Este adaptador consiste em um exemplo para acesso ao
        /// TMDb API (The Movie Database - https://developers.themoviedb.org/3)
        /// </summary>
        /// <param name="pesquisa">Criterios de pesquisa.</param>
        /// <returns>
        ///     Lista dos filmes encontrados conforme criterio de pesquisa.
        /// </returns>
        /// <exception cref="Exceptions.BuscarFilmesCoreException" />
        Task<IEnumerable<Filme>> GetFilmesAsync(Pesquisa pesquisa);
        Task<Filme> GetFilmesPorIdAsync(int movie_id);
    }
}



