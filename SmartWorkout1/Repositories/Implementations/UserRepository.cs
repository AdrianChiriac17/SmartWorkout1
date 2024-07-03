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

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public UserDTO GetById(int UserId)
        {
            var user = _context.Users.SingleOrDefault(X => X.Id == UserId);
            UserDTO userModel = new UserDTO()
            {
                Birthday = user.Birthday,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            return userModel;
        }
    }
}
