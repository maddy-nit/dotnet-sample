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
        [HttpGet]
        public async Task<IActionResult> GetProductAsync()
        {
            var allProducts = await _productRepository.GetProductsAsync();
            if (allProducts.Count() == 0)
            {
                return NoContent();
            }
            var productDto = _mapper.Map<List<ProductDto>>(allProducts);
            return Ok(productDto);

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {

            var singleProduct = await _productRepository.GetProductAsync(id);
            if (singleProduct == null)
            {
                return NoContent();
            }
            var productDto = _mapper.Map<ProductDto>(singleProduct);
            return Ok(productDto);

        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var productModel = new Product()
                {
                   ProductName=product.ProductName,
                   ProductDescription=product.ProductDescription,
                   Prize=product.Prize,
                   Category=product.Category
                };
                product = await _productRepository.AddProductAsync(productModel);

                var productDto = _mapper.Map<ProductDto>(product);

                return Created("Created Successfully", productDto);


            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var product = await _productRepository.DeleteProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

    }
}
