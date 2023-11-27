using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Interfaces;
using System.Text.Json;



namespace Client.Implementations
{
    public class PackageHttpClient: IPackageService{
        
            private readonly HttpClient client;

            public PackageHttpClient(HttpClient client)
            {
                this.client = client;
            }

            public async Task<PackageGetDTO> GetPackageByTrackingNumberAsync(string trackingNumber)
            {
                HttpResponseMessage response = await client.GetAsync($"/package/{trackingNumber}");
                string content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(content);
                }
                //use var (packageDTO)
                var packageDTO = JsonSerializer.Deserialize<PackageGetDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true
            
                });
                return packageDTO;
            }

            public async Task<PackageGetDTO> CreatePackage(PackageGetDTO dto)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("/packages", dto);
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }

                PackageGetDTO package = JsonSerializer.Deserialize<PackageGetDTO>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return package;
            }
    }
}