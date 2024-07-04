using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        public void AddUser(UserDTO userDTO);
        UserDTO GetById(int? id);
        public void EditUser(UserDTO userDTO);

        public void DeleteUser(int? id);
    }

}