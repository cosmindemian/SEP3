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
        

            public async Task<Package> GetPackageByIdAsync(long id)
            {
                HttpResponseMessage response = await client.GetAsync($"/package/{id}");
                string content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(content);
                }
                Console.WriteLine(content);
                //use var (packageDTO)
                var packageDTO = JsonSerializer.Deserialize<PackageGetDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true
            
                });
        
                Customer sender = new Customer(packageDTO.SenderName);
                Address receiverAddress = new Address(packageDTO.ReceiverAddress.Street, packageDTO.ReceiverAddress.Number,
                    packageDTO.ReceiverAddress.City);
                Address lastKnowLocation = new Address("Kabelikova", 3, "Prerov");

                Package package = new Package(packageDTO.Weight, sender, lastKnowLocation, receiverAddress);
                return package;
            }
    }
}