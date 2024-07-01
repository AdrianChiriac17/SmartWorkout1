using Microsoft.EntityFrameworkCore;
using SmartWorkout1.Context;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Repositories.Implementations
{
    public class ExcerciseLogRepository : IExcerciseLogRepository
    {
        private readonly SmartWorkoutContext _context;
        public ExcerciseLogRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<ExcerciseLog> GetExcerciseLogs()
        {
           return _context.ExcerciseLogs.Include(X=>X.Excercise).Include(X=>X.Workout).ToList();
        }
    }
}
