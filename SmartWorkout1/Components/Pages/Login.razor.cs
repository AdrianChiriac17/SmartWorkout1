using Microsoft.AspNetCore.Components;
using SmartWorkout.Repositories.Interfaces;
using SmartWorkout1.Context;
using SmartWorkout1.DTOs;

namespace SmartWorkout1.Components.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        private NavigationManager Navigation { get; set; }
        [Inject]
        SmartWorkoutContext context { get; set; }

        [SupplyParameterFromForm]
        public LoginDTO loginDTO { get; set; } = new LoginDTO();

        public async void TryLogin()
        {
            var user = context.Users.FirstOrDefault(u => u.Email == loginDTO.Email);
            if (user != null)
            {
                var password = user.Birthday.ToString("MMyyyy");

                if (password == loginDTO.Password)
                {
                    await InvokeAsync(() => Navigation.NavigateTo("/UsersPage"));

                }
                else Failed = true;
			}
            else
            {
                Failed = true;
            }
        }
    }
}
