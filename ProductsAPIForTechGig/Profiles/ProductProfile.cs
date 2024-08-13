using AutoMapper;
using ProductsAPIForTechGig.Models;
using ProductsAPIForTechGig.Models.Domain;

namespace ProductsAPIForTechGig.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
        }
    }
}
