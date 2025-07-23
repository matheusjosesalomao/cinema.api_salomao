using AutoMapper;
using Cinema.Bilhetes.Api.Dtos;
using Cinema.Bilhetes.Domain.Bilhetes;

namespace Cinema.Bilhetes.Api.Application.Queries
{
    public interface IBilhetesQueries
    {
        Task<IEnumerable<BilhetesGetResult>> ObterBilhetesPorUsuario(string idUsuario);
    }
    public class BilhetesQueries : IBilhetesQueries
    {
        private readonly IBilheteRepository _bilheteRepository;
        private readonly IMapper _mapper;

        public BilhetesQueries(IBilheteRepository bilheteRepository, IMapper mapper)
        {
            _bilheteRepository = bilheteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BilhetesGetResult>> ObterBilhetesPorUsuario(string idUsuario)
        {
            var bilhetes = await _bilheteRepository.GetBilhetesByUser(idUsuario);

            return _mapper.Map<IEnumerable<BilhetesGetResult>>(bilhetes);
        }
    }
}
