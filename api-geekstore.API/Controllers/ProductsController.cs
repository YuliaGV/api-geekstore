using api_geekstore.Data;
using api_geekstore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_geekstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly APIGeekStoreContext _context;

        public ProductsController(APIGeekStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("GetByCategory/{productCategoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            return await _context.Products
                                .Where(p => p.ProductCategoryId == productCategoryId )
                                .ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", product.Id, product);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _context.Entry(existingProduct).State = EntityState.Detached;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound();

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return NoContent();
        }




    }
}
