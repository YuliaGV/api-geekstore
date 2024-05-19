using api_geekstore.Data;
using api_geekstore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_geekstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly APIGeekStoreContext _context;

        public ClientsController(APIGeekStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null) return NotFound();
            return Ok(client);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", client.Id, client);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Client client)
        {
            var existingClient = await _context.Clients.FindAsync(client.Id);
            if (existingClient == null)
            {
                return NotFound();
            }

            _context.Entry(existingClient).State = EntityState.Detached; 
            _context.Clients.Update(client); 
            await _context.SaveChangesAsync(); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
