using AutoMapper;
using Cinema.Filmes.Domain.Adapters;
using Cinema.Filmes.Domain.Models;
using Cinema.Filmes.TMDBAdapter.Clients;
using Refit;
using System.Net;

namespace Cinema.Filmes.TMDBAdapter
{
    internal class TmdbAdapter : ITmdbAdapter
    {
        private readonly ITmdbApi tmdbApi;
        private readonly TmdbAdapterConfiguration tmdbAdapterConfiguration;
        private readonly IMapper mapper;

        public TmdbAdapter(ITmdbApi tmdbApi,
            TmdbAdapterConfiguration tmdbAdapterConfiguration,
            IMapper mapper)
        {
            this.tmdbApi = tmdbApi ??
                throw new ArgumentNullException(nameof(tmdbApi));

            this.tmdbAdapterConfiguration = tmdbAdapterConfiguration ??
                throw new ArgumentNullException(nameof(tmdbAdapterConfiguration));

            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Filme>> GetFilmesAsync(
            Pesquisa pesquisa)
        {
            try
            {
                var tmdbSearchMoviesGet =
                    mapper.Map<TmdbSearchMoviesGet>(pesquisa);

                tmdbSearchMoviesGet.ApiKey =
                    tmdbAdapterConfiguration.TmdbApiKey;

                tmdbSearchMoviesGet.Language = tmdbAdapterConfiguration.Idioma;

                var tmdbSearchMoviesGetResult = await tmdbApi
                    .SearchMovies(tmdbSearchMoviesGet);

                return mapper
                    .Map<IEnumerable<Filme>>(tmdbSearchMoviesGetResult.Results);
            }
            catch (ApiException e)
            {
                switch (e.StatusCode)
                {
                    case (HttpStatusCode)429:
                        throw new Exception();
                }

                throw;
            }
        }

        public async Task<Filme> GetFilmesPorIdAsync(int movieId)
        {
            try
            {
                // Faça a chamada para o método da API passando o cabeçalho de autorização
                var tmdbSearchMoviesGetResult = await tmdbApi
                    .SearchMoviesById(movieId);

                return mapper.Map<Filme>(tmdbSearchMoviesGetResult);
            }
            catch (ApiException e)
            {
                switch (e.StatusCode)
                {
                    case (HttpStatusCode)429:
                        throw new Exception();
                }

                throw;
            }
        }
    }
}
