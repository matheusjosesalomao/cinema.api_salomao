using Cinema.Bff.ViewModels;

namespace Cinema.Bff.Services
{
    public class FilmesService
    {
        private readonly HttpClient _httpClient;

        public FilmesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Filme>> BuscarFilmesAsync(string termo, int? ano)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7218/filmes?TermoPesquisa={termo}&ano={ano}");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Filme>>() ?? Enumerable.Empty<Filme>();
        }

        public async Task<Filme?> BuscarFilmePorIdAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7218/filmes/{id}");
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<Filme>();
        }
    }
}
