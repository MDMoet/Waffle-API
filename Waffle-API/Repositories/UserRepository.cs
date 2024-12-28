using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Waffle_API.Classes;
using Waffle_API.Context;
using Waffle_API.Models;

namespace Waffle_API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(uint id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(uint id);
        Task<bool> UserExistsAsync(uint id);
    }
    public class UserRepository(WaffleDbContext context) : IUserRepository
    {
        private readonly WaffleDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            // Get all users
            return await _context.Users.ToListAsync(); 
        }
        public async Task<User?> GetUserByIdAsync(uint id) {

            // Find the user by ID
            return await _context.Users.FindAsync(id); 
        }
        public async Task AddUserAsync(User user) {

            // Create a new instance of the HashController
            HashController hashController = new();

            // Set the user password to the hashed password
            user.Password = hashController.HashString(user.Password);

            // Set the user's created and updated date
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            // Add the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user) {

            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(uint id) {

            User? user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UserExistsAsync(uint id) { 
            return await _context.Users.FindAsync(id) != null;
        }
    }
}
