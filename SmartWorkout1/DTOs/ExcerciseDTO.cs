using SmartWorkout1.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.DTOs
{
    public class ExcerciseDTO
    {
        public int? Id { get; set; }


        [Required(ErrorMessage = "A description is required!")]
        [StringLength(50, ErrorMessage = "Description must be up to 50 characters long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A type is required!")]
        public string Type { get; set; }

        public bool Exist { get; set; } = true;

        [Required]
        public string ImageURL { get; set; }

        public static ExcerciseDTO FromEntity(Excercise excercise)
        {
            return new ExcerciseDTO
            {
                Description = excercise.Description,
                Type = excercise.Type,
                ImageURL=excercise.ImageURL,
            };
        }
    }
}
