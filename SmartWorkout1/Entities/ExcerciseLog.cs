using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.Entities
{
    public class ExcerciseLog
    {
        public int Id { get; set; }

        public int Reps { get; set; }
        public int Duration { get; set; }

        public int ExcerciseId { get; set; }
        public Excercise Excercise { get; set; }

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
