using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;

namespace SmartWorkout1.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        IQueryable<Workout> GetWorkouts();
        public void AddWorkout(WorkoutDTO workoutDTO);

        public void DeleteWorkout(int? id);
        WorkoutDTO GetById(int? id);
    }
}
