using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waffle_API.Context;
using Waffle_API.Models;

namespace Waffle_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkoutController(WaffleDbContext context) : ControllerBase
    {
        private readonly WaffleDbContext _context = context;

        // GET: Workout
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkout()
        {
            return await _context.Workouts.ToListAsync();
        }

        // GET: Workout/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(uint id)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound("If the issue persists, please contact support.");
            }

            return workout;
        }

        // POST: Workout
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkout), new { id = workout.WorkoutId }, workout);
        }

        // PATCH: Workout/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchWorkout(uint id, Workout workout)
        {
            if (id == 0)
            {
                return BadRequest("If the issue persists, please contact support.");
            }

            workout.WorkoutId = id;
                    
            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound("If the issue persists, please contact support.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated" + workout);
        }

        // DELETE: Workout/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(uint id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return Ok("Deleted:" + workout);
        }

        private bool WorkoutExists(uint id)
        {
            return _context.Workouts.Any(e => e.WorkoutId == id);
        }
    }
}
