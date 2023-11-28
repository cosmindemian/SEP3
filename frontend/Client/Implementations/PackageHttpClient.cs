using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Interfaces;
using System.Text.Json;
using Domain.DTO;

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

            public async Task<PackageCreationDto> CreatePackage(PackageCreationDto dto)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("/createPackage", dto);
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }

                PackageCreationDto package = JsonSerializer.Deserialize<PackageCreationDto>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return package;
            }

            public async Task<IEnumerable<PackageBasicDto>> GetAllPackagesByUserId(long userId)
            {
                string uri = "/packages";
                HttpResponseMessage response = await client.GetAsync(uri);
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }

                IEnumerable<PackageBasicDto> packages = JsonSerializer.Deserialize<IEnumerable<PackageBasicDto>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return packages;
            }
    }
}