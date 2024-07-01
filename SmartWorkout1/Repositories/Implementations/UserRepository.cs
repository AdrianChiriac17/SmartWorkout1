using SmartWorkout1.Context;
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
    }
}
