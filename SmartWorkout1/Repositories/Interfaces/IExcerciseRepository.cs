using SmartWorkout1.Entities;

namespace SmartWorkout1.Repositories.Interfaces
{
    public interface IExcerciseRepository
    {
        ICollection<Excercise> GetExcercises();
    }
}
