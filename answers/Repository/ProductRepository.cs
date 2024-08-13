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
        public async Task<Product> AddProductAsync(Product product)
        {
            await _productDbContext.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var productToDelete = await _productDbContext.Products.SingleAsync(x => x.Id == id);
            if (productToDelete == null)
            {
                return null;
            }
            else
            {
               _productDbContext.Remove(productToDelete);
                await _productDbContext.SaveChangesAsync();
            }
            return productToDelete;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productDbContext.Products.ToListAsync(); 
        }
    }
}
