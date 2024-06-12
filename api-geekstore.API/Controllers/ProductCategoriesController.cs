using api_geekstore.Data;
using api_geekstore.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_geekstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly APIGeekStoreContext _context;

        public ProductCategoriesController(APIGeekStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> Get()
        {
            return  await _context.ProductCategories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(c => c.Id == id);
            if (productCategory == null) return NotFound();
            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCategory productCategory)
        {
            await _context.ProductCategories.AddAsync(productCategory);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", productCategory.Id, productCategory);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductCategory productCategory)
        {
            var existingCategory = await _context.ProductCategories.FindAsync(productCategory.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            _context.Entry(existingCategory).State = EntityState.Detached;
            _context.ProductCategories.Update(productCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategory = await _context.ProductCategories.FindAsync(id);
            if (existingCategory == null)
                return NotFound();

            _context.ProductCategories.Remove(existingCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
