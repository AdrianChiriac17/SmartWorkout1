using SmartWorkout1.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.DTOs
{
    public class ExcerciseLogDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A number of reps is required!")]
        [Range(1, 20, ErrorMessage = "Value for Reps must be between 1 and 20.")]
        public int Reps { get; set; }

        [Required(ErrorMessage = "A duration is required!")]
        [Range(30, 300, ErrorMessage = "Duration must be between 30 and 300 seconds")]
        public int Duration { get; set; }

        public int ExcerciseId { get; set; }

        public int WorkoutId { get; set; }

        public static ExcerciseLogDTO FromEntity(ExcerciseLog excerciselog)
        {
            return new ExcerciseLogDTO
            {
                Reps = excerciselog.Reps,
                Duration = excerciselog.Duration,
                ExcerciseId=excerciselog.ExcerciseId,
                WorkoutId=excerciselog.WorkoutId
            };
        }

    }
}
