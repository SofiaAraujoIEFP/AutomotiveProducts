using AutomotiveProducts.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutomotiveProducts.Entities;
using Microsoft.EntityFrameworkCore;
using Products.Shared.Models;

namespace IAutomotiveProductsApi.Controllers
{
    //    [Route("api/[controller]")]
    //    [ApiController]
    //    public class ProductController : ControllerBase
    //    {
    //        protected readonly BusinessDbContext _businessDbContext;

    //        public ProductController (BusinessDbContext businessDbContext)
    //        {
    //            _businessDbContext = businessDbContext;
    //        }

    //        [HttpGet("/getproducts")]
    //        public async Task<List<AutomotiveProducts.Entities.Products>> GetProducts()
    //        {
    //            return await _businessDbContext.Product.ToListAsync();
    //        }

    //        [HttpPost("/saveproducts")]
    //        public async Task<ActionResult> SaveProducts(AutomotiveProducts.Entities.Products product)
    //        {
    //            await _businessDbContext.Product.AddAsync(product);
    //            var result = await _businessDbContext.SaveChangesAsync();
    //            if (result.Equals(1))
    //                return Ok();
    //            return BadRequest(result);
    //        }
    //        [HttpPut("/updateproducts")]
    //        public async Task<IActionResult> UpdateProducts(AutomotiveProducts.Entities.Products product)
    //        {
    //            var oldProduct = await _businessDbContext.Product.FirstOrDefaultAsync(s => s.Id.Equals(product.Id));
    //            if (oldProduct is null)

    //            { await _businessDbContext.Product.AddAsync(product); }
    //            else
    //            {
    //                oldProduct.Title = product.Title;
    //                oldProduct.Category = product.Category;
    //                oldProduct.Description = product.Description;
    //            }

    //            var result = await _businessDbContext.SaveChangesAsync();
    //            if (result.Equals(1))
    //                return Ok();
    //            return BadRequest(result);
    //        }
    //        [HttpGet("/getproduct/{id}")]
    //        public async Task<AutomotiveProducts.Entities.Products?> GetProduct(int id)
    //        {
    //            var product = await _businessDbContext.Product.FirstOrDefaultAsync(s => s.Id.Equals(id));
    //            if (product is null)
    //                return null;
    //            return product;
    //        }
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly BusinessDbContext _businessDbContext;

        public ValuesController(BusinessDbContext businessContext)
        {
            _businessDbContext = businessContext;
        }

        [HttpGet("/getproducts")]
        public async Task<IActionResult> GetProducts()
        {
            var taskTable = await _businessDbContext.Product.Where(t => t.IsDeleted == false).ToListAsync();

            if (!taskTable.Any())
                return NotFound();
            else
                return Ok(taskTable);
        }

        [HttpGet("/getproduct")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var taskTable = await _businessDbContext.Product.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id.Equals(Id));

            if (taskTable is null)
                return NotFound();
            else
                return Ok(taskTable);
        }

        [HttpPost("/addproducts")]
        public async Task<IActionResult> AddProducts(AutomotiveProducts.Entities.Products product)
        {
            var oldproduct = await _businessDbContext.Product.FirstOrDefaultAsync(t => t.Id.Equals(product.Id));

            if (product is not null)
                return BadRequest();

            var newProduct = new AutomotiveProducts.Entities.Products();
            newProduct.Title = product.Title;
            newProduct.Description = product.Description;
          

            _businessDbContext.Product.Add(newProduct);

            var result = await _businessDbContext.SaveChangesAsync();

            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("/deleteproduct")]
        public async Task<ActionResult> DeleteProduct(long Id)
        {
            var product = await _businessDbContext.Product.FirstOrDefaultAsync(t => t.Id.Equals(Id));

            if (product is null)
                return BadRequest();

            product.IsDeleted = true;

            var result = await _businessDbContext.SaveChangesAsync();

            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpPut("/updateproduct")]
        public async Task<IActionResult> Updateproduct(AutomotiveProducts.Entities.Products product)
        {
            var newProduct = await _businessDbContext.Product.FirstOrDefaultAsync(t => t.Id.Equals(product.Id));

                if (newProduct is null)
                return BadRequest();

            newProduct.Title = product.Title;
            newProduct.Description = product.Description;
            newProduct.Category = product.Category;
            newProduct.CostPrice = product.CostPrice;
            newProduct.Supplier = product.Supplier;
            newProduct.SupplierRef = product.SupplierRef;
            newProduct.Quantity = product.Quantity;

            var result = await _businessDbContext.SaveChangesAsync();

            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpPut("/saveproduct")]
        public async Task<IActionResult> SaveProduct(AutomotiveProducts.Entities.Products product)
        {

            if (product is null)
                return BadRequest();

            var newProduct = new AutomotiveProducts.Entities.Products();
            newProduct.Title = product.Title;
            newProduct.Description = product.Description;
            newProduct.Category = product.Category;
            newProduct.CostPrice = product.CostPrice;
            newProduct.Supplier = product.Supplier;
            newProduct.SupplierRef = product.SupplierRef;
            newProduct.Quantity = product.Quantity;

            var result = await _businessDbContext.SaveChangesAsync();

            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }
    }
}