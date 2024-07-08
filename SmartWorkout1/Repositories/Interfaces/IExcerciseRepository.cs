using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;

namespace SmartWorkout1.Repositories.Interfaces
{
    public interface IExcerciseRepository
    {
        ICollection<ExcerciseDTO> GetExcercises();

        ExcerciseDTO GetById(int? id);

        public void AddExcercise(ExcerciseDTO excerciseDTO);
        public void EditExcercise(ExcerciseDTO excerciseDTO);
        public void DeleteExcercise(int? id);

    }
}
