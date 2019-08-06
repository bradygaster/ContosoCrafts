using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}