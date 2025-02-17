using AutomotiveProducts.Entities;

namespace IAutomotiveProductsApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public List<string> ImageUrl { get; set; }
    }

    public class Products
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
    }
}
