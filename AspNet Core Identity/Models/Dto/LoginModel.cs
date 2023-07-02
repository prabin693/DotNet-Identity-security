using System.ComponentModel.DataAnnotations;

namespace AspNet_Core_Identity.Models.Dto
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
