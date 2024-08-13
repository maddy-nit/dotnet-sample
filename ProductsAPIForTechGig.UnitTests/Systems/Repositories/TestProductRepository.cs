using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProductsAPIForTechGig.Data;
using ProductsAPIForTechGig.Models.Domain;
using ProductsAPIForTechGig.Repository;
using ProductsAPIForTechGig.UnitTests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductsAPIForTechGig.UnitTests.Systems.Repositories
{
    public class TestProductRepository : IDisposable
    {
        private readonly ProductDbContext context;

        public TestProductRepository()
        {
            var options = new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new ProductDbContext(options);
            context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
        [Fact]
        public async Task GetProductssAsync_ShouldReturnProductList()
        {
            //Arrange
            context.Products.AddRange(ProductMockData.GetProducts());
            context.SaveChanges();
            var sut = new ProductRepository(context);
            //Act
            var result = await sut.GetProductsAsync();
            //Assert
            result.Should().HaveCount(ProductMockData.GetProducts().Count);
        }
        [Fact]
        public async Task AddProductAsync_ShouldReturnAddProduct()
        {
            //Arrange
            context.Products.AddRange(ProductMockData.GetProducts());
            context.SaveChanges();
            var sut = new ProductRepository(context);
            Product prod = ProductMockData.AddProduct();
            //Act
            var result = await sut.AddProductAsync(prod);
            //Assert
            result.Should().BeOfType<Product>();
        }


        [Fact]
        public async Task DeleteProductAsync_ShouldReturnDeletedProduct()
        {
            //Arrange
            context.Products.AddRange(ProductMockData.GetProducts());
            context.SaveChanges();
            var sut = new ProductRepository(context);
            //Employee emp = EmployeeMockData.AddEmployee();
            //Act
            var result = await sut.DeleteProductAsync(3);
            //Assert
            result.Should().BeOfType<Product>();
        }

    }
}
