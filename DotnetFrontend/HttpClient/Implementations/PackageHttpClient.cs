
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Client.Interfaces;
using System.Text.Json;
using gateway.DTO;

namespace Client.Implementations
{
    public class PackageHttpClient: IPackageService{
        
            private readonly HttpClient client;

            public PackageHttpClient(HttpClient client)
            {
                this.client = client;
            }

            public async Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber)
            {
                HttpResponseMessage response = await client.GetAsync($"/package/{trackingNumber}");
                string content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(content);
                }
                //use var (packageDTO)
                var packageDTO = JsonSerializer.Deserialize<GetPackageDto>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true
            
                });
                return packageDTO;
            }

            public async Task<SendPackageReturnDto> CreatePackage(SendPackageDto dto)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("/Package", dto);
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }

                var package = JsonSerializer.Deserialize<SendPackageReturnDto>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return package;
            }

            public async Task<IEnumerable<GetShortPackageDto>> GetAllPackagesByUserId(string token)
            {
                string uri = "/package";
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                request.Headers.Add("Bearer", new []{token});
                HttpResponseMessage response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }

                IEnumerable<GetShortPackageDto> packages = JsonSerializer.Deserialize<IEnumerable<GetShortPackageDto>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return packages;
            }
    }
}