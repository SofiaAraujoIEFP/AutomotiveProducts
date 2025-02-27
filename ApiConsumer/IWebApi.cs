using Microsoft.AspNetCore.Mvc;
using Refit;
using IAutomotiveProductsApi.Controllers;
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

        [Get("/getstock")]
        Task<List<AutomotiveProducts.Entities.Stock>> GetStock();

        [Get("/getstocks")]
        Task<AutomotiveProducts.Entities.Stock> GetStocks(long id);

        [Put("/updatestock")]
        Task<HttpResponseMessage> UpdateStock([FromBody] AutomotiveProducts.Entities.Stock stocks);

        [Post("/savestock")]
        Task<HttpResponseMessage> GetStock([FromBody] AutomotiveProducts.Entities.Stock stocks);

        [Put("/increase")]
        Task<HttpResponseMessage> IncreaseQuantity(long id, [FromBody] long receivedQuantity);

        [Put("/decrease")]
        Task<HttpResponseMessage> DecreaseQuantity(long id, [FromBody] long sentQuantity);

        [Post("/getquantity")]
        Task<List<AutomotiveProducts.Entities.Stock>> GetQuantity([FromBody] AutomotiveProducts.Entities.Stock stocks);

        //[Put("/getstockbyproductid")]
        //Task<AutomotiveProducts.Entities.Stock> GetStockByProductId(long id);
    }
}

