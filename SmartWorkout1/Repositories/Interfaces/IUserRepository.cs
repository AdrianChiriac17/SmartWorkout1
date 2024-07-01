using SmartWorkout1.Entities;

namespace SmartWorkout1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        void AddUser(User user);
    }
}
