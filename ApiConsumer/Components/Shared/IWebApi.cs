using Microsoft.AspNetCore.Mvc;
using Products.Shared.Models;
using Refit;
namespace ApiConsumer.Components.Shared

{
        internal interface IWebAPI
        {
            [Get("/getproducts")]
            Task<List<ProductModel>> GetProducts();
            [Get("/getproduct")]
            Task<ProductModel> GetProduct(int id);
            [Post("/addproduct")]
            Task<HttpResponseMessage> AddProduct([FromBody] ProductModel productModel);
            [Delete("/deletetodo")]
            Task<HttpResponseMessage> DeleteProduct(long id);
            [Put("/updateproduct")]
            Task<HttpResponseMessage> UpdateProduct([FromBody] ProductModel productModel);

        }
    }

