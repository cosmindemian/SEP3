using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;
using gateway.DTO;

namespace Client.Implementations
{
    public class LocationHttpClient : ILocationService
    {
        private readonly HttpClient client;

        public LocationHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<SendLocationReturnDto> CreateLocation(SendLocationDto dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/Location", dto);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            var location = JsonSerializer.Deserialize<SendLocationReturnDto>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return location;
        }

        public async Task<IEnumerable<GetPickUpPointDto>> GetAllPickupPoints()
        {
            string uri = "/Location/pick_up_point";
            HttpResponseMessage response = await client.GetAsync(uri);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
            IEnumerable<GetPickUpPointDto> pickupPoints = JsonSerializer.Deserialize<IEnumerable<GetPickUpPointDto>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return pickupPoints;
        }

        public async Task DeletePickupPoint(long id)
        {
            string url = "Location?id=" + id;
            await client.DeleteAsync(url );
        }
    }
}