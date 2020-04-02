using System.ComponentModel.DataAnnotations;

namespace CallScheduler.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        // [Required]
        [EmailAddress]
        public string Email { get; set; }
       // public string Latitude { get; set; }
       // public string Longitude { get; set; }

        // [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
