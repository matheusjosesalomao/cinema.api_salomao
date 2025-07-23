namespace Cinema.Bff.ViewModels
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset DataLancamento { get; set; }
    }
}
