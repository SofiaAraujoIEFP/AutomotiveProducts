using AutomotiveProducts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutomotiveProducts.Entities;

namespace IAutomotiveProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly BusinessDbContext _businessDbContext;

        public ValueController(BusinessDbContext businessContext)
        {
            _businessDbContext = businessContext;
        }

        [HttpGet("/getstock")]
        public async Task<IActionResult> GetStock()
        {
            var taskTable = await _businessDbContext.Stocks.Where(t => t.IsDeleted == false).ToListAsync();

            if (!taskTable.Any())
                return NotFound();
            else
                return Ok(taskTable);
        }

        [HttpGet("/getstock/{Id}")]
        public async Task<IActionResult> GetStock(int Id)
        {
            var taskTable = await _businessDbContext.Stocks.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id.Equals(Id));

            if (taskTable is null)
                return NotFound();
            else
                return Ok(taskTable);
        }

        [HttpPut("/updatestock")]
        public async Task<IActionResult> UpdateStock(AutomotiveProducts.Entities.Stock stocks)
        {
            //var availableStock = await _businessDbContext.Stocks.FirstOrDefaultAsync(t => t.Id.Equals(stocks.Id));
            var availableStock = await _businessDbContext.Stocks.Include(s => s.Products).FirstOrDefaultAsync(t => t.Id == stocks.Id);


            if (availableStock is null)
            {
                await _businessDbContext.Stocks.AddAsync(stocks);
                await _businessDbContext.SaveChangesAsync();
                return Ok();
            }

            availableStock.Products.Quantity = stocks.Products.Quantity;

            var result = await _businessDbContext.SaveChangesAsync();

            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpPut("/savestock")]
        public async Task<IActionResult> SaveStock(AutomotiveProducts.Entities.Stock stocks)
        {

            if (stocks is null)
                return BadRequest();

            var availableStock = new AutomotiveProducts.Entities.Stock();
            availableStock.Products.Quantity = stocks.Products.Quantity;

            var result = await _businessDbContext.SaveChangesAsync();

            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpPut("/decreasequantity")]
        public async Task<IActionResult> DecreaseQuantity(long productId, long sentQuantity)
        {
            if (sentQuantity <= 0)
                return BadRequest("The decrease quantity must be more than zero.");

            var availableStock = await _businessDbContext.Stocks
                                    .Include(s => s.Products)
                                    .FirstOrDefaultAsync(s => s.ProductId == productId && !s.IsDeleted);

            if (availableStock is null)
                return NotFound("The product was not found in stock.");

            var quantityAvailable = availableStock.QuantityReceived - availableStock.QuantitySent;
            if (quantityAvailable < sentQuantity)
                return BadRequest("Quantity is not enough.");

            availableStock.Decrease(sentQuantity);

            var result = await _businessDbContext.SaveChangesAsync();
            if (result > 0)
                return Ok("Quantaty sucessfully decreased.");

            return BadRequest("Error decreasing the quantity.");
        }

        [HttpPut("/increasequantity")]
        public async Task<IActionResult> IncreaseQuantity(long productId, long receivedQuantity)
        {
            if (receivedQuantity <= 0)
                return BadRequest("The increase quantity must be more than zero.");

            // Buscar o estoque do produto especificado
            var availableStock = await _businessDbContext.Stocks
                                    .Include(s => s.Products)
                                    .FirstOrDefaultAsync(s => s.ProductId == productId && !s.IsDeleted);

            // Verificar se o estoque foi encontrado
            if (availableStock is null)
                return NotFound("The product was not found in stock.");

            // Verificar se a quantidade é suficiente para a diminuição
            var quantityAvailable = availableStock.QuantityReceived - availableStock.QuantitySent;
            if (quantityAvailable < receivedQuantity)
                return BadRequest("Quantity is not enough.");

            // Diminuir a quantidade usando o método Decrease
            availableStock.Increase(receivedQuantity);

            // Salvar as alterações no banco de dados
            var result = await _businessDbContext.SaveChangesAsync();
            if (result > 0)
                return Ok("Quantity sucessfully increased.");

            return BadRequest("Error increasing the quantity.");
        }
    }
}