using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DetailService.Dtos;
using Microsoft.Extensions.Configuration;

namespace DetailService.SyncDataServices.Http
{
    public class HttpProviderDataClient : IProviderDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpProviderDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }




        public async Task SendDetailToCommand(DetailReadDto det)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(det),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync($"{_configuration["ProvidersService"]}", httpContent);


            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to ProviderService was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to ProviderService was NOT OK!");
            }
        }
    }
}