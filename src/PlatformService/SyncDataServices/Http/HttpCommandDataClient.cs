using System.Text.Json;
using System.Text;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;

        public HttpCommandDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendPlatformToCommand(PlatformReadDto model)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var posted = await _httpClient.PostAsync("https://localhost:7299/api/command/Platforms", httpContent);
            
        }
    }
}