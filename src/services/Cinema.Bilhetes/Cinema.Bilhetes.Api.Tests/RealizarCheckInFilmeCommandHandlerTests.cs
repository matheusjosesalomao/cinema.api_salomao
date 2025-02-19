using Cinema.Bilhetes.Api.Application.Commands;
using Cinema.Bilhetes.Domain.Bilhetes;
using Cinema.Bilhetes.Infra.Http;
using Cinema.Bilhetes.Infra.Http.Dto;
using Moq;

namespace Cinema.Bilhetes.Api.Tests
{
    public class RealizarCheckInFilmeCommandHandlerTests
    {
        [Fact]
        public async Task Handle_DeveRetornarTrue_QuandoFilmeObtidoECheckInRealizado_Sucesso()
        {
            // Arrange
            var filmeId = 1;
            var usuarioId = "123";
            var filmeResultMock = new FilmeDto(filmeId, "Nome Teste", "Descricao Teste", DateTimeOffset.Now);

            var filmesApiMock = new Mock<IFilmesApi>();
            filmesApiMock
                .Setup(api => api.GetFilmePorIdAsync(filmeId))
                .ReturnsAsync(filmeResultMock);

            var bilheteRepositoryMock = new Mock<IBilheteRepository>();
            bilheteRepositoryMock
                .Setup(repo => repo.CreateAsync(It.IsAny<Bilhete>()))
                .Returns(Task.CompletedTask);

            var handler = new RealizarCheckInFilmeCommandHandler(filmesApiMock.Object, bilheteRepositoryMock.Object);

            var command = new RealizarCheckInFilmeCommand(filmeId, usuarioId);

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado);
            filmesApiMock.Verify(api => api.GetFilmePorIdAsync(filmeId), Times.Once);
            bilheteRepositoryMock.Verify(repo => repo.CreateAsync(It.Is<Bilhete>(b => b.FilmeId == filmeId && b.UsuarioId == usuarioId)), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoFilmeNaoForEncontrado_Erro()
        {
            // Arrange
            var filmeId = 1;
            var usuarioId = "123";

            var filmesApiMock = new Mock<IFilmesApi>();
            filmesApiMock
                .Setup(api => api.GetFilmePorIdAsync(filmeId))
                .ReturnsAsync((FilmeDto)null);

            var bilheteRepositoryMock = new Mock<IBilheteRepository>();

            var handler = new RealizarCheckInFilmeCommandHandler(filmesApiMock.Object, bilheteRepositoryMock.Object);

            var command = new RealizarCheckInFilmeCommand(filmeId, usuarioId);

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(resultado);
            filmesApiMock.Verify(api => api.GetFilmePorIdAsync(filmeId), Times.Once);
            bilheteRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Bilhete>()), Times.Never);
        }
    }
}
