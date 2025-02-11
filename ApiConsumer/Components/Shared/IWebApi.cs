using Microsoft.AspNetCore.Mvc;
using Products.Shared.Models;
using Refit;
namespace ApiConsumer.Components.Shared
{
    internal interface IWebAPI
    {
        [Get("/getproducts")]
        Task<List<AutomotiveProducts.Entities.Products>> GetProducts();

        [Post("/saveproducts")]
        Task<HttpResponseMessage> SaveProducts([FromBody] Product product);

        [Put("/updateproducts")]
        Task<HttpResponseMessage> UpdateProducts([FromBody] Product product);

        [Get("/getproduct/{id}")]
        Task<AutomotiveProducts.Entities.Products> GetProduct(int id);
    }
}

