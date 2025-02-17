namespace Cinema.Bilhetes.Api.Dtos
{
    public class BilhetesGetResult
    {
        public string Id { get; set; }
        public long Filmeid { get; set; }
        public string CheckInId { get; set; }
        public double Preco { get; set; }
    }
}
