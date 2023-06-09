using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoolatyMVC.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Village { get; set; }
        public string? Thana { get; set; }
        public string? PostalCode { get; set; }
        public string? Division { get; set; }
    }
}
