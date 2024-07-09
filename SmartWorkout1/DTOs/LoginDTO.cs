using SmartWorkout1.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.DTOs
{
    public class LoginDTO
    {
        [EmailAddress (ErrorMessage="Email address is required!")]
        [Required (ErrorMessage ="Email address is required!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
    }
}
