using Microsoft.AspNetCore.Identity;

namespace JWTAuthentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}