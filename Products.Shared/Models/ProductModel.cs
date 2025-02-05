using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Shared.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrl { get; set; }
    }

    public class ProductResponse
    {
        public List<ProductModel> ProductsModels { get; set; }
    }
}
