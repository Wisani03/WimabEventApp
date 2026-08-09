using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WimabEventApp.Models;

namespace WimabEventApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                return BadRequest(new
                {
                    message = "Full name is required."
                });
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new
                {
                    message = "Email address is required."
                });
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new
                {
                    message = "Password is required."
                });
            }

            
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return Conflict(new
                {
                    message = "An account with this email address already exists."
                });
            }

            // Create a new Wimab user
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName
            };

            // Let ASP.NET Identity securely hash and store the password
            var result = await _userManager.CreateAsync(user, request.Password);

            
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(error => error.Description);

                return BadRequest(new
                {
                    message = "Account could not be created.",
                    errors
                });
            }

            return Ok(new
            {
                message = "Account created successfully!",
                userId = user.Id,
                fullName = user.FullName,
                email = user.Email
            });
        }
    }

    
    public class RegisterRequest
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}