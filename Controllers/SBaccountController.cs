using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBAssignment.Models;

namespace SBAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SBaccountController : ControllerBase
    {
        private readonly SBaccountContext _context;

        public SBaccountController(SBaccountContext context)
        {
            _context = context;
        }

        // GET: api/SBaccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SBaccount>>> GetSbaccount()
        {
            return await _context.Sbaccount.ToListAsync();
        }

        // GET: api/SBaccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBaccount>> GetSBaccount(int id)
        {
            var sBaccount = await _context.Sbaccount.FindAsync(id);

            if (sBaccount == null)
            {
                return NotFound();
            }

            return sBaccount;
        }

        // PUT: api/SBaccount/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSBaccount(int id, SBaccount sBaccount)
        {
            if (id != sBaccount.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(sBaccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SBaccountExists(id))
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

        // POST: api/SBaccount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<SBaccount>> PostSBaccount(SBaccount sBaccount)
        //{
        //    _context.Sbaccount.Add(sBaccount);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSBaccount", new { id = sBaccount.CustomerId }, sBaccount);
        //}
        public async Task<ActionResult<SBaccount>> PostSBAccount(SBaccount sBAccount)
        {
            _context.Sbaccount.Add(sBAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSBAccount", new { id = sBAccount.CustomerId }, sBAccount);
        }
        // DELETE: api/SBaccount/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSBaccount(int id)
        {
            var sBaccount = await _context.Sbaccount.FindAsync(id);
            if (sBaccount == null)
            {
                return NotFound();
            }

            _context.Sbaccount.Remove(sBaccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SBaccountExists(int id)
        {
            return _context.Sbaccount.Any(e => e.CustomerId == id);
        }
    }
}
