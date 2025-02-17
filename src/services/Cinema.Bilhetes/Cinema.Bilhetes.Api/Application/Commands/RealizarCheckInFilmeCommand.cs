using MediatR;

namespace Cinema.Bilhetes.Api.Application.Commands
{
    public class RealizarCheckInFilmeCommand : IRequest<bool>
    {
        public RealizarCheckInFilmeCommand(int filmeId, string usuarioId)
        {
            FilmeId = filmeId;
            UsuarioId = usuarioId;
        }

        public int FilmeId { get; set; }
        public string UsuarioId { get; set; }
    }
}
