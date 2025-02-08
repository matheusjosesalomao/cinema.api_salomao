using AutoMapper;
using Cinema.Filmes.Api.Dtos;
using Cinema.Filmes.Domain.Models;
using Cinema.Filmes.TMDBAdapter;

namespace Cinema.Filmes.Api
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection servicos)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullDestinationValues = true;
                mc.AllowNullCollections = true;
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new TmdbMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            servicos.AddSingleton(mapper);
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Filme, FilmesGetResult>();
                CreateMap<FilmesGet, Pesquisa>();
            }
        }
    }
}
