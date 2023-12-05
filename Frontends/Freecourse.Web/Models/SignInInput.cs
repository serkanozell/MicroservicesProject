using System.ComponentModel.DataAnnotations;

namespace Freecourse.Web.Models
{
    public class SignInInput
    {
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
