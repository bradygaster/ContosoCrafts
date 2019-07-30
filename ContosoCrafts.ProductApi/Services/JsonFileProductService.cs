using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContosoCrafts.ProductApi.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.ProductApi.Services
{
   public class JsonFileProductService : IProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IEnumerable<Product> GetProducts()
        {
            var jsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

            using(var jsonFileReader = File.OpenText(jsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }

            throw new System.InvalidOperationException("No products found.");
        }
    }

}