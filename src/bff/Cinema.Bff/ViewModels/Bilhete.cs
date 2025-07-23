namespace Cinema.Bff.ViewModels
{
    public class Bilhete
    {
        public string Id { get; set; }
        public long Filmeid { get; set; }
        public string CheckInId { get; set; }
        public double Preco { get; set; }
    }
}
