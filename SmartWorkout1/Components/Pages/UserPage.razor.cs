using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.Repositories.Interfaces;
using SmartWorkout1.Entities;
using SmartWorkout1.Repositories.Interfaces;

namespace SmartWorkout1.Components.Pages
{
    public partial class UserPage : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        private ICollection<User> users;

        protected override void OnInitialized()
        {
            users = UserRepository.GetUsers();
        }

        private void EditUser(EditCommandContext<User> context)
        {

            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/user/edit/{context.Item.Id}");
            }
        }
        private void AddWorkout(EditCommandContext<User> context)
        {

            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/workout/add/{context.Item.Id}");

            }
        }

        private void SeeWorkout(EditCommandContext<User> context)
        {

            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/WorkoutPage/user/{context.Item.Id}");

            }
        }


        private void DeleteUser(DeleteCommandContext<User> context)
        {
            
            var id = context.Item.Id;

            if (context != null && context.Item != null)
            {
                UserRepository.DeleteUser(id);
                NavigationManager.Refresh(forceReload: true);
            }

        }
    }
}
