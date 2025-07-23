using Cinema.Bff.ViewModels;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Cinema.Bff.Services
{
    public class BilhetesService
    {
        private readonly HttpClient _httpClient;

        public BilhetesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Bilhete>> ObterBilhetesPorUsuarioAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7104/bilhetes");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new UnauthorizedAccessException("Usuário não autenticado");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Bilhete>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Bilhete>();
        }

        public async Task<string> RealizarCheckInFilmeAsync(int filmeId, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:5003/bilhetes/check-in?filmeId={filmeId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new UnauthorizedAccessException("Usuário não autenticado");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new InvalidOperationException($"Filme com Id = {filmeId} não foi encontrado.");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
