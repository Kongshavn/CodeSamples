using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClientCredentials.Application.Models;

namespace ClientCredentials.Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Remember to inject with DI
            var httpClient = new HttpClient();

            var request = new ClientAuthenticationRequestModel("{TokenEndpoint}",
                "{ClientId}", "{ClientSecret}", new List<string>() { "{ListOfScopes" });

            var jsonResponse = await httpClient.SendAsync(request.GetRequest());

            if (jsonResponse.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<ClientAuthenticationResponseModel>(await jsonResponse.Content.ReadAsStringAsync());
                Console.WriteLine(response.AccessToken);
            }
            else
                Console.WriteLine("Failed to retrieve token");
        }
    }
}
