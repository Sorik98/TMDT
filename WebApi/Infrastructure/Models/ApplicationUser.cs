using Microsoft.AspNetCore.Identity;

namespace WebApi.Infrastructure.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public string Address { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }

    }
}
