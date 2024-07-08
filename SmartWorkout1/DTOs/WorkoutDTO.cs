

using SmartWorkout1.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.DTOs
{
    public class WorkoutDTO
    {
        public int Id { get; set; }

        [Required (ErrorMessage="Name of Workout is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; } = DateTime.Now;

        public bool Exist { get; set; } = true;

        public int UserId { get; set; }

    }
}
