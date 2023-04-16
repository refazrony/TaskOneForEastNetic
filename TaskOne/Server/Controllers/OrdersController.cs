using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskOne.Server;
using TaskOne.Shared;

namespace TaskOne.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/GetOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(Int64 id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            // var orders = await _context.Orders.FindAsync(id);


            Orders orders = await _context.Orders
               .Include(p => p.liwindows)
                .ThenInclude(w=>w.liSubElement)
                .FirstOrDefaultAsync(p => p.orderid == id);


          

            




            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.orderid)
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

        // POST: api/Orders/PostOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {


          if (_context.Orders == null)
          {
              return Problem("Entity set 'AppDbContext.Orders'  is null.");
          }

            try
            {
                _context.Orders.Add(orders);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrders", new { id = orders.orderid }, orders);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
           

        }

        // POST: api/Orders/PostOrdersUpdate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrdersUpdate(Orders orders)
        {


            if (_context.Orders == null)
            {
                return Problem("Entity set 'AppDbContext.Orders'  is null.");
            }

            try
            {
                
                _context.Entry(orders).State = EntityState.Modified;

                if (orders.liwindows.Count > 0)
                {
                    foreach (windows item in orders.liwindows)
                    {
                        if (WindoesExists(item.winId))
                        {
                            _context.Entry(item).State = EntityState.Modified;
                        }
                        else {
                            windows winIrem = item as windows;
                            _context.windows.Add(winIrem);
                        }
                    }
                    
                }


                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrders", new { id = orders.orderid }, orders);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
          

        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
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
            return (_context.Orders?.Any(e => e.orderid == id)).GetValueOrDefault();
        }

        private bool WindoesExists(int id)
        {
            return (_context.windows?.Any(e => e.winId == id)).GetValueOrDefault();
        }
    }
}
