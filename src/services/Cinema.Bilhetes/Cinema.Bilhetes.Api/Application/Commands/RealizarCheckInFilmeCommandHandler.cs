using Cinema.Bilhetes.Domain.Bilhetes;
using Cinema.Bilhetes.Infra.Http;
using MediatR;

namespace Cinema.Bilhetes.Api.Application.Commands
{
    public class RealizarCheckInFilmeCommandHandler : IRequestHandler<RealizarCheckInFilmeCommand, bool>
    {
        private readonly IFilmesApi _fimesApi;
        private readonly IBilheteRepository _bilheteRepository;

        public RealizarCheckInFilmeCommandHandler(IFilmesApi filmesApi, IBilheteRepository bilheteRepository)
        {
            _fimesApi = filmesApi;
            _bilheteRepository = bilheteRepository;
        }

        public async Task<bool> Handle(RealizarCheckInFilmeCommand request, CancellationToken cancellationToken)
        {
            var filmeResult = await _fimesApi.GetFilmePorIdAsync(request.FilmeId);
            if (filmeResult is null)
                return false;

            var bilhete = new Bilhete(filmeResult.Id, 20, request.UsuarioId);

            await _bilheteRepository.CreateAsync(bilhete);

            return true;
        }
    }
}
