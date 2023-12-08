
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Client.Interfaces;
using System.Text.Json;
using gateway.DTO;
using Google.Protobuf.WellKnownTypes;

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

            public async Task<GetAllPackagesByUserDto> GetAllPackagesByUserId(string token)
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

                GetAllPackagesByUserDto packages = JsonSerializer.Deserialize<GetAllPackagesByUserDto>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return packages;
            }

            public async Task UpdateFinalLocation(UpdateFinalLocationDto dto, string token)
            {
                string uri = "/Package/update_location";
                var request = new HttpRequestMessage(HttpMethod.Put, uri);
                request.Headers.Add("Bearer", new []{token});
                request.Content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
                
                HttpResponseMessage response = await client.SendAsync(request);
                
                string result = await response.Content.ReadAsStringAsync();
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }
            }
    }
}