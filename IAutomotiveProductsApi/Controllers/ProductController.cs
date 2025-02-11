using AutomotiveProducts.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutomotiveProducts.Entities;
using Microsoft.EntityFrameworkCore;
using Products.Shared.Models;

namespace IAutomotiveProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly BusinessDbContext _businessDbContext;

        public ProductController (BusinessDbContext businessDbContext)
        {
            _businessDbContext = businessDbContext;
        }

        [HttpGet("/getproducts")]
        public async Task<List<AutomotiveProducts.Entities.Products>> GetProducts()
        {
            return await _businessDbContext.Product.ToListAsync();
        }

        [HttpPost("/saveproducts")]
        public async Task<ActionResult> SaveProducts(AutomotiveProducts.Entities.Products product)
        {
            await _businessDbContext.Product.AddAsync(product);
            var result = await _businessDbContext.SaveChangesAsync();
            if (result.Equals(1))
                return Ok();
            return BadRequest(result);
        }
        [HttpPut("/updateproducts")]
        public async Task<IActionResult> UpdateProducts(AutomotiveProducts.Entities.Products product)
        {
            var oldProduct = await _businessDbContext.Product.FirstOrDefaultAsync(s => s.Id.Equals(product.Id));
            if (oldProduct is null)

            { await _businessDbContext.Product.AddAsync(product); }
            else
            {
                oldProduct.Title = product.Title;
                oldProduct.Category = product.Category;
                oldProduct.Description = product.Description;
                oldProduct.ImageUrl = product.ImageUrl;
            }

            var result = await _businessDbContext.SaveChangesAsync();
            if (result.Equals(1))
                return Ok();
            return BadRequest(result);
        }
        [HttpGet("/getproduct/{id}")]
        public async Task<AutomotiveProducts.Entities.Products?> GetProduct(int id)
        {
            var product = await _businessDbContext.Product.FirstOrDefaultAsync(s => s.Id.Equals(id));
            if (product is null)
                return null;
            return product;
        }
    }
}

