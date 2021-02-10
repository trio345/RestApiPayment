using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiTO.Models;
using RestApiTO.Wrapper;

namespace RestApiTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PaymentContext _context;

        public OrdersController(PaymentContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            var response = await _context.Orders.ToListAsync();
            return Ok(new GeneralResponseModel<List<Orders>>(response));
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostOrders([FromBody] RequestModel<AttributeModel<OrderRequestModel<Order_items>>> orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = orders.Data.Attributes.Order_detail;
            var order = await _context.Orders.FirstAsync(x => x.CustomerId.Equals(orders.Data.Attributes.User_id));
            /*_context.*/
            return Ok(order);          
            /*await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = orders.Id }, orders);*/
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
