using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;

namespace SmartWorkout1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        void AddUser(User user);

        public UserDTO GetById (int UserId);
    }
}
