using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProductsAPIForTechGig.UnitTests.MockData;
using FluentAssertions;
using ProductsAPIForTechGig.Controllers;
using ProductsAPIForTechGig.Repository;
using ProductsAPIForTechGig.Models.Domain;

namespace ProductsAPIForTechGig.UnitTests.Systems.Controllers
{
    public class TestProductController
    {
        [Fact]

        public async Task GetProductAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
         productRepository.Setup(x => x.GetProductsAsync()).ReturnsAsync(ProductMockData.GetProducts());



            var sut = new ProductController(productRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetProductAsync();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetProductAsync_ShouldBe204StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();



            productRepository.Setup(x => x.GetProductsAsync()).ReturnsAsync(ProductMockData.EmptyProductsList());



            var sut = new ProductController(productRepository.Object, mapper.Object);



            //Act
            var result = await sut.GetProductAsync();



            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task GetByProductIdAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
            int productId = 1;
            productRepository.Setup(x => x.GetProductAsync(productId)).ReturnsAsync(ProductMockData.Product());
            var sut = new ProductController(productRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetProductByIdAsync(productId);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetByProductIdAsync_ShouldBe204StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
            int productId = 1;
            productRepository.Setup(x => x.GetProductAsync(productId)).ReturnsAsync(ProductMockData.EmptyProduct());
            var sut = new ProductController(productRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetProductByIdAsync(productId);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task AddProductAsync_ShouldBe201StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
            var prodstruct = new Mock<Product>();



            productRepository.Setup(x => x.AddProductAsync(prodstruct.Object)).ReturnsAsync(ProductMockData.Product());
            var sut = new ProductController(productRepository.Object, mapper.Object);
            //Act
            var result = await sut.AddProductAsync(prodstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(CreatedResult));
            (result as CreatedResult).StatusCode.Should().Be(201);
        }
        [Fact]
        public async Task AddProductAsync_ShouldBe400StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
            var productstruct = new Mock<Product>();


            productRepository.Setup(x => x.AddProductAsync(productstruct.Object)).ReturnsAsync(ProductMockData.EmptyProduct());
            var sut = new ProductController(productRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");
            //Act
            var result = await sut.AddProductAsync(productstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task DeleteProductAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
            int productId = 1;



            productRepository.Setup(x => x.DeleteProductAsync(productId)).ReturnsAsync(ProductMockData.Product());
            var sut = new ProductController(productRepository.Object, mapper.Object);



            //Act
            var result = await sut.DeleteProductAsync(productId);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DeleteProductAsync_ShouldBe404StatusCode()
        {
            //Arrange
            var productRepository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
            int productId = 1;



            productRepository.Setup(x => x.DeleteProductAsync(productId)).ReturnsAsync(ProductMockData.EmptyProduct());
            var sut = new ProductController(productRepository.Object, mapper.Object);



            //Act
            var result = await sut.DeleteProductAsync(productId);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }

    }
}
