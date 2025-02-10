namespace Cinema.Bilhetes.Domain.Bilhetes
{
    public class Bilhete
    {
        public Bilhete(long filmeId, decimal preco, string usuarioId)
        {
            Id = Guid.NewGuid().ToString();
            FilmeId = filmeId;
            CheckInId = Guid.NewGuid().ToString();
            Preco = preco;
            CriadoEm = DateTime.UtcNow;
            UsuarioId = usuarioId;
        }

        public string Id { get; set; }
        public long FilmeId { get; set; }
        public string CheckInId { get; set; }

        public decimal Preco { get; set; }
        public DateTime CriadoEm { get; set; }
        public string UsuarioId { get; set; }
    }
}
