using Microsoft.AspNetCore.Mvc;
using Refit;
//using IAutomotiveProductsApi.Models;
namespace ApiConsumer
{
    internal interface IWebAPI
    {
        [Get("/getproducts")]
        Task<List<AutomotiveProducts.Entities.Products>> GetProducts();

        [Get("/getproduct")]
        Task<AutomotiveProducts.Entities.Products> GetProduct(int id);

        [Post("/addproducts")]
        Task<HttpResponseMessage> AddProducts(AutomotiveProducts.Entities.Products product);

        [Delete("/deleteproduct")]
        Task<HttpResponseMessage> DeleteProduct(long id);

        [Put("/updateproduct")]
        Task<HttpResponseMessage> Updateproduct([FromBody] AutomotiveProducts.Entities.Products product);

        [Post("/saveproduct")]
        Task<HttpResponseMessage> SaveProduct([FromBody] AutomotiveProducts.Entities.Products product);
    }
}

