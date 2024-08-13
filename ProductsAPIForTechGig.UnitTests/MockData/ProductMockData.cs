using ProductsAPIForTechGig.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAPIForTechGig.UnitTests.MockData
{
    public static class ProductMockData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new(){ 
                    Id = 1,ProductName="Laptop",ProductDescription="HP Laptop with core 11",Prize=100000,Category="Electronic"
                },
                 new(){
                    Id = 2,ProductName="Washing Machine",ProductDescription="LG Fully automatic fron loaded",Prize=80000,Category="Home Appliance"
                },
                  new(){
                    Id = 3,ProductName="Sneakers",ProductDescription="Nike sports shoes with spikes",Prize=3000,Category="Fashion"
                },

            };
        }
        public static List<Product> EmptyProductsList()
        {
            return new List<Product>();
        }
        public static Product Product()
        {
            return new Product()
            {
                Id = 1,
                ProductName="Laptop",
                ProductDescription= "LG Fully automatic fron loaded",
                Prize=80000,
                Category = "Home Appliance"

            };



        }
        public static Product EmptyProduct()
        {
            return null;
        }
        public static Product AddProduct()
        {
            return new Product()
            {
               ProductName="Laptop",
                ProductDescription = "LG Fully automatic fron loaded",
                Prize = 80000,
                Category = "Home Appliance"

            };
        }

    }
}
