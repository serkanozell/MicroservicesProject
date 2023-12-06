using System.ComponentModel.DataAnnotations;

namespace Freecourse.Web.Models
{
    public class SignInInput
    {
        [Required]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
