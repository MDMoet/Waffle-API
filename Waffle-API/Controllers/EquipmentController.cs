using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waffle_API.Context;
using Waffle_API.Models;

namespace Waffle_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipmentController(WaffleDbContext context) : ControllerBase
    {
        private readonly WaffleDbContext _context = context;

        // GET: Equipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipment()
        {
            return await _context.Equipment.ToListAsync();
        }

        // GET: Equipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(uint id)
        {
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment == null)
            {
                return NotFound("If the issue persists, please contact support.");
            }

            return equipment;
        }

        // POST: Equipment
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipment), new { id = equipment.EquipmentId }, equipment);
        }

        // PATCH: Equipment/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEquipment(uint id, Equipment equipment)
        {
            if (id == 0)
            {
                return BadRequest("If the issue persists, please contact support.");
            }

            equipment.EquipmentId = id;
                    
            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
                {
                    return NotFound("If the issue persists, please contact support.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated" + equipment);
        }

        // DELETE: Equipment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(uint id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();

            return Ok("Deleted:" + equipment);
        }

        private bool EquipmentExists(uint id)
        {
            return _context.Equipment.Any(e => e.EquipmentId == id);
        }
    }
}
