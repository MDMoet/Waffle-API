using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waffle_API.Context;
using Waffle_API.Models;

namespace Waffle_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeController(WaffleDbContext context) : ControllerBase
    {
        private readonly WaffleDbContext _context = context;

        // GET: Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Type>>> GetTypes()
        {
            return await _context.Types.ToListAsync();
        }

        // GET: Type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Type>> GetType(uint id)
        {
            var type = await _context.Types.FindAsync(id);

            if (type == null)
            {
                return NotFound("If the issue persists, please contact support.");
            }

            return type;
        }

        // POST: Type
        [HttpPost]
        public async Task<ActionResult<Models.Type>> PostType(Models.Type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Types.Add(type);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetType), new { id = type.TypeId }, type);
        }

        // PATCH: Types/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTypes(uint id, Models.Type type)
        {
            if (id == 0)
            {
                return BadRequest("If the issue persists, please contact support.");
            }

            type.TypeId = id;
                    
            _context.Entry(type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
                {
                    return NotFound("If the issue persists, please contact support.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated" + type);
        }

        // DELETE: Types/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypes(uint id)
        {
            var type = await _context.Types.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            _context.Types.Remove(type);
            await _context.SaveChangesAsync();

            return Ok("Deleted:" + type);
        }

        private bool TypeExists(uint id)
        {
            return _context.Types.Any(e => e.TypeId == id);
        }
    }
}
