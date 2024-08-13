namespace ProductsAPIForTechGig.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Prize { get; set; }
        public string Category { get; set; }
        public string  ProductDescription { get; set; }
    }
}
