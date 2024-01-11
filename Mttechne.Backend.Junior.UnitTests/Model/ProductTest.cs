using Moq;
using Mttechne.Backend.Junior.Services.Repositories;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.UnitTests.Helpers;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProductTest
{
    private ProductService _productService;

    public ProductTest()
    {
        _productService = new ProductService((Services.Data.ApplicationDbContext)new Mock<IProductService>().Object);
    }


}