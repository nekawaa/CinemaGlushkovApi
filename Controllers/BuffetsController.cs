using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaGlushkovApi.Models;

namespace CinemaGlushkovApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuffetsController : ControllerBase
    {
        private readonly CinemaGlushkovContext _context;

        public BuffetsController(CinemaGlushkovContext context)
        {
            _context = context;
        }

        // GET: api/Buffets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buffet>>> GetBuffets()
        {
            return await _context.Buffets.ToListAsync();
        }

        // GET: api/Buffets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buffet>> GetBuffet(int id)
        {
            var buffet = await _context.Buffets.FindAsync(id);

            if (buffet == null)
            {
                return NotFound();
            }

            return buffet;
        }

        // PUT: api/Buffets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuffet(int id, Buffet buffet)
        {
            if (id != buffet.IdProduct)
            {
                return BadRequest();
            }

            _context.Entry(buffet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuffetExists(id))
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

        // POST: api/Buffets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buffet>> PostBuffet(Buffet buffet)
        {
            _context.Buffets.Add(buffet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuffet", new { id = buffet.IdProduct }, buffet);
        }

        // DELETE: api/Buffets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuffet(int id)
        {
            var buffet = await _context.Buffets.FindAsync(id);
            if (buffet == null)
            {
                return NotFound();
            }

            _context.Buffets.Remove(buffet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuffetExists(int id)
        {
            return _context.Buffets.Any(e => e.IdProduct == id);
        }
    }
}
