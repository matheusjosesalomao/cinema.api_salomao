using System.ComponentModel.DataAnnotations;

namespace Cinema.Bilhetes.Infra.Data
{
    public class MongoDbConfig
    {
        [Required]
        public string DefaultConnection { get; set; }
    }
}
