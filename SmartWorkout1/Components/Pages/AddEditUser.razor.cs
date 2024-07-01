using Microsoft.AspNetCore.Components;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class AddEditUser : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        [SupplyParameterFromForm]
        public User User { get; set; } = new User();

        public void SaveUser()
        {
            UserRepository.AddUser(User);
            //NavigationManager.NavigateTo("/UsersPage");
        }
    }
}
