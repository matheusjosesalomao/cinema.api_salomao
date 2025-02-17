using AutoMapper;
using Cinema.Bilhetes.Api.Dtos;
using Cinema.Bilhetes.Domain.Bilhetes;

namespace Cinema.Bilhetes.Api
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
            });

            var mapper = mappingConfig.CreateMapper();
            servicos.AddSingleton(mapper);
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Bilhete, BilhetesGetResult>();
            }
        }
    }
}
