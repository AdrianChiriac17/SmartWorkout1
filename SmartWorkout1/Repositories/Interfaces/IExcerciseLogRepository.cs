using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;

namespace SmartWorkout1.Repositories.Interfaces
{
    public interface IExcerciseLogRepository
    {
        ICollection<ExcerciseLog> GetExcerciseLogs();
        public ExcerciseLogDTO GetById(int? id);

        public void AddExcerciseLog(ExcerciseLogDTO excerciseLogDTO);
        public void EditExcerciseLog(ExcerciseLogDTO excerciseLogDTO);
        public void DeleteExcerciseLog(int? id);
        List<ExcerciseLogDTO> GetByWorkoutId(int? workoutId);
    }

}
