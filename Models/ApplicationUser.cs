using Microsoft.AspNetCore.Identity;

namespace WimabEventApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}