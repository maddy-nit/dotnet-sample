using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPIForTechGig.Models;
using ProductsAPIForTechGig.Models.Domain;
using ProductsAPIForTechGig.Repository;

namespace ProductsAPIForTechGig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        // [HttpGet]
        // public async Task<IActionResult> GetProductAsync()
        // {
        // }
        // [HttpGet("id")]
        // public async Task<IActionResult> GetProductByIdAsync(int id)
        // {
        // }
        // [HttpPost]
        // public async Task<IActionResult> AddProductAsync(Product product)
        // {
        // }
        
        // [HttpDelete("{id:int}")]
        // public async Task<IActionResult> DeleteProductAsync(int id)
        // {
        // }
    }
}
