using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;
using Domain.DTO;

namespace Client.Implementations
{
    public class LocationHttpClient : ILocationService
    {
        private readonly HttpClient client;

        public LocationHttpClient(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task<IEnumerable<GetLocationDto>> GetAllPackagesByUserId(long userId)
        {
            string uri = "/pickupPoints";
            HttpResponseMessage response = await client.GetAsync(uri);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
            IEnumerable<GetLocationDto> pickupPoints = JsonSerializer.Deserialize<IEnumerable<GetLocationDto>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return pickupPoints;
        }
    }
}