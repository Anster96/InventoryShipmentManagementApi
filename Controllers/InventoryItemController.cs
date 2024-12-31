using InventoryShipmentManagementApi.DB;
using InventoryShipmentManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryShipmentManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryItemController : Controller
    {
        private readonly InventoryDbContext _context;

        public InventoryItemController(InventoryDbContext context) 
        { 
            _context = context; 
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventoryItems() 
        { 
            return await _context.InventoryItems.ToListAsync(); 
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<InventoryItem>> GetInventoryItem(int id) 
        { 
            var item = await _context.InventoryItems.FindAsync(id); 
            if (item == null) 
            { 
                return NotFound(); 
            } 
            return item; 
        }

        [HttpPost] 
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem item) 
        { 
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync(); 
            return CreatedAtAction(nameof(GetInventoryItem), new { id = item.Id }, item); 
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> PutInventoryItem(int id, InventoryItem item) 
        { 
            if (id != item.Id) 
            { 
                return BadRequest(); 
            } 
            _context.Entry(item).State = EntityState.Modified; 
            try 
            { 
                await _context.SaveChangesAsync(); 
            } 
            catch (DbUpdateConcurrencyException) 
            { 
                if (!_context.InventoryItems.Any(e => e.Id == id)) 
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

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteInventoryItem(int id) 
        { 
            var item = await _context.InventoryItems.FindAsync(id); 
            if (item == null) 
            { 
                return NotFound(); 
            } 
            _context.InventoryItems.Remove(item); 
            await _context.SaveChangesAsync(); 
            return NoContent(); 
        }

    }
}
