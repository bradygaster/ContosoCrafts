using System.Collections.Generic;
using ContosoCrafts.ProductApi.Models;

namespace ContosoCrafts.ProductApi.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}