using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskOne.Server;
using TaskOne.Shared;

namespace TaskOne.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class windowsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public windowsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/windows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<windows>>> Getwindows()
        {
          if (_context.windows == null)
          {
              return NotFound();
          }
            return await _context.windows.ToListAsync();
        }

        // GET: api/windows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<windows>> Getwindows(int id)
        {
          if (_context.windows == null)
          {
              return NotFound();
          }
            var windows = await _context.windows.FindAsync(id);

            if (windows == null)
            {
                return NotFound();
            }

            return windows;
        }

        // PUT: api/windows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putwindows(int id, windows windows)
        {
            if (id != windows.winId)
            {
                return BadRequest();
            }

            _context.Entry(windows).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!windowsExists(id))
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

        // POST: api/windows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<windows>> Postwindows(List<windows> windows)
        {
          if (_context.windows == null)
          {
              return Problem("Entity set 'AppDbContext.windows'  is null.");
          }
           // _context.windows.Add(windows);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getwindows",windows);
        }

        // DELETE: api/windows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletewindows(int id)
        {
            if (_context.windows == null)
            {
                return NotFound();
            }
            var windows = await _context.windows.FindAsync(id);
            if (windows == null)
            {
                return NotFound();
            }

            _context.windows.Remove(windows);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool windowsExists(int id)
        {
            return (_context.windows?.Any(e => e.winId == id)).GetValueOrDefault();
        }
    }
}
