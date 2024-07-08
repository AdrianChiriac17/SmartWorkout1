using Microsoft.EntityFrameworkCore;
using SmartWorkout1.Context;
using SmartWorkout1.DTOs;
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

        public ExcerciseLogDTO GetById(int? id)
        {
            var excerciselog = _context.ExcerciseLogs.SingleOrDefault(e => e.Id == id);

            return ExcerciseLogDTO.FromEntity(excerciselog);
        }

        public List<ExcerciseLogDTO> GetByWorkoutId(int? workoutId)
        {
            var excerciselogDtos = _context.ExcerciseLogs
                .Where(el => el.WorkoutId == workoutId)
                .Select(el => ExcerciseLogDTO.FromEntity(el))
                .ToList();

            return excerciselogDtos;
        }

        public void AddExcerciseLog(ExcerciseLogDTO excerciseLogDTO)
        {
            _context.ExcerciseLogs.Add(new ExcerciseLog()
            {
                Reps = excerciseLogDTO.Reps,
                Duration = excerciseLogDTO.Duration,
                ExcerciseId = excerciseLogDTO.ExcerciseId,
                WorkoutId = excerciseLogDTO.WorkoutId,
            });
            _context.SaveChanges();
        }

        public void EditExcerciseLog(ExcerciseLogDTO excerciseLogDTO)
        {
            var excerciseLog = _context.ExcerciseLogs.SingleOrDefault(e => e.Id == excerciseLogDTO.Id);

            if (excerciseLog != null)
            {

                excerciseLog.Reps = excerciseLogDTO.Reps;
                excerciseLog.Duration = excerciseLogDTO.Duration;
                excerciseLog.ExcerciseId = excerciseLogDTO.ExcerciseId;
                excerciseLog.WorkoutId = excerciseLogDTO.WorkoutId;
                _context.SaveChanges();
            }
        }

        public void DeleteExcerciseLog(int? id)
        {
            if (id != null) _context.ExcerciseLogs.Where(el => el.Id == id).ExecuteDelete();
        }

    }
}
