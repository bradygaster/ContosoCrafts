using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}