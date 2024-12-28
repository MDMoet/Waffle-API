using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waffle_API.Classes;
using Waffle_API.Models;
using Waffle_API.Repositories;

namespace Waffle_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        
        // GET: User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUserAsync()
        {
            var user = await _userRepository.GetAllUsersAsync();
            
            if(!user.Any())
            {
                return BadRequest("If this issue persists, contact support.");
            }

            return Ok(user.Count());
        }

        // GET: User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(uint id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return BadRequest("If this issue persists, contact support.");
            }

            return Ok(user);
        }

        // POST: User
        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("If this issue persists, contact support.");
            }

            await _userRepository.AddUserAsync(user);
            return CreatedAtAction("GetUserById", new { id = user.UserId }, user);
        }

        // PATCH: User/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);

            if (user == null)
            {
                return BadRequest("If this issue persists, contact support.");
            }

            return AcceptedAtAction("GetUserById", new { id = user.UserId }, user);
        }

        // DELETE: User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(uint id)
        {
            bool exists = await _userRepository.UserExistsAsync(id);

            if (exists == false)
            {
                return BadRequest("If this issue persists, contact support.");
            }

            return Ok(id);
        }
    }
}
