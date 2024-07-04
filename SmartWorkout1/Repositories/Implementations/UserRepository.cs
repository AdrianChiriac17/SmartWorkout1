
using Microsoft.EntityFrameworkCore;
using SmartWorkout.Repositories.Interfaces;
using SmartWorkout1.Context;
using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartWorkoutContext _context;
        public UserRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(UserDTO userDTO)
        {
            _context.Users.Add(new User()
            {
                Birthday = userDTO.Birthday,
                Gender = userDTO.Gender,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
            });
            _context.SaveChanges(); 
        }

        public UserDTO GetById(int? id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            UserDTO userDTO = new UserDTO();
            userDTO.Exist = user != null;
            if (user != null)
            {
                userDTO.Gender = user.Gender;
                userDTO.FirstName = user.FirstName;
                userDTO.LastName = user.LastName;
                userDTO.Birthday = user.Birthday;
            }
            return userDTO;
        }

        public void EditUser(UserDTO userDTO)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userDTO.Id);

            if (user != null)
            {
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.Birthday = userDTO.Birthday;
                user.Gender = userDTO.Gender;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int? id)
        {
            if (id != null) _context.Users.Where(u => u.Id == id).ExecuteDelete();
        }

  
    }
}
