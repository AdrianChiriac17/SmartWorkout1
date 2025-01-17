﻿namespace SmartWorkout1.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<ExcerciseLog> ExcerciseLogs { get; set; }

    }
}
