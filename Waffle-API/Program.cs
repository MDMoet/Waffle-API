using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Waffle_API.Context;
using Waffle_API.Repositories; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the DbContext with the DI container
builder.Services.AddDbContext<WaffleDbContext>(options =>
    options.UseMySql("server=77.251.5.254;database=waffle_workout_db;user id=ps250444;password=G7!rE2@9wN^zX3#jU1*QkT5&fL0$", ServerVersion.Parse("10.4.32-mariadb")));

// Repository registration
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Add the password hasher to the DI container
builder.Services.AddSingleton<IPasswordHasher<string>, PasswordHasher<string>>();

// Add services for API documentation (Swagger, OpenAPI)
builder.Services.AddEndpointsApiExplorer();

// Build the application
var app = builder.Build();

// Middleware for HTTPS redirection, authorization, and cookie policy
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCookiePolicy();

// Map controllers (routes)
app.MapControllers();

// Run the application
app.Run();
