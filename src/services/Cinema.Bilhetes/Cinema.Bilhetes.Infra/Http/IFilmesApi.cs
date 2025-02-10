using Cinema.Bilhetes.Infra.Http.Dto;
using Refit;

namespace Cinema.Bilhetes.Infra.Http
{
    public interface IFilmesApi
    {
        [Get("/Filmes/{filmeId}")]
        Task<FilmeDto> GetFilmePorIdAsync(int filmeId);
    }
}
