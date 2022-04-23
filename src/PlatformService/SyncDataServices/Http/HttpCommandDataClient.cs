using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using PlatformService.Dtos;
using Microsoft.Extensions.Configuration;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto model)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            string url = string.Format("{0}command/platforms", _configuration["CommandService"]);
            var response = await _httpClient.PostAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("--> Sync POST to Command Services was OK");
            }
            else
            {
                System.Console.WriteLine("--> Sync POST to Command Services was NO OK");
            }

        }
    }
}