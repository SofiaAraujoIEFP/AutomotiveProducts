using AutomotiveProducts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IAutomotiveProductsApi.Controllers
{
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

            if (product is null)
                return BadRequest();

            var newProduct = new AutomotiveProducts.Entities.Products();
            newProduct.Title = product.Title;
            newProduct.Description = product.Description;
            newProduct.CostPrice = product.CostPrice;
            newProduct.Category = product.Category;
            newProduct.Supplier = product.Supplier;
            newProduct.SupplierRef = product.SupplierRef;
            newProduct.Quantity = product.Quantity;
            newProduct.SalePrice = product.SalePrice;
            newProduct.IsDeleted = product.IsDeleted;
            newProduct.IsCompleted = product.IsCompleted;

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
            {
                await _businessDbContext.Product.AddAsync(product);
                await _businessDbContext.SaveChangesAsync();
                return Ok();
            }

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