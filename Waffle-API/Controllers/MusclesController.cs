using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waffle_API.Context;
using Waffle_API.Models;

namespace Waffle_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MuscleController(WaffleDbContext context) : ControllerBase
    {
        private readonly WaffleDbContext _context = context;

        // GET: Muscle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Muscle>>> GetMuscle()
        {
            return await _context.Muscles.ToListAsync();
        }

        // GET: Muscle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Muscle>> GetMuscle(uint id)
        {
            var muscle = await _context.Muscles.FindAsync(id);

            if (muscle == null)
            {
                return NotFound("If the issue persists, please contact support.");
            }

            return muscle;
        }

        // POST: Muscle
        [HttpPost]
        public async Task<ActionResult<Muscle>> PostMuscle(Muscle muscle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Muscles.Add(muscle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMuscle), new { id = muscle.MuscleId }, muscle);
        }

        // PATCH: Muscle/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMuscle(uint id, Muscle muscle)
        {
            if (id == 0)
            {
                return BadRequest("If the issue persists, please contact support.");
            }

            muscle.MuscleId = id;
                    
            _context.Entry(muscle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuscleExists(id))
                {
                    return NotFound("If the issue persists, please contact support.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated" + muscle);
        }

        // DELETE: Muscle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuscle(uint id)
        {
            var muscle = await _context.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }

            _context.Muscles.Remove(muscle);
            await _context.SaveChangesAsync();

            return Ok("Deleted:" + muscle);
        }

        private bool MuscleExists(uint id)
        {
            return _context.Muscles.Any(e => e.MuscleId == id);
        }
    }
}
