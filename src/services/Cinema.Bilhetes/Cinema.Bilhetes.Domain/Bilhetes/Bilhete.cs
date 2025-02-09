namespace Cinema.Bilhetes.Domain.Bilhetes
{
    public class Bilhete
    {
        public Bilhete(int filmeId, int checkInId, decimal preco)
        {
            Id = Guid.NewGuid().ToString();
            FilmeId = filmeId;
            CheckInId = checkInId;
            Preco = preco;
            CriadoEm = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public int FilmeId { get; set; }
        public int CheckInId { get; set; }

        public decimal Preco { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
