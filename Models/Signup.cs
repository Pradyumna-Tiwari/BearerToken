using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BererTokenPartTwo.Models
{
    public class Signup
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
