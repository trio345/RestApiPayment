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
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentContext _context;

        public PaymentsController(PaymentContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult> GetPayments()
        {
            var response = await _context.Payments.ToListAsync();
            return Ok(new GeneralResponseModel<List<Payments>>(response));
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPayments(int id)
        {
            var payments = await _context.Payments.FindAsync(id);

            if (payments == null)
            {
                return NotFound();
            }

            return Ok(new GeneralResponseModel<Payments>(payments));
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayments(int id, Payments payments)
        {
            if (id != payments.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(payments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentsExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payments>> PostPayments([FromBody] RequestModel<AttributeModel<Payments>> request)
        {
            var payment = request.Data.Attributes;

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayments", new { id = payment.PaymentId }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayments(int id)
        {
            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentId == id);
        }
    }
}
