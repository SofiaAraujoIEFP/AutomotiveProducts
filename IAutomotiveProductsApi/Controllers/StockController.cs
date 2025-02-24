//using AutomotiveProducts.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//using AutomotiveProducts.Entities;

//namespace IAutomotiveProductsApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValueController : ControllerBase
//    {
//        private readonly BusinessDbContext _businessDbContext;

//        public ValueController(BusinessDbContext businessContext)
//        {
//            _businessDbContext = businessContext;
//        }

//        [HttpGet("/getstock")]
//        public async Task<IActionResult> GetStock()
//        {
//            var taskTable = await _businessDbContext.Stocks.Where(t => t.IsDeleted == false).ToListAsync();

//            if (!taskTable.Any())
//                return NotFound();
//            else
//                return Ok(taskTable);
//        }

//        [HttpGet("/getstock")]
//        public async Task<IActionResult> GetStock(int Id)
//        {
//            var taskTable = await _businessDbContext.Stocks.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id.Equals(Id));

//            if (taskTable is null)
//                return NotFound();
//            else
//                return Ok(taskTable);
//        }

//        [HttpPut("/updatestock")]
//        public async Task<IActionResult> UpdateStock(AutomotiveProducts.Entities.Stock stocks)
//        {
//            //var availableStock = await _businessDbContext.Stocks.FirstOrDefaultAsync(t => t.Id.Equals(stocks.Id));
//            var availableStock = await _businessDbContext.Stocks.Include(s => s.Products).FirstOrDefaultAsync(t => t.Id == stocks.Id);


//            if (availableStock is null)
//            {
//                await _businessDbContext.Stocks.AddAsync(stocks);
//                await _businessDbContext.SaveChangesAsync();
//                return Ok();
//            }

//            availableStock.Products.Quantity = stocks.Products.Quantity;

//            var result = await _businessDbContext.SaveChangesAsync();

//            if (result.Equals(1))
//                return Ok();

//            return BadRequest();
//        }

//        [HttpPut("/savestock")]
//        public async Task<IActionResult> SaveStock(AutomotiveProducts.Entities.Stock stocks)
//        {

//            if (stocks is null)
//                return BadRequest();

//            var availableStock = new AutomotiveProducts.Entities.Stock();
//            availableStock.Products.Quantity = stocks.Products.Quantity;

//            var result = await _businessDbContext.SaveChangesAsync();

//            if (result.Equals(1))
//                return Ok();

//            return BadRequest();
//        }
//    }
//}