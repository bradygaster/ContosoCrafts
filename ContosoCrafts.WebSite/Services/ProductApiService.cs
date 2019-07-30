using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Services
{
    public class ProductApiService : IProductService
    {
        public ProductApiService(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public IHttpClientFactory ClientFactory { get; }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:4001/product");

            var httpClient = ClientFactory.CreateClient();

            var httpResponse = await httpClient.SendAsync(httpRequest);
            if(httpResponse.IsSuccessStatusCode)
            {
                var productJson = await httpResponse.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Product[]>(productJson,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }

            return Array.Empty<Product>();
        }
    }
}