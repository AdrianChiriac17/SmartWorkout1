using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using SmartWorkout.Repositories.Interfaces;
using SmartWorkout1.Context;
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
        private NavigationManager Navigation { get; set; }

		[Inject]
		SmartWorkoutContext context { get; set; }

		[Parameter]
        public int? UserId { get; set; }


        protected override void OnParametersSet()
        {
            if (UserId != null)
            {
                UserDTO = UserRepository.GetById(UserId);
            }
        }

        [SupplyParameterFromForm]
        public UserDTO UserDTO { get; set; } = new UserDTO();
        public User User { get; set; } = new User();
        public async Task SaveUser()
        {

			if (UserId == null)
            {
                UserRepository.AddUser(UserDTO);
            }
            else
            {
                UserDTO.Id = UserId;
                UserRepository.EditUser(UserDTO);
            }
            await InvokeAsync(() => Navigation.NavigateTo("/UsersPage"));
        }
    }
}
