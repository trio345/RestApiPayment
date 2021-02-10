using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiTO.Models;
using RestApiTO.Wrapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PaymentContext _context;

        public CustomersController(PaymentContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var response = await _context.Customers.ToListAsync();

            return Ok(new GeneralResponseModel<List<Customers>>(response));
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var customers = await _context.Customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(new GeneralResponseModel<Customers>(customers));
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, [FromBody] RequestModel<AttributeModel<Customers>> data)
        {
            var customer = await _context.Customers.FindAsync(id);
            var dataCustomers = data.Data.Attributes;
            if (customer == null)
            {
                return NotFound();
            }
            else if (!(dataCustomers.Username == customer.Username))
            {
                return BadRequest();
            }

            _context.Entry(dataCustomers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCustomers([FromBody] RequestModel<AttributeModel<Customers>> data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Customers.Add(data.Data.Attributes);


            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.Data.Attributes.CustomerId }, data);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
