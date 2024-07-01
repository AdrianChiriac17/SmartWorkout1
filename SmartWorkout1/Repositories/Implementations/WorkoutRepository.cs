using Microsoft.EntityFrameworkCore;
using SmartWorkout1.Context;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Repositories.Implementations
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly SmartWorkoutContext _context;
        public WorkoutRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<Workout> GetWorkouts()
        {
            return _context.Workouts.Include(X=>X.User).ToList();
        }
    }
}
