using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using SmartWorkout1.DTOs;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class AddEditUser : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [SupplyParameterFromForm]
        public UserDTO UserDTO { get; set; } = new UserDTO();

        [Parameter]
        public int UserId { get; set; }

        protected override void OnParametersSet()
        {
            if (UserId != null)
            {
                UserDTO = UserRepository.GetById((int)UserId);
            }
        }


        public async Task SaveUser()
        {
            var user = new User();
            user.FirstName = UserDTO.FirstName;
            user.LastName= UserDTO.LastName;
            user.Gender = UserDTO.Gender;
            user.Birthday = UserDTO.Birthday;

            UserRepository.AddUser(user);
            //NavigationManager.NavigateTo("/UsersPage");
            await InvokeAsync(() => NavigationManager.NavigateTo("/UsersPage"));
        }
    }
}
