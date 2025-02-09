using Refit;

namespace Cinema.Bilhetes.Infra.Http
{
    public interface IFilmesApi
    {
        [Get("/filmes/{filmeId}")]
        Task<bool> GetFilmePorId(int id);
    }
}
