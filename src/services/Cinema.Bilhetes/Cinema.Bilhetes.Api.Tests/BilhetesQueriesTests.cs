using AutoMapper;
using Cinema.Bilhetes.Api.Application.Queries;
using Cinema.Bilhetes.Api.Dtos;
using Cinema.Bilhetes.Domain.Bilhetes;
using Moq;

namespace Cinema.Bilhetes.Api.Tests
{
    public class BilhetesQueriesTests
    {
        [Fact]
        public async Task ObterBilhetesPorUsuario_DeveRetornarListaDeBilhetes_Sucesso()
        {
            // Arrange
            var usuarioId = Guid.NewGuid().ToString();
            var bilhetesRepo = new List<Bilhete>
            {
                new Bilhete(123, 20, usuarioId) { Id = Guid.NewGuid().ToString() },
                new Bilhete(456, 20, usuarioId) { Id = Guid.NewGuid().ToString() },
            };

            var bilhetesEsperados = new List<BilhetesGetResult>
            {
                new BilhetesGetResult { Id = Guid.NewGuid().ToString(), Filmeid = 123 },
                new BilhetesGetResult { Id = Guid.NewGuid().ToString(), Filmeid = 456 },
            };

            var bilheteRepositoryMock = new Mock<IBilheteRepository>();
            bilheteRepositoryMock.Setup(r => r.GetBilhetesByUser(It.IsAny<string>())).ReturnsAsync(bilhetesRepo);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<BilhetesGetResult>>(bilhetesRepo)).Returns(bilhetesEsperados);

            var bilheteQueries = new BilhetesQueries(bilheteRepositoryMock.Object, mapperMock.Object);

            // Act
            var resultado = await bilheteQueries.ObterBilhetesPorUsuario(usuarioId);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(bilhetesEsperados.Count(), resultado.Count());
            Assert.Equal(bilhetesEsperados.First().Filmeid, resultado.First().Filmeid);
            bilheteRepositoryMock.Verify(r => r.GetBilhetesByUser(It.IsAny<string>()), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<IEnumerable<BilhetesGetResult>>(bilhetesRepo), Times.Once);
        }
    }
}