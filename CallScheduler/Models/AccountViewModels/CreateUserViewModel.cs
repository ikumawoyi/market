using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CallScheduler.Models.AccountViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string RoleName { get; set; }

        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
       // public string BankCode { get; set; }
       // public int? TeamLeadId { get; set; }
       // public string LeadCode { get; set; }
        public IFormFile File { get; set; }
    }
}
