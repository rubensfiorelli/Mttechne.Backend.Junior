using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Data;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using System.Data.Common;

namespace Mttechne.Backend.Junior.Services.Repositories;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {

        try
        {
            var listCategories = await _context.Products
                .Take(25)
                .ToListAsync();

            if (listCategories is null)
                return Enumerable.Empty<Product>();

            return listCategories.AsReadOnly();
        }
        catch (DbException)
        {

            throw;
        }
    }

    public async Task<List<Product>> GetByNameAsync(string name)
    {
        try
        {
            var products = _context.Products
               .Where(pn => pn.Name.ToLower().Contains(name.ToLower()));


            return await products.ToListAsync();
        }
        catch (DbException)
        {

            throw;
        }

    }

    public async Task<List<Product>> GetByBiggestPriceAsync()
    {
        try
        {
            var products = _context.Products
                 .OrderByDescending(pp => pp.Price);

            return await products.ToListAsync();
        }
        catch (DbException)
        {

            throw;
        }

    }

    public async Task<List<Product>> GetByLowestPriceAsync()
    {
        try
        {
            var products = _context.Products
                .OrderBy(pp => pp.Price);

            return await products.ToListAsync();
        }
        catch (DbException)
        {

            throw;
        }

    }
    public async Task<List<Product>> GetByMinPriceAndMaxPriceAsync(decimal min, decimal max)
    {
        try
        {
            var products = _context.Products
                .Where(pr => pr.Price >= min && pr.Price <= max);

            return await products.ToListAsync();
        }
        catch (DbException)
        {

            throw;
        }

    }

    public async Task<List<Product>> GetByMaxPriceAsync(decimal max)
    {
        try
        {
            var products = _context.Products
                 .Where(pr => pr.Price <= max)
                 .OrderBy(pp => pp.Price);

            return await products.ToListAsync();
        }
        catch (DbException)
        {

            throw;
        }
    }

    public async Task<List<Product>> GetByMinPriceAsync(decimal min)
    {
        try
        {
            var products = _context.Products
                 .Where(pr => pr.Price >= min)
                 .OrderBy(pp => pp.Price);

            return await products.ToListAsync();
        }
        catch (DbException)
        {

            throw;
        }

    }
}