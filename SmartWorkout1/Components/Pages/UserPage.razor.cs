using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
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
            base.OnInitialized();
        }

        private void EditUser(EditCommandContext<User> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/user/edit/{context.Item.Id}");
            }
        }
    }
}
