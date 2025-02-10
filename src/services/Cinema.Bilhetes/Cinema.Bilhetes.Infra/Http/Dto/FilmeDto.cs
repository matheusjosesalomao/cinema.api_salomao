namespace Cinema.Bilhetes.Infra.Http.Dto
{
    public record FilmeDto(long Id, string Nome, string Descricao, DateTimeOffset DataLancamento);
}
