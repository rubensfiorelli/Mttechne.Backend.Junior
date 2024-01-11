using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[Route("v1/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsList()
    {
        var result = await _productService.GetAllProductsAsync();
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetProductsName(string name)
    {
        try
        {
            var result = await _productService.GetByNameAsync(name);

            if (result is null)
                return NotFound();

            return Ok(result);

        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

    [HttpGet("biggest")]
    public async Task<IActionResult> GetByBiggestPrice()
    {
        try
        {
            var result = await _productService.GetByBiggestPriceAsync();

            if (result is null)
                return NotFound();

            return Ok(result);

        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

    [HttpGet("lowrest")]
    public async Task<IActionResult> GetByLowestPrice()
    {
        try
        {
            var result = await _productService.GetByLowestPriceAsync();

            if (result is null)
                return NotFound();

            return Ok(result);

        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

    [HttpGet("min-max-price")]
    public async Task<IActionResult> GetByMinPriceAndMaxPrice(decimal min, decimal max)
    {
        try
        {
            var result = await _productService.GetByMinPriceAndMaxPriceAsync(min, max);

            if (result is null)
                return NotFound();

            return Ok(result);

        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

    [HttpGet("max-price/{price}")]
    public async Task<IActionResult> GetByMaxPrice(decimal price)
    {
        try
        {
            var result = await _productService.GetByMaxPriceAsync(price);

            if (result is null)
                return NotFound();

            return Ok(result);

        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

    [HttpGet("min-price/{price}")]
    public async Task<IActionResult> GetByMinPrice(decimal price)
    {
        try
        {
            var result = await _productService.GetByMinPriceAsync(price);

            if (result is null)
                return NotFound();

            return Ok(result);

        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

}