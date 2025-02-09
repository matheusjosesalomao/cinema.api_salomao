using AutoMapper;
using Cinema.Filmes.Domain.Models;
using Cinema.Filmes.TMDBAdapter.Clients;

namespace Cinema.Filmes.TMDBAdapter
{
    public class TmdbMapperProfile : Profile
    {
        public TmdbMapperProfile()
        {
            CreateMap<TmdbSearchMoviesGetResult.ResultItem, Filme>()
                .ForMember(destino => destino.Descricao,
                    opt => opt.MapFrom(origem => origem.Overview))
                .ForMember(destino => destino.Nome,
                    opt => opt.MapFrom(origem => origem.Title))
                .ForMember(destino => destino.DataLancamento,
                    opt => opt.MapFrom(origem => origem.ReleaseDate));

            CreateMap<Pesquisa, TmdbSearchMoviesGet>()
                .ForMember(destino => destino.Query,
                    opt => opt.MapFrom(origem => origem.TermoPesquisa))
                .ForMember(destino => destino.Year,
                    opt => opt.MapFrom(origem => origem.AnoLancamento));

            CreateMap<Movie, Filme>()
                .ForMember(destino => destino.Nome,
                    opt => opt.MapFrom(origem => origem.Title))
                .ForMember(destiono => destiono.Descricao,
                    opt => opt.MapFrom(origem => origem.Overview))
                .ForMember(destino => destino.DataLancamento,
                    opt => opt.MapFrom(origem => origem.ReleaseDate));
        }
    }
}
