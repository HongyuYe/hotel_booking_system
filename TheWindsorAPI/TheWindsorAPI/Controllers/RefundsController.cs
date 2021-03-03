using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWindsorAPI.Models;

namespace TheWindsorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundsController : ControllerBase
    {
        private readonly RefundContext _context;

        public RefundsController(RefundContext context)
        {
            _context = context;
            if (!_context.Refunds.Any())
            {
                // The table is empty
                Refund initial_Item = new Refund { reference = "0", isRefund = false, amount = "1"};
                _context.Refunds.Add(initial_Item);
                _context.SaveChangesAsync();
                CreatedAtAction(nameof(GetRefund), new { id = initial_Item.refundId }, initial_Item);
            }
        }

        // GET: api/Refunds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Refund>>> GetRefunds()
        {
            return await _context.Refunds.ToListAsync();
        }

        // GET: api/Refunds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Refund>> GetRefund(int id)
        {
            var refund = await _context.Refunds.FindAsync(id);

            if (refund == null)
            {
                return NotFound();
            }

            return refund;
        }

        // PUT: api/Refunds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefund(int id, Refund refund)
        {
            if (id != refund.refundId)
            {
                return BadRequest();
            }

            _context.Entry(refund).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefundExists(id))
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

        // POST: api/Refunds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Refund>> PostRefund(Refund refund)
        {
            _context.Refunds.Add(refund);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRefund", new { id = refund.refundId }, refund);
            return CreatedAtAction(nameof(GetRefund), new { id = refund.refundId }, refund);
        }

        // DELETE: api/Refunds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefund(int id)
        {
            var refund = await _context.Refunds.FindAsync(id);
            if (refund == null)
            {
                return NotFound();
            }

            _context.Refunds.Remove(refund);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RefundExists(int id)
        {
            return _context.Refunds.Any(e => e.refundId == id);
        }
    }
}
