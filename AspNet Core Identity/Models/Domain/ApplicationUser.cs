using Microsoft.AspNetCore.Identity;

namespace AspNet_Core_Identity.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string? ProfilPicture { get; set; }
    }
}
