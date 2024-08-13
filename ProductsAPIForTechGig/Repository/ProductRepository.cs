using Microsoft.EntityFrameworkCore;
using ProductsAPIForTechGig.Data;
using ProductsAPIForTechGig.Models.Domain;

namespace ProductsAPIForTechGig.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
           _productDbContext = productDbContext;
        }
        // public async Task<Product> AddProductAsync(Product product)
        // {
            
        // }

        // public async Task<Product> DeleteProductAsync(int id)
        // {
            
        // }

        // public async Task<Product> GetProductAsync(int id)
        // {
        // }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productDbContext.Products.ToListAsync(); 
        }
    }
}
