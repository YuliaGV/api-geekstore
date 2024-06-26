﻿using api_geekstore.Data;
using api_geekstore.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api_geekstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly APIGeekStoreContext _context;

        public OrdersController(APIGeekStoreContext context)
        {
            _context = context;
      
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return Ok(order);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            if (order == null) return NotFound();

            if (order.OrderDetails == null) return BadRequest("Order should have at least one detail");

            await _context.Orders.AddAsync(order);
            await _context.OrderDetails.AddRangeAsync(order.OrderDetails);
           
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", order.Id, order);

        }

        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            if (order == null) return NotFound();
            if (order.Id <= 0) return NotFound();

            var existingOrder = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == order.Id);

            if(existingOrder == null) return NotFound();

            existingOrder.OrderNumber = order.OrderNumber;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.DeliveryDate = order.DeliveryDate;
            existingOrder.ClientId = order.ClientId;

            _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);
            _context.Orders.Update(existingOrder);
            _context.OrderDetails.AddRange(order.OrderDetails);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null) return NotFound();

            _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);
            _context.Orders.Remove(existingOrder);

            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
