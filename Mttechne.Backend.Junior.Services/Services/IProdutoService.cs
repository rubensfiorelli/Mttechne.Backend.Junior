using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<List<Product>> GetByNameAsync(string name);
    Task<List<Product>> GetByBiggestPriceAsync();
    Task<List<Product>> GetByLowestPriceAsync();
    Task<List<Product>> GetByMinPriceAndMaxPriceAsync(decimal min, decimal max);
    Task<List<Product>> GetByMaxPriceAsync(decimal price);
    Task<List<Product>> GetByMinPriceAsync(decimal price);



}