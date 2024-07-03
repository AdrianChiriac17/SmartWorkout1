using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.DTOs
{
    public class ExcerciseDTO
    {
        [Required (ErrorMessage ="Description cannot be empty!")]   
        public string Description { get; set; }

        [Required (ErrorMessage ="Type cannot be empty!")]
        public string Type { get; set; }
    }
}
