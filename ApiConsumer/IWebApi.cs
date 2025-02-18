using Microsoft.AspNetCore.Mvc;
using Refit;
using IAutomotiveProductsApi.Models;
namespace ApiConsumer
{
    internal interface IWebAPI
    {
        [Get("/getproducts")]
        Task<List<ProductModel>> GetProducts();

        [Get("/getproduct")]
        Task<ProductModel> GetProduct(int id);

        [Post("/addproducts")]
        Task<HttpResponseMessage> AddProducts([FromBody] ProductModel productModel);

        [Delete("/deleteproduct")]
        Task<HttpResponseMessage> DeleteProduct(long id);

        [Put("/updateproduct")]
        Task<HttpResponseMessage> UpdateTodo([FromBody] ProductModel productModel);
    }
}

