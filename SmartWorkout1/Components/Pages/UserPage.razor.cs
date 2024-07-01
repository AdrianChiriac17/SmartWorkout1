using Microsoft.AspNetCore.Components;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class UserPage : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        private ICollection<User> users;

        protected override void OnInitialized()
        {
            users = UserRepository.GetUsers();
            base.OnInitialized();
        }
    }
}
