using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;
using CSharpShared.Exception;
using gateway.DTO;

namespace Client.Implementations
{
    public class LocationHttpClient : ILocationService
    {
        private readonly HttpClient client;
        private ExceptionHandler _exceptionHandler;
        public LocationHttpClient(HttpClient client, ExceptionHandler exceptionHandler)
        {
            this.client = client;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<SendLocationReturnDto> CreateLocation(CreateLocationDto dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/Location", dto);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var content= await response.Content.ReadFromJsonAsync<ApiException>();
                _exceptionHandler.Throw(content);
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
                var content= await response.Content.ReadFromJsonAsync<ApiException>();
                _exceptionHandler.Throw(content);
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
            var response = await client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<ApiException>();
                _exceptionHandler.Throw(content);
            }
        }
    }
}