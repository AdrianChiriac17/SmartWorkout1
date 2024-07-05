using Microsoft.EntityFrameworkCore;
using SmartWorkout1.Context;
using SmartWorkout1.DTOs;
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

        public void AddWorkout(WorkoutDTO workoutDTO)
        {
            _context.Workouts.Add(new Workout()
            {
                UserId = workoutDTO.UserId,
                Name = workoutDTO.Name,
                Date = workoutDTO.Date,


            });
            _context.SaveChanges();

        }

        public void DeleteWorkout(int? id)
        {
            if (id != null) _context.Workouts.Where(w => w.Id == id).ExecuteDelete();
        }

        public WorkoutDTO GetById(int? id)
        {
            var workout = _context.Workouts.SingleOrDefault(w => w.Id == id);
            WorkoutDTO workoutDTO = new WorkoutDTO();

            workoutDTO.Exist = workout != null;
            
            if (workout != null)
            {
                workoutDTO.Name = workout.Name;
                workoutDTO.Date = workout.Date;
            }
            return workoutDTO;
        }
    }
}
