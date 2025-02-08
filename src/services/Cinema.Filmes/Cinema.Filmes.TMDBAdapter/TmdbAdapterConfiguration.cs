using System.ComponentModel.DataAnnotations;

namespace Cinema.Filmes.TMDBAdapter
{
    public class TmdbAdapterConfiguration
    {
        [Required]
        public string TmdbApiUrlBase { get; set; }
        [Required]
        public string TmdbApiKey { get; set; }
        [Required]
        public string Idioma { get; set; }
    }
}
