using Cinema.Bff.ViewModels;

namespace Cinema.Bff.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> LoginAsync(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7240/api/identidade/login", request);
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result?.Token;
        }
    }
}
